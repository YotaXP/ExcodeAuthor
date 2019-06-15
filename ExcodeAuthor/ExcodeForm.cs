using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;

namespace ExcodeAuthor
{
    public partial class ExcodeForm : Form
    {
        private System.Timers.Timer scanTimer = new System.Timers.Timer(500);

        public ExcodeForm(string path, bool untitled) {
            scanTimer.Elapsed += new System.Timers.ElapsedEventHandler(ScanForErrors);
            scanTimer.SynchronizingObject = this;
            scanTimer.AutoReset = false;
            ResizeRedraw = true;
            InitializeComponent();
            updateForm = new UpdateForm(updateToolStripButton, this);
            LoadRecentFiles();
            if (path.Length > 0) {
                OpenFile(path);
                isDirty = false;
                currentFileName = "Untitled";
                Text = "Excode Author - Untitled";
            }
        }

        private readonly string[] emptyLine = new[] { "" };
        private string[][] SplitCommands() {
            List<string[]> ret = new List<string[]>();
            System.IO.StringReader sr = new System.IO.StringReader(codeBox.Text);
            while(true) {
                string line = sr.ReadLine();
                if (line == null) break;
                line = line.TrimStart(' ', '\t');
                if (line.Length == 0 || line.StartsWith("'") || line.StartsWith("//") || line.StartsWith("comment;", true, System.Globalization.CultureInfo.InvariantCulture) || line.ToLowerInvariant() == "comment") {
                    ret.Add(emptyLine);
                    continue;
                }
                string[] parts = line.Split(';');
                parts[0] = parts[0].ToLowerInvariant();
                ret.Add(parts);
            }
            return ret.ToArray();
        }

        private List<string> identifiers = new List<string>();
        private void ResetVariables() {
            identifiers.Clear();
            identifiers.AddRange(new[] {";null", ";err_level", ";out_level", ";input", ";arg"});
        }
        private int CheckVariable(string name, string function) {
            if (name.StartsWith("\"")) return -1;
            int colon = name.IndexOf(':');
            if (colon == 0) return -2;
            if (colon != -1) {
                if (CheckVariable(name.Substring(colon + 1), function) == -2) return -2;
                name = name.Substring(0, colon);
            }
            if (name.Trim(' ', '\t').Length == 0) return -2;
            if (!name.StartsWith("#")) function = "";
            int index = identifiers.IndexOf(function + ";" + name);
            if (index == -1) {
                index = identifiers.Count;
                identifiers.Add(function + ";" + name);
            }
            return index;
        }

        /* Defined:
         * x id (needs to make use of 'identifiers' list)
         * x goto (needs to make use of 'identifiers' list)
         * x if (needs to make use of 'identifiers' list)
         * X shell
         * X set
         * X eval
         * X init_list
         * X list_moveup
         *   length
         *   char
         *   findtext
         *   replacetext
         *   copytext
         *   dumpfile
         *   getfile
         *   dumppath
         *   end
         * X func
         *   call
         * X endfunc
         */

        Regex lineNumRegex = new System.Text.RegularExpressions.Regex(@"^Line (\d+):");
        private void ScanForErrors(object sender, System.Timers.ElapsedEventArgs e) { // TODO: Make error sorting more effecient.  Should not require Regex.
            List<string> errors = new List<string>();
            string[][] lines = SplitCommands();
            ResetVariables();
            Dictionary<int, string> gotos = new Dictionary<int,string>();
            string funcName = "";
            for (int lineNum = 0; lineNum < lines.Length; lineNum++)
			{
                string[] line = lines[lineNum];
                switch (line[0]) {
                    case "": break;
                    case "id":
                        if (line.Length > 2) errors.Add(string.Format("Line {0}: Too many parameters.  Expected 1.  id;label", lineNum + 1));
                        else if (line.Length < 2) errors.Add(string.Format("Line {0}: Too few parameters.  Expected 1.  id;label", lineNum + 1));
                        else if (line.Any(p => string.IsNullOrEmpty(p.Trim(' ', '\t')))) errors.Add(string.Format("Line {0}: Blank parameter not acceptable.  id;label", lineNum + 1));
                        else {
                            if (identifiers.Contains(funcName + ";;" + line[1])) {
                                if (funcName == "") errors.Add(string.Format("Line {0}: Duplicate label definition for '{1}'.", lineNum + 1, line[1]));
                                else errors.Add(string.Format("Line {0}: Duplicate label definition for '{1}' in function '{2}'.", lineNum + 1, line[1], funcName));
                            }
                            else identifiers.Add(funcName + ";;" + line[1]);
                        }
                        break;
                    case "goto":
                        if (line.Length > 2) errors.Add(string.Format("Line {0}: Too many parameters.  Expected 1.  goto;label", lineNum + 1));
                        else if (line.Length < 2) errors.Add(string.Format("Line {0}: Too few parameters.  Expected 1.  goto;label", lineNum + 1));
                        else if (line.Any(p => string.IsNullOrEmpty(p.Trim(' ', '\t')))) errors.Add(string.Format("Line {0}: Blank parameter not acceptable.  goto;label", lineNum + 1));
                        else gotos[lineNum] = funcName + ";;" + line[1];
                        break;
                    case "if":
                        if (line.Length > 5) errors.Add(string.Format("Line {0}: Too many parameters.  Expected 4.  if;input1;operator;input2;label", lineNum + 1));
                        else if (line.Length < 5) errors.Add(string.Format("Line {0}: Too few parameters.  Expected 4.  if;input1;operator;input2;label", lineNum + 1));
                        else if (line.Any(p => string.IsNullOrEmpty(p.Trim(' ', '\t')))) errors.Add(string.Format("Line {0}: Blank parameter not acceptable.  if;input1;operator;input2;label", lineNum + 1));
                        else {
                            if (line[2] != "==" && line[2] != "!=" && line[2] != ">=" && line[2] != "<=" && line[2] != ">" && line[2] != "<") errors.Add(string.Format("Line {0}: Unknown comparison operator '{1}'.  Expected ==, !=, >=, <=, >, or <.", lineNum + 1, line[2]));
                            gotos[lineNum] = funcName + ";;" + line[4];
                            if (CheckVariable(line[1], funcName) == -2 || CheckVariable(line[3], funcName) == -2) errors.Add(string.Format("Line {0}: Bad input parameter.", lineNum + 1));
                        }
                        break;
                    case "shell":
                        if (line.Length > 2) errors.Add(string.Format("Line {0}: Too many parameters.  Expected 1.  shell;input", lineNum + 1));
                        else if (line.Length < 2) errors.Add(string.Format("Line {0}: Too few parameters.  Expected 1.  shell;input", lineNum + 1));
                        else if (line.Any(p => string.IsNullOrEmpty(p.Trim(' ', '\t')))) errors.Add(string.Format("Line {0}: Blank parameter not acceptable.  shell;input", lineNum + 1));
                        else if (CheckVariable(line[1], funcName) == -2) errors.Add(string.Format("Line {0}: Bad input parameter.", lineNum + 1));
                        break;
                    case "set":
                        if (line.Length > 3) errors.Add(string.Format("Line {0}: Too many parameters.  Expected 2.  set;variable;input", lineNum + 1));
                        else if (line.Length < 3) errors.Add(string.Format("Line {0}: Too few parameters.  Expected 2.  set;variable;input", lineNum + 1));
                        else if (line.Any(p => string.IsNullOrEmpty(p.Trim(' ', '\t')))) errors.Add(string.Format("Line {0}: Blank parameter not acceptable.  set;variable;input", lineNum + 1));
                        else {
                            if (CheckVariable(line[1], funcName) < 0) errors.Add(string.Format("Line {0}: First parameter must be a variable.  set;variable;input", lineNum + 1));
                            if (CheckVariable(line[2], funcName) == -2) errors.Add(string.Format("Line {0}: Bad input parameter.", lineNum + 1));
                        }
                        break;
                    case "eval": // ++ and -- are Nadrew's additions.
                        if (line.Length > 4) errors.Add(string.Format("Line {0}: Too many parameters.  Expected 2 or 3.  eval;variable;operator[;input]", lineNum + 1));
                        else if (line.Length < 3) errors.Add(string.Format("Line {0}: Too few parameters.  Expected 2 or 3.  eval;variable;operator[;input]", lineNum + 1));
                        else if (line.Any(p => string.IsNullOrEmpty(p.Trim(' ', '\t')))) errors.Add(string.Format("Line {0}: Blank parameter not acceptable.  eval;variable;operator[;input]", lineNum + 1));
                        else {
                            if (CheckVariable(line[1], funcName) < 0) errors.Add(string.Format("Line {0}: First parameter must be a variable.  eval;variable;operator[;input]", lineNum + 1));
                            if (line[2] != "+=" && line[2] != "-=" && line[2] != "*=" && line[2] != "/=" && line[2] != "++" && line[2] != "--") errors.Add(string.Format("Line {0}: Unknown math operator '{1}'.  Expected +=, -=, *=, /=, ++, or --.", lineNum + 1, line[2]));
                            if (line[2] == "++" || line[2] == "--") {
                                if (line.Length == 4) errors.Add(string.Format("Line {0}: The {1} operator does not allow a third paramiter.", lineNum + 1, line[2]));
                            }
                            else {
                                if (line.Length == 3) errors.Add(string.Format("Line {0}: The {1} operator requires a third paramiter.", lineNum + 1, line[2]));
                                else if (CheckVariable(line[3], funcName) == -2) errors.Add(string.Format("Line {0}: Bad input parameter.", lineNum + 1));
                            }
                        }
                        break;
                    case "init_list":
                        if (line.Length > 2) errors.Add(string.Format("Line {0}: Too many parameters.  Expected 1.  init_list;variable", lineNum + 1));
                        else if (line.Length < 2) errors.Add(string.Format("Line {0}: Too few parameters.  Expected 1.  init_list;variable", lineNum + 1));
                        else if (line.Any(p => string.IsNullOrEmpty(p.Trim(' ', '\t')))) errors.Add(string.Format("Line {0}: Blank parameter not acceptable.  init_list;variable", lineNum + 1));
                        else if (CheckVariable(line[1], funcName) < 0) errors.Add(string.Format("Line {0}: First parameter must be a variable.  init_list;variable", lineNum + 1));
                        break;
                    case "list_moveup":
                        if (line.Length > 2) errors.Add(string.Format("Line {0}: Too many parameters.  Expected 1.  list_moveup;variable", lineNum + 1));
                        else if (line.Length < 2) errors.Add(string.Format("Line {0}: Too few parameters.  Expected 1.  list_moveup;variable", lineNum + 1));
                        else if (line.Any(p => string.IsNullOrEmpty(p.Trim(' ', '\t')))) errors.Add(string.Format("Line {0}: Blank parameter not acceptable.  list_moveup;variable", lineNum + 1));
                        else if (CheckVariable(line[1], funcName) < 0) errors.Add(string.Format("Line {0}: First parameter must be a variable.  list_moveup;variable", lineNum + 1));
                        break;
                    case "length":
                        if (line.Length > 3) errors.Add(string.Format("Line {0}: Too many parameters.  Expected 2.  length;variable;input", lineNum + 1));
                        else if (line.Length < 3) errors.Add(string.Format("Line {0}: Too few parameters.  Expected 2.  length;variable;input", lineNum + 1));
                        else if (line.Any(p => string.IsNullOrEmpty(p.Trim(' ', '\t')))) errors.Add(string.Format("Line {0}: Blank parameter not acceptable.  length;variable;input", lineNum + 1));
                        else {
                            if (CheckVariable(line[1], funcName) < 0) errors.Add(string.Format("Line {0}: First parameter must be a variable.  length;variable;input", lineNum + 1));
                            if (CheckVariable(line[2], funcName) == -2) errors.Add(string.Format("Line {0}: Bad input parameter.", lineNum + 1));
                        }
                        break;
                    case "char":
                        if (line.Length > 3) errors.Add(string.Format("Line {0}: Too many parameters.  Expected 2.  char;variable;input", lineNum + 1));
                        else if (line.Length < 3) errors.Add(string.Format("Line {0}: Too few parameters.  Expected 2.  char;variable;input", lineNum + 1));
                        else if (line.Any(p => string.IsNullOrEmpty(p.Trim(' ', '\t')))) errors.Add(string.Format("Line {0}: Blank parameter not acceptable.  char;variable;input", lineNum + 1));
                        else {
                            if (CheckVariable(line[1], funcName) < 0) errors.Add(string.Format("Line {0}: First parameter must be a variable.  char;variable;input", lineNum + 1));
                            int v = CheckVariable(line[2], funcName);
                            if (v == -2) errors.Add(string.Format("Line {0}: Bad input parameter.", lineNum + 1));
                            else if (v == -1) {
                                int ch;
                                if (!int.TryParse(line[2].Substring(1), out ch) || ch < 0 || ch > 255) errors.Add(string.Format("Line {0}: If a literal is given to a 'char' command, it must be an integer between 0 and 255.", lineNum + 1));
                            }
                        }
                        break;
                    case "findtext":
                        if (line.Length > 6) errors.Add(string.Format("Line {0}: Too many parameters.  Expected 3 to 5.  findtext;variable;input1;input2;input3;input4", lineNum + 1));
                        else if (line.Length < 4) errors.Add(string.Format("Line {0}: Too few parameters.  Expected 3 to 5.  findtext;variable;input1;input2;input3;input4", lineNum + 1));
                        else if (line.Any(p => string.IsNullOrEmpty(p.Trim(' ', '\t')))) errors.Add(string.Format("Line {0}: Blank parameter not acceptable.  findtext;variable;input1;input2;input3;input4", lineNum + 1));
                        else {
                            if (CheckVariable(line[1], funcName) < 0) errors.Add(string.Format("Line {0}: First parameter must be a variable.  findtext;variable;input1;input2;input3;input4", lineNum + 1));
                            if (CheckVariable(line[2], funcName) == -2 || CheckVariable(line[3], funcName) == -2 || (line.Length > 4 && CheckVariable(line[4], funcName) == -2) || (line.Length > 5 && CheckVariable(line[5], funcName) == -2)) errors.Add(string.Format("Line {0}: Bad input parameter.", lineNum + 1));
                        }
                        break;
                    case "replacetext":
                        if (line.Length > 5) errors.Add(string.Format("Line {0}: Too many parameters.  Expected 4.  replacetext;variable;input1;input2;input3", lineNum + 1));
                        else if (line.Length < 5) errors.Add(string.Format("Line {0}: Too few parameters.  Expected 4.  replacetext;variable;input1;input2;input3", lineNum + 1));
                        else if (line.Any(p => string.IsNullOrEmpty(p.Trim(' ', '\t')))) errors.Add(string.Format("Line {0}: Blank parameter not acceptable.  replacetext;variable;input1;input2;input3", lineNum + 1));
                        else {
                            if (CheckVariable(line[1], funcName) < 0) errors.Add(string.Format("Line {0}: First parameter must be a variable.  replacetext;variable;input1;input2;input3", lineNum + 1));
                            if (CheckVariable(line[2], funcName) == -2 || CheckVariable(line[3], funcName) == -2 || CheckVariable(line[4], funcName) == -2) errors.Add(string.Format("Line {0}: Bad input parameter.", lineNum + 1));
                        }
                        break;
                    case "copytext":
                        if (line.Length > 5) errors.Add(string.Format("Line {0}: Too many parameters.  Expected 4.  copytext;variable;input1;input2;input3", lineNum + 1));
                        else if (line.Length < 5) errors.Add(string.Format("Line {0}: Too few parameters.  Expected 4.  copytext;variable;input1;input2;input3", lineNum + 1));
                        else if (line.Any(p => string.IsNullOrEmpty(p.Trim(' ', '\t')))) errors.Add(string.Format("Line {0}: Blank parameter not acceptable.  copytext;variable;input1;input2;input3", lineNum + 1));
                        else {
                            if (CheckVariable(line[1], funcName) < 0) errors.Add(string.Format("Line {0}: First parameter must be a variable.  findtextcopytextvariable;input1;input2;input3", lineNum + 1));
                            if (CheckVariable(line[2], funcName) == -2 || CheckVariable(line[3], funcName) == -2 || CheckVariable(line[4], funcName) == -2) errors.Add(string.Format("Line {0}: Bad input parameter.", lineNum + 1));
                        }
                        break;
                    case "dumpfile":
                        if (line.Length > 3) errors.Add(string.Format("Line {0}: Too many parameters.  Expected 2.  dumpfile;input;variable", lineNum + 1));
                        else if (line.Length < 3) errors.Add(string.Format("Line {0}: Too few parameters.  Expected 2.  dumpfile;input;variable", lineNum + 1));
                        else if (line.Any(p => string.IsNullOrEmpty(p.Trim(' ', '\t')))) errors.Add(string.Format("Line {0}: Blank parameter not acceptable.  dumpfile;input;variable", lineNum + 1));
                        else {
                            if (CheckVariable(line[1], funcName) == -2) errors.Add(string.Format("Line {0}: Bad input parameter.", lineNum + 1));
                            if (CheckVariable(line[2], funcName) < 0) errors.Add(string.Format("Line {0}: Second parameter must be a variable.  dumpfile;input;variable", lineNum + 1));
                        }
                        break;
                    case "getfile":
                        if (line.Length > 3) errors.Add(string.Format("Line {0}: Too many parameters.  Expected 2.  getfile;variable;input", lineNum + 1));
                        else if (line.Length < 3) errors.Add(string.Format("Line {0}: Too few parameters.  Expected 2.  getfile;variable;input", lineNum + 1));
                        else if (line.Any(p => string.IsNullOrEmpty(p.Trim(' ', '\t')))) errors.Add(string.Format("Line {0}: Blank parameter not acceptable.  getfile;variable;input", lineNum + 1));
                        else {
                            if (CheckVariable(line[1], funcName) < 0) errors.Add(string.Format("Line {0}: First parameter must be a variable.  getfile;variable;input", lineNum + 1));
                            if (CheckVariable(line[2], funcName) == -2) errors.Add(string.Format("Line {0}: Bad input parameter.", lineNum + 1));
                        }
                        break;
                    case "dumppath":
                        if (line.Length > 3) errors.Add(string.Format("Line {0}: Too many parameters.  Expected 2.  dumppath;variable;input", lineNum + 1));
                        else if (line.Length < 3) errors.Add(string.Format("Line {0}: Too few parameters.  Expected 2.  dumppath;variable;input", lineNum + 1));
                        else if (line.Any(p => string.IsNullOrEmpty(p.Trim(' ', '\t')))) errors.Add(string.Format("Line {0}: Blank parameter not acceptable.  dumppath;variable;input", lineNum + 1));
                        else {
                            if (CheckVariable(line[1], funcName) < 0) errors.Add(string.Format("Line {0}: First parameter must be a variable.  dumppath;variable;input", lineNum + 1));
                            if (CheckVariable(line[2], funcName) == -2) errors.Add(string.Format("Line {0}: Bad input parameter.", lineNum + 1));
                        }
                        break;
                    case "end":
                        if (line.Length > 2) errors.Add(string.Format("Line {0}: Too many parameters.  Expected at most 1.  end;input", lineNum + 1));
                        else if (line.Length == 2 && CheckVariable(line[1], funcName) == -2 && line[1] != "") errors.Add(string.Format("Line {0}: Bad input parameter.", lineNum + 1));
                        break;

                    // Nadrew's Additions
                    case "rand":
                        if (line.Length > 4) errors.Add(string.Format("Line {0}: Too many parameters.  Expected 3.  rand;input1;input2;variable", lineNum + 1));
                        else if (line.Length < 4) errors.Add(string.Format("Line {0}: Too few parameters.  Expected 3.  rand;input1;input2;variable", lineNum + 1));
                        else if (line.Any(p => string.IsNullOrEmpty(p.Trim(' ', '\t')))) errors.Add(string.Format("Line {0}: Blank parameter not acceptable.  rand;input1;input2;variable", lineNum + 1));
                        else {
                            if (CheckVariable(line[1], funcName) == -2 || CheckVariable(line[2], funcName) == -2) errors.Add(string.Format("Line {0}: Bad input parameter.", lineNum + 1));
                            if (CheckVariable(line[3], funcName) < 0) errors.Add(string.Format("Line {0}: Third parameter must be a variable.  rand;input1;input2;variable", lineNum + 1));
                        }
                        break;
                    case "echo_var":
                        if (line.Length > 2) errors.Add(string.Format("Line {0}: Too many parameters.  Expected 1.  echo_var;input", lineNum + 1));
                        else if (line.Length < 2) errors.Add(string.Format("Line {0}: Too few parameters.  Expected 1.  echo_var;input", lineNum + 1));
                        else if (line.Any(p => string.IsNullOrEmpty(p.Trim(' ', '\t')))) errors.Add(string.Format("Line {0}: Blank parameter not acceptable.  echo_var;input", lineNum + 1));
                        else if (CheckVariable(line[1], funcName) == -2 && line[1] != "") errors.Add(string.Format("Line {0}: Bad input parameter.", lineNum + 1));
                        break;
                    case "ckey":
                        if (line.Length > 3) errors.Add(string.Format("Line {0}: Too many parameters.  Expected 2.  ckey;input;variable", lineNum + 1));
                        else if (line.Length < 3) errors.Add(string.Format("Line {0}: Too few parameters.  Expected 2.  ckey;input;variable", lineNum + 1));
                        else if (line.Any(p => string.IsNullOrEmpty(p.Trim(' ', '\t')))) errors.Add(string.Format("Line {0}: Blank parameter not acceptable.  ckey;input;variable", lineNum + 1));
                        else {
                            if (CheckVariable(line[1], funcName) == -2) errors.Add(string.Format("Line {0}: Bad input parameter.", lineNum + 1));
                            if (CheckVariable(line[2], funcName) < 0) errors.Add(string.Format("Line {0}: Second parameter must be a variable.  ckey;input;variable", lineNum + 1));
                        }
                        break;
                    case "uppertext":
                        if (line.Length > 3) errors.Add(string.Format("Line {0}: Too many parameters.  Expected 2.  uppertext;input;variable", lineNum + 1));
                        else if (line.Length < 3) errors.Add(string.Format("Line {0}: Too few parameters.  Expected 2.  uppertext;input;variable", lineNum + 1));
                        else if (line.Any(p => string.IsNullOrEmpty(p.Trim(' ', '\t')))) errors.Add(string.Format("Line {0}: Blank parameter not acceptable.  uppertext;input;variable", lineNum + 1));
                        else {
                            if (CheckVariable(line[1], funcName) == -2) errors.Add(string.Format("Line {0}: Bad input parameter.", lineNum + 1));
                            if (CheckVariable(line[2], funcName) < 0) errors.Add(string.Format("Line {0}: Second parameter must be a variable.  uppertext;input;variable", lineNum + 1));
                        }
                        break;
                    case "lowertext":
                        if (line.Length > 3) errors.Add(string.Format("Line {0}: Too many parameters.  Expected 2.  lowertext;input;variable", lineNum + 1));
                        else if (line.Length < 3) errors.Add(string.Format("Line {0}: Too few parameters.  Expected 2.  lowertext;input;variable", lineNum + 1));
                        else if (line.Any(p => string.IsNullOrEmpty(p.Trim(' ', '\t')))) errors.Add(string.Format("Line {0}: Blank parameter not acceptable.  lowertext;input;variable", lineNum + 1));
                        else {
                            if (CheckVariable(line[1], funcName) == -2) errors.Add(string.Format("Line {0}: Bad input parameter.", lineNum + 1));
                            if (CheckVariable(line[2], funcName) < 0) errors.Add(string.Format("Line {0}: Second parameter must be a variable.  lowertext;input;variable", lineNum + 1));
                        }
                        break;
                    case "md5":
                        if (line.Length > 3) errors.Add(string.Format("Line {0}: Too many parameters.  Expected 2.  md5;input;variable", lineNum + 1));
                        else if (line.Length < 3) errors.Add(string.Format("Line {0}: Too few parameters.  Expected 2.  md5;input;variable", lineNum + 1));
                        else if (line.Any(p => string.IsNullOrEmpty(p.Trim(' ', '\t')))) errors.Add(string.Format("Line {0}: Blank parameter not acceptable.  md5;input;variable", lineNum + 1));
                        else {
                            if (CheckVariable(line[1], funcName) == -2) errors.Add(string.Format("Line {0}: Bad input parameter.", lineNum + 1));
                            if (CheckVariable(line[2], funcName) < 0) errors.Add(string.Format("Line {0}: Second parameter must be a variable.  md5;input;variable", lineNum + 1));
                        }
                        break;
                    case "ascii":
                        if (line.Length > 3) errors.Add(string.Format("Line {0}: Too many parameters.  Expected 2.  ascii;variable;input", lineNum + 1));
                        else if (line.Length < 3) errors.Add(string.Format("Line {0}: Too few parameters.  Expected 2.  ascii;variable;input", lineNum + 1));
                        else if (line.Any(p => string.IsNullOrEmpty(p.Trim(' ', '\t')))) errors.Add(string.Format("Line {0}: Blank parameter not acceptable.  ascii;variable;input", lineNum + 1));
                        else {
                            if (CheckVariable(line[1], funcName) < 0) errors.Add(string.Format("Line {0}: First parameter must be a variable.  ascii;variable;input", lineNum + 1));
                            if (CheckVariable(line[2], funcName) == -2) errors.Add(string.Format("Line {0}: Bad input parameter.", lineNum + 1));
                        }
                        break;
                    case "getenv":
                        if (line.Length > 3) errors.Add(string.Format("Line {0}: Too many parameters.  Expected 1 or 2.  getenv[;input];variable", lineNum + 1));
                        else if (line.Length < 2) errors.Add(string.Format("Line {0}: Too few parameters.  Expected 1 or 2.  getenv[;input];variable", lineNum + 1));
                        else if (line.Any(p => string.IsNullOrEmpty(p.Trim(' ', '\t')))) errors.Add(string.Format("Line {0}: Blank parameter not acceptable.  getenv[;input];variable", lineNum + 1));
                        else {
                            if (line.Length == 3) {
                                if (CheckVariable(line[1], funcName) == -2) errors.Add(string.Format("Line {0}: Bad input parameter.", lineNum + 1));
                                else if (line[1].Contains(' ')) errors.Add(string.Format("Line {0}: Spaces and semicolons are stripped from enviroment variable names.", lineNum + 1));
                                if (CheckVariable(line[2], funcName) < 0) errors.Add(string.Format("Line {0}: Second parameter must be a variable.  getenv[;input];variable", lineNum + 1));
                            }
                            else
                                if (CheckVariable(line[1], funcName) < 0) errors.Add(string.Format("Line {0}: First parameter must be a variable, or expected 2 parameters.  getenv[;input];variable", lineNum + 1));
                        }
                        break;
                    case "setenv":
                        if (line.Length > 3) errors.Add(string.Format("Line {0}: Too many parameters.  Expected 2.  setenv;input;input", lineNum + 1));
                        else if (line.Length < 3) errors.Add(string.Format("Line {0}: Too few parameters.  Expected 2.  setenv;input;input", lineNum + 1));
                        else if (line.Any(p => string.IsNullOrEmpty(p.Trim(' ', '\t')))) errors.Add(string.Format("Line {0}: Blank parameter not acceptable.  setenv;input;input", lineNum + 1));
                        else {
                            if (CheckVariable(line[1], funcName) == -2) errors.Add(string.Format("Line {0}: Bad input parameter.", lineNum + 1));
                            else if (line[1].Contains(' ')) errors.Add(string.Format("Line {0}: Spaces and semicolons are stripped from enviroment variable names.", lineNum + 1));
                            if (CheckVariable(line[2], funcName) == -2) errors.Add(string.Format("Line {0}: Bad input parameter.", lineNum + 1));
                        }
                        break;

                    // Metacode

                    //case "func":
                    //    if (line.Length < 2) errors.Add(string.Format("Line {0}: Too few parameters.  Expected at least 1.  func;method;variables...", lineNum + 1));
                    //    else if (funcName != "") errors.Add(string.Format("Line {0}: Function '{1}' defined within function '{2}'.", lineNum + 1, line[1], funcName));
                    //    else if (identifiers.Contains(line[1])) errors.Add(string.Format("Line {0}: Duplicate function definition for '{1}'.", lineNum + 1, line[1]));
                    //    else {
                    //        funcName = line[1];
                    //        identifiers.Add(funcName);
                    //        for (int i = 2; i < line.Length; i++) {
                    //            if(!line[i].StartsWith("#")) line[i] = "#" + line[i];
                    //            if (identifiers.Contains(funcName + ";" + line[i])) errors.Add(string.Format("Line {0}: Duplicate parameter definition in '{1}' for '{2}'.", lineNum + 1, funcName, line[i]));
                    //            else if(CheckVariable(line[i], funcName) < 0) errors.Add(string.Format("Line {0}: Bad variable definition in '{1}' for '{2}'.", lineNum + 1, funcName, line[i]));
                    //        }
                    //    }
                    //    break;
                    //case "endfunc":
                    //    if (line.Length > 1) errors.Add(string.Format("Line {0}: Too many parameters.  Expected 0.  endfunc", lineNum + 1));
                    //    else if (funcName == "") errors.Add(string.Format("Line {0}: 'endfunc' command without a function.", lineNum + 1));
                    //    else funcName = "";
                    //    break;
                    default:
                        errors.Add(string.Format("Line {0}: Unknown command: '{1}'", lineNum + 1, line[0]));
                        break;
                }
            }
            //if (funcName != "") errors.Add(string.Format("Line {0}: Function '{1}' not terminated with an 'endfunc'.", lines.Length, funcName));
            foreach (int i in gotos.Keys)
                if (!identifiers.Contains(gotos[i])) {
                    //int pos = gotos[i].IndexOf(";;");
                    /*if (pos == 0)*/ errors.Add(string.Format("Line {0}: Undefined label '{1}'.", i + 1, gotos[i].Substring(2)));
                    //else errors.Add(string.Format("Line {0}: Undefined label '{1}' in function '{2}'.", i + 1, gotos[i].Substring(0, pos), gotos[i].Substring(pos + 2)));
                }
            errors.Sort((x,y) => (int.Parse(lineNumRegex.Match(x).Groups[1].Value) - int.Parse(lineNumRegex.Match(y).Groups[1].Value)));
            errorBox.Items.Clear();
            errorBox.Items.AddRange(errors.ToArray());
            variableBox.Items.Clear();
            variableBox.Items.AddRange((from i in identifiers
                         let l = i.StartsWith(";;")
                         orderby i descending
                         select l ? ": " + i.Substring(2) : i.Substring(1)).ToArray());
            errorBox.BackColor = SystemColors.Window;
        }

        public RichTextBox CodeBox { get { return codeBox; } }

        private int identCount = 0;
        private Dictionary<string, Dictionary<string, string>> identRenames = new Dictionary<string, Dictionary<string, string>>();
        private string GetIdentifier(string original, string function) {
            return identRenames[function][original] ?? (identRenames[function][original] = "i" + (++identCount).ToString());
        }

        private void copyRaw_Click(object sender, EventArgs e) {
            Clipboard.Clear();
            if (!string.IsNullOrEmpty(codeBox.Text))
                Clipboard.SetText(codeBox.Text, TextDataFormat.Text);
        }

        private void copyClean_Click(object sender, EventArgs e) {
            string[][] lines = SplitCommands();
            StringBuilder sb = new StringBuilder();
            foreach(string[] line in lines) if(line != emptyLine) sb.AppendLine(string.Join(";", line));
            Clipboard.Clear();
            if (sb.Length > 0) {
                sb.Remove(sb.Length - 1, 1);
                Clipboard.SetText(sb.ToString(), TextDataFormat.Text);
            }
        }

        private void copyScript_Click(object sender, EventArgs e) {
            string filename = copyScriptName.Text;
            if (filename.Length == 0 || filename.Contains(' ') || filename.Contains('/') || filename.Contains(':') || filename.Contains(';') || filename == "root") {
                MessageBox.Show("The filename must be at least one character long, and must not contain spaces, slashes, colons, or semicolons, and cannot be 'root'.");
                return;
            }
            //string[][] lines = SplitCommands();
            var lines = SplitCommands().Select(line => line.Select(segment =>
                segment
                    .Replace("[bracket_l]", "[bracket_l]bracket_l]")
                    .Replace("[bracket_r]", "[bracket_l]bracket_r]")
                    .Replace("[newline]", "[bracket_l]newline]")
                    .Replace("[semi]", "[bracket_l]semi]")
                    .Replace("[space]", "[bracket_l]space]")
                ).ToArray());
            StringBuilder sb = new StringBuilder();
            bool useNewline = (ModifierKeys & Keys.Control) != 0;
            bool makeFile = (ModifierKeys & Keys.Alt) == 0;
            if (makeFile) sb.Append("del " + filename + ";delay 0;make " + filename + ";");
            sb.Append("file_add " + filename + " ");
            int len = sb.Length;
            foreach (var line in lines)
                if (line != emptyLine) {
                    if (useNewline) sb.AppendLine(string.Join("[semi]", line));
                    else sb.Append(string.Join("[semi]", line) + "[newline]");
                }
            if (sb.Length > len) {
                if (useNewline) sb.Remove(sb.Length - 1, 1);
                else sb.Remove(sb.Length - 9, 9);
            }
            if(makeFile) sb.Append(";run /bin/compiler.exe " + filename);
            Clipboard.Clear();
            Clipboard.SetText(sb.ToString(), TextDataFormat.Text);
        }

        private void codeBox_TextChanged(object sender, EventArgs e) {
            if (!isDirty) {
                isDirty = true;
                Text = "Excode Author - " + Path.GetFileNameWithoutExtension(currentFileName) + "*";
            }
            scanTimer.Stop();
            scanTimer.Start();
            errorBox.BackColor = ControlPaint.Dark(SystemColors.Window, 0.05f);
        }


        private IEnumerable<string> GetRecentFiles() {
            var sr = new StringReader(ExcodeAuthor.Properties.Settings.Default.Recent);
            string line = sr.ReadLine();
            while (line != null && line.Length > 0) {
                yield return line;
                line = sr.ReadLine();
            }
        }

        private void OpenFile(string path) {
            if (!File.Exists(path)) {
                if (MessageBox.Show("The file '" + Path.GetFileName(path) + "' no longer exists, or is inaccessable.", "File Missing", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Retry)
                    OpenFile(path);
                return;
            }
            if (CheckDirtyFile()) return;
            codeBox.LoadFile(currentFileName = path, RichTextBoxStreamType.PlainText);
            Text = "Excode Author - " + Path.GetFileNameWithoutExtension(currentFileName);
            isDirty = false;
            AddRecentFile(path);
        }

        private bool CheckDirtyFile() {
            if(isDirty)
                switch(MessageBox.Show("This file has been modified.  Would you like to save the changes?", "Save Changes", MessageBoxButtons.YesNoCancel)){
                    case DialogResult.Yes:
                        return SaveFile(false, true);
                    case DialogResult.Cancel:
                        return true;
                }
            return false;
        }

        private string currentFileName = "Untitled";
        private bool isDirty = false;
        private bool SaveFile(bool prompt, bool reopen) {
            string path = currentFileName;
            if (prompt || currentFileName == "Untitled") {
                saveFileDialog.FileName = Path.GetFileName(currentFileName);
                saveFileDialog.InitialDirectory = Path.GetDirectoryName(currentFileName);
                if (saveFileDialog.ShowDialog() != DialogResult.OK) return true;
                path = saveFileDialog.FileName;
                if (reopen) currentFileName = path;
            }
            codeBox.SaveFile(path, RichTextBoxStreamType.PlainText);
            if(prompt || reopen) AddRecentFile(path);
            if (reopen) {
                isDirty = false;
                Text = "Excode Author - " + Path.GetFileNameWithoutExtension(currentFileName);
            }
            return false;
        }

        List<ToolStripMenuItem> recentFileMenuItems = new List<ToolStripMenuItem>();

        private void LoadRecentFiles() {
            foreach (var i in GetRecentFiles()) {
                var menu = new ToolStripMenuItem(Path.GetFileNameWithoutExtension(i)) { Tag = i };
                menu.Click += new EventHandler(recentFileToolStripMenuItem_Click);
                openFileToolStripSplitButton.DropDownItems.Add(menu);
                recentFileMenuItems.Add(menu);
            }
        }

        private void AddRecentFile(string path) {
            foreach (var item in recentFileMenuItems){
                openFileToolStripSplitButton.DropDownItems.Remove(item);
                item.Dispose();
            }
            recentFileMenuItems.Clear();
            var files = new[] {path}.Concat(GetRecentFiles().Where(s => s != path).Take(9));
            var sb = new StringBuilder();
            foreach (var i in files) {
                sb.AppendLine(i);
                var menu = new ToolStripMenuItem(Path.GetFileNameWithoutExtension(i)) { Tag = i };
                menu.Click += new EventHandler(recentFileToolStripMenuItem_Click);
                openFileToolStripSplitButton.DropDownItems.Add(menu);
                recentFileMenuItems.Add(menu);
            }
            ExcodeAuthor.Properties.Settings.Default.Recent = sb.ToString();
            ExcodeAuthor.Properties.Settings.Default.Save();
        }

        private void codeBox_SelectionChanged(object sender, EventArgs e) {
            cutToolStripButton.Enabled =
                copyToolStripButton.Enabled =
                cutToolStripMenuItem.Enabled =
                copyToolStripMenuItem.Enabled =
                deleteToolStripMenuItem.Enabled = codeBox.SelectionLength > 0;
        }

        private void newBlankWindowToolStripMenuItem_Click(object sender, EventArgs e) {
            if(File.Exists(Application.ExecutablePath))
                System.Diagnostics.Process.Start(Application.ExecutablePath);
            else
                MessageBox.Show("Failed to launch a new instance.  Make sure the execuable file has not moved or been renamed.");
        }

        private void newDuplicateWindowToolStripMenuItem_Click(object sender, EventArgs e) {
            string old = currentFileName;
            string temp = currentFileName = Path.GetTempFileName();
            SaveFile(false, false);
            currentFileName = old;
            if (File.Exists(Application.ExecutablePath))
                System.Diagnostics.Process.Start(Application.ExecutablePath, "-t " + temp);
            else
                MessageBox.Show("Failed to launch a new instance.  Make sure the execuable file has not moved or been renamed.");
        }


        private void variableBox_DoubleClick(object sender, EventArgs e) {
            if (variableBox.Text.StartsWith(": ")) {
                Regex regex = new Regex("^ *id;" + Regex.Escape(variableBox.Text.Substring(2)) + "$", RegexOptions.Multiline);
                Match match = regex.Match(codeBox.Text);
                if (!match.Success) return;
                codeBox.SelectionStart = match.Index;
                codeBox.SelectionLength = match.Length;
                codeBox.Focus();
            }
            else {
                codeBox.SelectedText = variableBox.Text;
                codeBox.SelectionStart += codeBox.SelectionLength;
                codeBox.SelectionLength = 0;
                codeBox.Focus();
            }
        }

        FindForm findForm;


        public string SearchString { get; set; }
        public bool SearchCaseSensitive { get; set; }
        public bool Find(bool silent) {
            findAgainToolStripMenuItem.Enabled = false;
            int pos = codeBox.Text.IndexOf(SearchString, codeBox.SelectionStart + (codeBox.SelectionLength > 0 ? 1 : 0), SearchCaseSensitive ? StringComparison.InvariantCulture : StringComparison.InvariantCultureIgnoreCase);
            if (pos == -1) pos = codeBox.Text.IndexOf(SearchString, 0, SearchCaseSensitive ? StringComparison.InvariantCulture : StringComparison.InvariantCultureIgnoreCase);
            if (pos == -1) {
                if(!silent) MessageBox.Show("The search string does not occur at all in the code.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            findAgainToolStripMenuItem.Enabled = true;
            codeBox.SelectionStart = pos;
            codeBox.SelectionLength = SearchString.Length;
            return true;
        }


        private bool Goto(int line) {
            Regex regex = new Regex("^(?:.*[^.]){" + (line - 1) + "}(.*)");
            Match match = regex.Match(codeBox.Text);
            if (!match.Success) return false;
            codeBox.SelectionStart = match.Groups[1].Index;
            codeBox.SelectionLength = match.Groups[1].Length;
            codeBox.Focus();
            return true;
        }

        private void errorBox_DoubleClick(object sender, EventArgs e) {
            Match match = lineNumRegex.Match(errorBox.Text);
            if (!match.Success) return;
            Goto(int.Parse(match.Groups[1].Value));
        }

        private void goToLineToolStripTextBox_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Return) {
                if (Goto(int.Parse(goToLineToolStripTextBox.Text)))
                    findToolStripSplitButton.HideDropDown();
            }
            else if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8) {
                e.Handled = true;
                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void goToLineToolStripTextBox_GotFocus(object sender, EventArgs e) {
            goToLineToolStripTextBox.Text = "";
        }

        private void goToLineToolStripTextBox_LostFocus(object sender, EventArgs e) {
            goToLineToolStripTextBox.Text = "Go To Line";
        }

        UpdateForm updateForm;
        private void updateToolStripButton_Click(object sender, EventArgs e) {
            updateForm.Show();
        }

        private void ExcodeForm_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush brush;
            if (updateForm.Checking) brush = new LinearGradientBrush(new Point(0, Height), new Point(0, Height / 2 - 1), Color.FromArgb(192, 255, 255, 0), Color.FromArgb(0, 255, 255, 0));
            else if (updateForm.UpToDate) brush = new LinearGradientBrush(new Point(0, Height), new Point(0, Height / 2 - 1), Color.FromArgb(192, 0, 255, 0), Color.FromArgb(0, 0, 255, 0));
            else brush = new LinearGradientBrush(new Point(0, Height), new Point(0, Height / 2 - 1), Color.FromArgb(192, 255, 0, 0), Color.FromArgb(0, 255, 0, 0));
            e.Graphics.FillRectangle(brush, new Rectangle(0, Height / 2, Width, Height / 2));
            brush.Dispose();
        }

        #region Toolbar

        private void clearCurrentWindowToolStripMenuItem_Click(object sender, EventArgs e) {
            codeBox.Text = "";
            isDirty = false;
            currentFileName = "Untitled";
            Text = "Excode Author - Untitled";
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e) {
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                OpenFile(openFileDialog.FileName);
            }
        }
        
        // Hooked up to dynamically generated ToolStripMenuItems.
        private void recentFileToolStripMenuItem_Click(object sender, EventArgs e) {
            var menu = sender as ToolStripMenuItem;
            if (menu != null) {
                OpenFile((string)menu.Tag);
            }
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveFile(false, true);
        }

        private void saveFileAsToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveFile(true, true);
        }

        private void saveCopyAsToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveFile(true, false);
        }

        private void ExcodeForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (CheckDirtyFile()) e.Cancel = true;
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e) {
            codeBox.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e) {
            codeBox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e) {
            codeBox.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
            codeBox.SelectedText = "";
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e) {
            codeBox.SelectionStart = 0;
            codeBox.SelectionLength = codeBox.Text.Length;
        }

        private void aboutToolStripButton_Click(object sender, EventArgs e) {
            using(AboutForm about = new AboutForm())
                about.ShowDialog(this);
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e) {
            if (findForm == null || findForm.IsDisposed) findForm = new FindForm(this);
            if (codeBox.SelectionLength > 0) {
                findForm.SearchBox.Text = codeBox.SelectedText;
            }
            findForm.SearchBox.SelectAll();
            findForm.SearchBox.Focus();
            if(!findForm.Visible) findForm.Show(this);
            
        }

        private void findAgainToolStripMenuItem_Click(object sender, EventArgs e) {
            Find(false);
        }



        #endregion
    }
}

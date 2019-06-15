using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ExcodeExt
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] param)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IEnumerable<string> p = param;
            bool untitled = false;
            if (param.Length > 0) {
                if (param[0] == "-t") {
                    p = param.Skip(1);
                    untitled = true;
                }
                Application.Run(new ExcodeForm(p.Aggregate((a, s) => a + s + " ").Trim(), untitled));
            }
            else Application.Run(new ExcodeForm("", true));
        }
    }
}

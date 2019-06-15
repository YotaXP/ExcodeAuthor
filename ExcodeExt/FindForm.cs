using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExcodeExt
{
    public partial class FindForm : Form
    {
        public FindForm(ExcodeForm parent) {
            InitializeComponent();
            this.parent = parent;
            caseSensitive.Checked = Properties.Settings.Default.FindCaseSensitive;
            stayOpen.Checked = Properties.Settings.Default.FindStayOpen;
        }

        private readonly ExcodeForm parent;

        public TextBox SearchBox { get { return searchBox; } }

        private void searchBox_TextChanged(object sender, EventArgs e) {
            findNext.Enabled = !string.IsNullOrEmpty(searchBox.Text);
            replace.Enabled = replaceAll.Enabled = findNext.Enabled && !string.IsNullOrEmpty(replaceBox.Text);
        }

        private void replaceBox_TextChanged(object sender, EventArgs e) {
            replace.Enabled = replaceAll.Enabled = findNext.Enabled  && !string.IsNullOrEmpty(replaceBox.Text);
        }

        private void close_Click(object sender, EventArgs e) {
            Close();
        }

        private void findNext_Click(object sender, EventArgs e) {
            parent.SearchString = searchBox.Text;
            parent.SearchCaseSensitive = caseSensitive.Checked;
            parent.Find(false);
            if (!stayOpen.Checked) Close();
        }

        private void caseSensitive_CheckedChanged(object sender, EventArgs e) {
            Properties.Settings.Default.FindCaseSensitive = caseSensitive.Checked;
            Properties.Settings.Default.Save();
        }

        private void stayOpen_CheckedChanged(object sender, EventArgs e) {
            Properties.Settings.Default.FindStayOpen = stayOpen.Checked;
            Properties.Settings.Default.Save();
        }

        private void replace_Click(object sender, EventArgs e) {
            if (parent.CodeBox.SelectedText == searchBox.Text) parent.CodeBox.SelectedText = replaceBox.Text;
            parent.SearchString = searchBox.Text;
            parent.SearchCaseSensitive = caseSensitive.Checked;
            parent.Find(false);
        }

        private void replaceAll_Click(object sender, EventArgs e) {
            parent.SearchString = searchBox.Text;
            parent.SearchCaseSensitive = caseSensitive.Checked;
            if (!parent.Find(false)) return;
            int count = 0;
            do {
                parent.CodeBox.SelectedText = replaceBox.Text;
                count++;
            }
            while (parent.Find(true));
            MessageBox.Show("Found and replaced " + count.ToString() + " occurance" + (count != 1 ? "s" : "") + " of the search string.", "Replaced All Occurances", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}

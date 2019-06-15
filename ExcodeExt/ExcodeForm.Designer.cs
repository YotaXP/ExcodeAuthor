namespace ExcodeExt
{
    partial class ExcodeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExcodeForm));
            this.copyRaw = new System.Windows.Forms.Button();
            this.copyClean = new System.Windows.Forms.Button();
            this.errorBox = new System.Windows.Forms.ListBox();
            this.variableBox = new System.Windows.Forms.ListBox();
            this.codeBox = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyScript = new System.Windows.Forms.Button();
            this.copyScriptLabel = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.newWindowToolStripSplitButton = new System.Windows.Forms.ToolStripSplitButton();
            this.newBlankWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDuplicateWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearCurrentWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripSplitButton = new System.Windows.Forms.ToolStripSplitButton();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileToolStripSplitButton = new System.Windows.Forms.ToolStripSplitButton();
            this.saveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCopyAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripSplitButton = new System.Windows.Forms.ToolStripSplitButton();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findAgainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToLineToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.cutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.aboutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.updateToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.copyScriptName = new System.Windows.Forms.ComboBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.codeGutter = new ExcodeExt.Gutter();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new System.Drawing.Size(161, 6);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(173, 6);
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new System.Drawing.Size(157, 6);
            // 
            // copyRaw
            // 
            this.copyRaw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.copyRaw.Location = new System.Drawing.Point(373, 28);
            this.copyRaw.Name = "copyRaw";
            this.copyRaw.Size = new System.Drawing.Size(99, 23);
            this.copyRaw.TabIndex = 1;
            this.copyRaw.Text = "Copy Raw";
            this.toolTip.SetToolTip(this.copyRaw, "Copies the contents of the code as is, to the clipboard.");
            this.copyRaw.UseVisualStyleBackColor = true;
            this.copyRaw.Click += new System.EventHandler(this.copyRaw_Click);
            // 
            // copyClean
            // 
            this.copyClean.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.copyClean.Location = new System.Drawing.Point(373, 57);
            this.copyClean.Name = "copyClean";
            this.copyClean.Size = new System.Drawing.Size(99, 23);
            this.copyClean.TabIndex = 2;
            this.copyClean.Text = "Copy Clean";
            this.toolTip.SetToolTip(this.copyClean, "Copies the contents of the code to the left, and strips out blank lines, comments" +
                    ", and leading spaces.");
            this.copyClean.UseVisualStyleBackColor = true;
            this.copyClean.Click += new System.EventHandler(this.copyClean_Click);
            // 
            // errorBox
            // 
            this.errorBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.errorBox.FormattingEnabled = true;
            this.errorBox.Location = new System.Drawing.Point(12, 396);
            this.errorBox.Name = "errorBox";
            this.errorBox.Size = new System.Drawing.Size(460, 56);
            this.errorBox.TabIndex = 4;
            this.errorBox.DoubleClick += new System.EventHandler(this.errorBox_DoubleClick);
            // 
            // variableBox
            // 
            this.variableBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.variableBox.FormattingEnabled = true;
            this.variableBox.IntegralHeight = false;
            this.variableBox.Location = new System.Drawing.Point(373, 177);
            this.variableBox.Name = "variableBox";
            this.variableBox.Size = new System.Drawing.Size(99, 213);
            this.variableBox.TabIndex = 5;
            this.variableBox.DoubleClick += new System.EventHandler(this.variableBox_DoubleClick);
            // 
            // codeBox
            // 
            this.codeBox.AcceptsTab = true;
            this.codeBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.codeBox.ContextMenuStrip = this.contextMenuStrip;
            this.codeBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeBox.HideSelection = false;
            this.codeBox.Location = new System.Drawing.Point(46, 28);
            this.codeBox.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.codeBox.Name = "codeBox";
            this.codeBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.codeBox.Size = new System.Drawing.Size(321, 362);
            this.codeBox.TabIndex = 7;
            this.codeBox.Text = "";
            this.codeBox.WordWrap = false;
            this.codeBox.SelectionChanged += new System.EventHandler(this.codeBox_SelectionChanged);
            this.codeBox.TextChanged += new System.EventHandler(this.codeBox_TextChanged);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem,
            toolStripSeparator3,
            this.selectAllToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(165, 120);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = global::ExcodeExt.Properties.Resources.cut16;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+X";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = global::ExcodeExt.Properties.Resources.copy16;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+C";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = global::ExcodeExt.Properties.Resources.paste16;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+V";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::ExcodeExt.Properties.Resources.trash16;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+A";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // copyScript
            // 
            this.copyScript.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.copyScript.Location = new System.Drawing.Point(373, 125);
            this.copyScript.Name = "copyScript";
            this.copyScript.Size = new System.Drawing.Size(99, 46);
            this.copyScript.TabIndex = 8;
            this.copyScript.Text = "Copy Script";
            this.toolTip.SetToolTip(this.copyScript, resources.GetString("copyScript.ToolTip"));
            this.copyScript.UseVisualStyleBackColor = true;
            this.copyScript.Click += new System.EventHandler(this.copyScript_Click);
            // 
            // copyScriptLabel
            // 
            this.copyScriptLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.copyScriptLabel.AutoSize = true;
            this.copyScriptLabel.Location = new System.Drawing.Point(373, 83);
            this.copyScriptLabel.Name = "copyScriptLabel";
            this.copyScriptLabel.Size = new System.Drawing.Size(77, 13);
            this.copyScriptLabel.TabIndex = 10;
            this.copyScriptLabel.Text = "Compile Script:";
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newWindowToolStripSplitButton,
            this.openFileToolStripSplitButton,
            this.saveFileToolStripSplitButton,
            this.findToolStripSplitButton,
            toolStripSeparator2,
            this.cutToolStripButton,
            this.copyToolStripButton,
            this.pasteToolStripButton,
            this.aboutToolStripButton,
            this.updateToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.toolStrip.Size = new System.Drawing.Size(484, 25);
            this.toolStrip.TabIndex = 11;
            this.toolStrip.Text = "toolstrip";
            // 
            // newWindowToolStripSplitButton
            // 
            this.newWindowToolStripSplitButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newBlankWindowToolStripMenuItem,
            this.newDuplicateWindowToolStripMenuItem,
            this.clearCurrentWindowToolStripMenuItem});
            this.newWindowToolStripSplitButton.Image = global::ExcodeExt.Properties.Resources.documents16;
            this.newWindowToolStripSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newWindowToolStripSplitButton.Name = "newWindowToolStripSplitButton";
            this.newWindowToolStripSplitButton.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.newWindowToolStripSplitButton.Size = new System.Drawing.Size(63, 22);
            this.newWindowToolStripSplitButton.Text = "New";
            this.newWindowToolStripSplitButton.ButtonClick += new System.EventHandler(this.newBlankWindowToolStripMenuItem_Click);
            // 
            // newBlankWindowToolStripMenuItem
            // 
            this.newBlankWindowToolStripMenuItem.Image = global::ExcodeExt.Properties.Resources.documents16;
            this.newBlankWindowToolStripMenuItem.Name = "newBlankWindowToolStripMenuItem";
            this.newBlankWindowToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newBlankWindowToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.newBlankWindowToolStripMenuItem.Text = "New Blank Window";
            this.newBlankWindowToolStripMenuItem.Click += new System.EventHandler(this.newBlankWindowToolStripMenuItem_Click);
            // 
            // newDuplicateWindowToolStripMenuItem
            // 
            this.newDuplicateWindowToolStripMenuItem.Image = global::ExcodeExt.Properties.Resources.copy16;
            this.newDuplicateWindowToolStripMenuItem.Name = "newDuplicateWindowToolStripMenuItem";
            this.newDuplicateWindowToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.N)));
            this.newDuplicateWindowToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.newDuplicateWindowToolStripMenuItem.Text = "New Duplicate Window";
            this.newDuplicateWindowToolStripMenuItem.Click += new System.EventHandler(this.newDuplicateWindowToolStripMenuItem_Click);
            // 
            // clearCurrentWindowToolStripMenuItem
            // 
            this.clearCurrentWindowToolStripMenuItem.Image = global::ExcodeExt.Properties.Resources.trash16;
            this.clearCurrentWindowToolStripMenuItem.Name = "clearCurrentWindowToolStripMenuItem";
            this.clearCurrentWindowToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.clearCurrentWindowToolStripMenuItem.Text = "Clear Current Window";
            this.clearCurrentWindowToolStripMenuItem.Click += new System.EventHandler(this.clearCurrentWindowToolStripMenuItem_Click);
            // 
            // openFileToolStripSplitButton
            // 
            this.openFileToolStripSplitButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            toolStripSeparator1});
            this.openFileToolStripSplitButton.Image = global::ExcodeExt.Properties.Resources.folderOpen16;
            this.openFileToolStripSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openFileToolStripSplitButton.Name = "openFileToolStripSplitButton";
            this.openFileToolStripSplitButton.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.openFileToolStripSplitButton.Size = new System.Drawing.Size(68, 22);
            this.openFileToolStripSplitButton.Text = "Open";
            this.openFileToolStripSplitButton.ButtonClick += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Image = global::ExcodeExt.Properties.Resources.folderOpen16;
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.openFileToolStripMenuItem.Text = "Open File...";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // saveFileToolStripSplitButton
            // 
            this.saveFileToolStripSplitButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveFileToolStripMenuItem,
            this.saveFileAsToolStripMenuItem,
            this.saveCopyAsToolStripMenuItem});
            this.saveFileToolStripSplitButton.Image = global::ExcodeExt.Properties.Resources.save16;
            this.saveFileToolStripSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveFileToolStripSplitButton.Name = "saveFileToolStripSplitButton";
            this.saveFileToolStripSplitButton.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.saveFileToolStripSplitButton.Size = new System.Drawing.Size(63, 22);
            this.saveFileToolStripSplitButton.Text = "Save";
            this.saveFileToolStripSplitButton.ButtonClick += new System.EventHandler(this.saveFileToolStripMenuItem_Click);
            // 
            // saveFileToolStripMenuItem
            // 
            this.saveFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveFileToolStripMenuItem.Image")));
            this.saveFileToolStripMenuItem.Name = "saveFileToolStripMenuItem";
            this.saveFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveFileToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.saveFileToolStripMenuItem.Text = "Save File";
            this.saveFileToolStripMenuItem.Click += new System.EventHandler(this.saveFileToolStripMenuItem_Click);
            // 
            // saveFileAsToolStripMenuItem
            // 
            this.saveFileAsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveFileAsToolStripMenuItem.Image")));
            this.saveFileAsToolStripMenuItem.Name = "saveFileAsToolStripMenuItem";
            this.saveFileAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.S)));
            this.saveFileAsToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.saveFileAsToolStripMenuItem.Text = "Save File As...";
            this.saveFileAsToolStripMenuItem.Click += new System.EventHandler(this.saveFileAsToolStripMenuItem_Click);
            // 
            // saveCopyAsToolStripMenuItem
            // 
            this.saveCopyAsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveCopyAsToolStripMenuItem.Image")));
            this.saveCopyAsToolStripMenuItem.Name = "saveCopyAsToolStripMenuItem";
            this.saveCopyAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                        | System.Windows.Forms.Keys.S)));
            this.saveCopyAsToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.saveCopyAsToolStripMenuItem.Text = "Save Copy As...";
            this.saveCopyAsToolStripMenuItem.Click += new System.EventHandler(this.saveCopyAsToolStripMenuItem_Click);
            // 
            // findToolStripSplitButton
            // 
            this.findToolStripSplitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.findToolStripSplitButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findToolStripMenuItem,
            this.findAgainToolStripMenuItem,
            toolStripSeparator4,
            this.goToLineToolStripTextBox});
            this.findToolStripSplitButton.Image = global::ExcodeExt.Properties.Resources.find;
            this.findToolStripSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.findToolStripSplitButton.Name = "findToolStripSplitButton";
            this.findToolStripSplitButton.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.findToolStripSplitButton.Size = new System.Drawing.Size(32, 22);
            this.findToolStripSplitButton.Text = "Find";
            this.findToolStripSplitButton.ButtonClick += new System.EventHandler(this.findToolStripMenuItem_Click);
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Image = global::ExcodeExt.Properties.Resources.find;
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.findToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.findToolStripMenuItem.Text = "Find...";
            this.findToolStripMenuItem.Click += new System.EventHandler(this.findToolStripMenuItem_Click);
            // 
            // findAgainToolStripMenuItem
            // 
            this.findAgainToolStripMenuItem.Enabled = false;
            this.findAgainToolStripMenuItem.Name = "findAgainToolStripMenuItem";
            this.findAgainToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.findAgainToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.findAgainToolStripMenuItem.Text = "Find Again";
            this.findAgainToolStripMenuItem.Click += new System.EventHandler(this.findAgainToolStripMenuItem_Click);
            // 
            // goToLineToolStripTextBox
            // 
            this.goToLineToolStripTextBox.AcceptsReturn = true;
            this.goToLineToolStripTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.goToLineToolStripTextBox.Name = "goToLineToolStripTextBox";
            this.goToLineToolStripTextBox.Size = new System.Drawing.Size(100, 23);
            this.goToLineToolStripTextBox.Text = "Go To Line";
            this.goToLineToolStripTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.goToLineToolStripTextBox_KeyPress);
            this.goToLineToolStripTextBox.LostFocus += new System.EventHandler(this.goToLineToolStripTextBox_LostFocus);
            this.goToLineToolStripTextBox.GotFocus += new System.EventHandler(this.goToLineToolStripTextBox_GotFocus);
            // 
            // cutToolStripButton
            // 
            this.cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cutToolStripButton.Image = global::ExcodeExt.Properties.Resources.cut16;
            this.cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripButton.Name = "cutToolStripButton";
            this.cutToolStripButton.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.cutToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.cutToolStripButton.Text = "Cut";
            this.cutToolStripButton.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripButton
            // 
            this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyToolStripButton.Image = global::ExcodeExt.Properties.Resources.copy16;
            this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripButton.Name = "copyToolStripButton";
            this.copyToolStripButton.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.copyToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.copyToolStripButton.Text = "Copy";
            this.copyToolStripButton.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripButton
            // 
            this.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteToolStripButton.Image = global::ExcodeExt.Properties.Resources.paste16;
            this.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripButton.Name = "pasteToolStripButton";
            this.pasteToolStripButton.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.pasteToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.pasteToolStripButton.Text = "Paste";
            this.pasteToolStripButton.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // aboutToolStripButton
            // 
            this.aboutToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.aboutToolStripButton.BackColor = System.Drawing.SystemColors.Control;
            this.aboutToolStripButton.Image = global::ExcodeExt.Properties.Resources.questionMark;
            this.aboutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.aboutToolStripButton.Name = "aboutToolStripButton";
            this.aboutToolStripButton.Size = new System.Drawing.Size(60, 22);
            this.aboutToolStripButton.Text = "About";
            this.aboutToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.aboutToolStripButton.Click += new System.EventHandler(this.aboutToolStripButton_Click);
            // 
            // updateToolStripButton
            // 
            this.updateToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.updateToolStripButton.Font = new System.Drawing.Font("Segoe UI", 6F);
            this.updateToolStripButton.ForeColor = System.Drawing.Color.Black;
            this.updateToolStripButton.Image = global::ExcodeExt.Properties.Resources.yellowButton;
            this.updateToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.updateToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.updateToolStripButton.Name = "updateToolStripButton";
            this.updateToolStripButton.Size = new System.Drawing.Size(104, 22);
            this.updateToolStripButton.Text = "Click to Update!";
            this.updateToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.updateToolStripButton.Click += new System.EventHandler(this.updateToolStripButton_Click);
            // 
            // copyScriptName
            // 
            this.copyScriptName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.copyScriptName.FormattingEnabled = true;
            this.copyScriptName.Items.AddRange(new object[] {
            "t",
            "test",
            "app",
            "packet1.scr",
            "packet-1.scr",
            "packet-2.scr",
            "packetdqry.scr",
            "hello.update"});
            this.copyScriptName.Location = new System.Drawing.Point(373, 98);
            this.copyScriptName.Name = "copyScriptName";
            this.copyScriptName.Size = new System.Drawing.Size(99, 21);
            this.copyScriptName.TabIndex = 12;
            this.copyScriptName.Text = "app";
            // 
            // openFileDialog
            // 
            this.openFileDialog.AddExtension = false;
            this.openFileDialog.FileName = "*.txt";
            this.openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            this.openFileDialog.InitialDirectory = "%USERPROFILE%";
            this.openFileDialog.Title = "Open Excode";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "*.txt";
            this.saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            this.saveFileDialog.InitialDirectory = "%USERPROFILE%";
            // 
            // codeGutter
            // 
            this.codeGutter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.codeGutter.BackColor = System.Drawing.Color.Transparent;
            this.codeGutter.Location = new System.Drawing.Point(0, 28);
            this.codeGutter.Margin = new System.Windows.Forms.Padding(0);
            this.codeGutter.Name = "codeGutter";
            this.codeGutter.Size = new System.Drawing.Size(46, 362);
            this.codeGutter.TabIndex = 6;
            this.codeGutter.Text = "gutter1";
            this.codeGutter.TextBox = this.codeBox;
            // 
            // ExcodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(484, 464);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.copyScriptName);
            this.Controls.Add(this.copyScript);
            this.Controls.Add(this.copyScriptLabel);
            this.Controls.Add(this.codeBox);
            this.Controls.Add(this.codeGutter);
            this.Controls.Add(this.variableBox);
            this.Controls.Add(this.errorBox);
            this.Controls.Add(this.copyClean);
            this.Controls.Add(this.copyRaw);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(400, 280);
            this.Name = "ExcodeForm";
            this.Text = "Excode Author - Untitled";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ExcodeForm_Paint);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExcodeForm_FormClosing);
            this.contextMenuStrip.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button copyRaw;
        private System.Windows.Forms.Button copyClean;
        private System.Windows.Forms.ListBox errorBox;
        private System.Windows.Forms.ListBox variableBox;
        private Gutter codeGutter;
        private System.Windows.Forms.RichTextBox codeBox;
        private System.Windows.Forms.Button copyScript;
        private System.Windows.Forms.Label copyScriptLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripSplitButton newWindowToolStripSplitButton;
        private System.Windows.Forms.ToolStripMenuItem newBlankWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newDuplicateWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton openFileToolStripSplitButton;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton saveFileToolStripSplitButton;
        private System.Windows.Forms.ToolStripMenuItem saveFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFileAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCopyAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton cutToolStripButton;
        private System.Windows.Forms.ToolStripButton copyToolStripButton;
        private System.Windows.Forms.ToolStripButton pasteToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem clearCurrentWindowToolStripMenuItem;
        private System.Windows.Forms.ComboBox copyScriptName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripButton aboutToolStripButton;
        private System.Windows.Forms.ToolStripSplitButton findToolStripSplitButton;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findAgainToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox goToLineToolStripTextBox;
        private System.Windows.Forms.ToolStripButton updateToolStripButton;
    }
}


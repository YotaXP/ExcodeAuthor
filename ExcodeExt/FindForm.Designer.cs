namespace ExcodeExt
{
    partial class FindForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
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
        private void InitializeComponent() {
            this.searchBox = new System.Windows.Forms.TextBox();
            this.replaceBox = new System.Windows.Forms.TextBox();
            this.searchLabel = new System.Windows.Forms.Label();
            this.replaceLabel = new System.Windows.Forms.Label();
            this.caseSensitive = new System.Windows.Forms.CheckBox();
            this.findNext = new System.Windows.Forms.Button();
            this.replace = new System.Windows.Forms.Button();
            this.replaceAll = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.stayOpen = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(90, 12);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(257, 20);
            this.searchBox.TabIndex = 0;
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            // 
            // replaceBox
            // 
            this.replaceBox.Location = new System.Drawing.Point(90, 39);
            this.replaceBox.Name = "replaceBox";
            this.replaceBox.Size = new System.Drawing.Size(257, 20);
            this.replaceBox.TabIndex = 1;
            this.replaceBox.TextChanged += new System.EventHandler(this.replaceBox_TextChanged);
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Location = new System.Drawing.Point(12, 15);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(59, 13);
            this.searchLabel.TabIndex = 2;
            this.searchLabel.Text = "Search for:";
            // 
            // replaceLabel
            // 
            this.replaceLabel.AutoSize = true;
            this.replaceLabel.Location = new System.Drawing.Point(12, 42);
            this.replaceLabel.Name = "replaceLabel";
            this.replaceLabel.Size = new System.Drawing.Size(72, 13);
            this.replaceLabel.TabIndex = 2;
            this.replaceLabel.Text = "Replace with:";
            // 
            // caseSensitive
            // 
            this.caseSensitive.AutoSize = true;
            this.caseSensitive.Location = new System.Drawing.Point(90, 68);
            this.caseSensitive.Name = "caseSensitive";
            this.caseSensitive.Size = new System.Drawing.Size(96, 17);
            this.caseSensitive.TabIndex = 3;
            this.caseSensitive.Text = "&Case Sensitive";
            this.caseSensitive.UseVisualStyleBackColor = true;
            this.caseSensitive.CheckedChanged += new System.EventHandler(this.caseSensitive_CheckedChanged);
            // 
            // findNext
            // 
            this.findNext.Enabled = false;
            this.findNext.Location = new System.Drawing.Point(353, 10);
            this.findNext.Name = "findNext";
            this.findNext.Size = new System.Drawing.Size(75, 23);
            this.findNext.TabIndex = 4;
            this.findNext.Text = "&Find Next";
            this.findNext.UseVisualStyleBackColor = true;
            this.findNext.Click += new System.EventHandler(this.findNext_Click);
            // 
            // replace
            // 
            this.replace.Enabled = false;
            this.replace.Location = new System.Drawing.Point(353, 37);
            this.replace.Name = "replace";
            this.replace.Size = new System.Drawing.Size(75, 23);
            this.replace.TabIndex = 4;
            this.replace.Text = "&Replace";
            this.replace.UseVisualStyleBackColor = true;
            this.replace.Click += new System.EventHandler(this.replace_Click);
            // 
            // replaceAll
            // 
            this.replaceAll.Enabled = false;
            this.replaceAll.Location = new System.Drawing.Point(353, 64);
            this.replaceAll.Name = "replaceAll";
            this.replaceAll.Size = new System.Drawing.Size(75, 23);
            this.replaceAll.TabIndex = 4;
            this.replaceAll.Text = "Replace &All";
            this.replaceAll.UseVisualStyleBackColor = true;
            this.replaceAll.Click += new System.EventHandler(this.replaceAll_Click);
            // 
            // close
            // 
            this.close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.close.Location = new System.Drawing.Point(272, 64);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 4;
            this.close.Text = "&Close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // stayOpen
            // 
            this.stayOpen.AutoSize = true;
            this.stayOpen.Location = new System.Drawing.Point(190, 68);
            this.stayOpen.Name = "stayOpen";
            this.stayOpen.Size = new System.Drawing.Size(76, 17);
            this.stayOpen.TabIndex = 5;
            this.stayOpen.Text = "Stay Open";
            this.stayOpen.UseVisualStyleBackColor = true;
            this.stayOpen.CheckedChanged += new System.EventHandler(this.stayOpen_CheckedChanged);
            // 
            // FindForm
            // 
            this.AcceptButton = this.findNext;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.close;
            this.ClientSize = new System.Drawing.Size(440, 99);
            this.Controls.Add(this.stayOpen);
            this.Controls.Add(this.close);
            this.Controls.Add(this.replaceAll);
            this.Controls.Add(this.replace);
            this.Controls.Add(this.findNext);
            this.Controls.Add(this.caseSensitive);
            this.Controls.Add(this.replaceLabel);
            this.Controls.Add(this.searchLabel);
            this.Controls.Add(this.replaceBox);
            this.Controls.Add(this.searchBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FindForm";
            this.ShowInTaskbar = false;
            this.Text = "Find";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.TextBox replaceBox;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.Label replaceLabel;
        private System.Windows.Forms.CheckBox caseSensitive;
        private System.Windows.Forms.Button findNext;
        private System.Windows.Forms.Button replace;
        private System.Windows.Forms.Button replaceAll;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.CheckBox stayOpen;
    }
}
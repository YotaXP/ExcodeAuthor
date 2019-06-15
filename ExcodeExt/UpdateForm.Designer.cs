namespace ExcodeExt
{
    partial class UpdateForm
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            this.progress = new System.Windows.Forms.ProgressBar();
            this.close = new System.Windows.Forms.Button();
            this.mainLabel = new System.Windows.Forms.Label();
            this.update = new System.Windows.Forms.Button();
            this.currentVersion = new System.Windows.Forms.Label();
            this.latestVersion = new System.Windows.Forms.Label();
            this.autoCheck = new System.Windows.Forms.CheckBox();
            this.autoInstall = new System.Windows.Forms.CheckBox();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Location = new System.Drawing.Point(17, 42);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(82, 13);
            label2.TabIndex = 3;
            label2.Text = "Current Version:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Location = new System.Drawing.Point(17, 55);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(77, 13);
            label3.TabIndex = 3;
            label3.Text = "Latest Version:";
            // 
            // progress
            // 
            this.progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progress.Location = new System.Drawing.Point(12, 75);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(336, 23);
            this.progress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progress.TabIndex = 0;
            // 
            // close
            // 
            this.close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.close.Location = new System.Drawing.Point(354, 75);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 1;
            this.close.Text = "&Close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // mainLabel
            // 
            this.mainLabel.AutoSize = true;
            this.mainLabel.BackColor = System.Drawing.Color.Transparent;
            this.mainLabel.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainLabel.Location = new System.Drawing.Point(12, 9);
            this.mainLabel.Name = "mainLabel";
            this.mainLabel.Size = new System.Drawing.Size(404, 29);
            this.mainLabel.TabIndex = 2;
            this.mainLabel.Text = "What the...?  You shouldn\'t see this.";
            // 
            // update
            // 
            this.update.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.update.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.update.Location = new System.Drawing.Point(354, 46);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(75, 23);
            this.update.TabIndex = 1;
            this.update.Text = "C&heck";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // currentVersion
            // 
            this.currentVersion.AutoSize = true;
            this.currentVersion.BackColor = System.Drawing.Color.Transparent;
            this.currentVersion.Location = new System.Drawing.Point(105, 42);
            this.currentVersion.Name = "currentVersion";
            this.currentVersion.Size = new System.Drawing.Size(53, 13);
            this.currentVersion.TabIndex = 3;
            this.currentVersion.Text = "Unknown";
            // 
            // latestVersion
            // 
            this.latestVersion.AutoSize = true;
            this.latestVersion.BackColor = System.Drawing.Color.Transparent;
            this.latestVersion.Location = new System.Drawing.Point(105, 55);
            this.latestVersion.Name = "latestVersion";
            this.latestVersion.Size = new System.Drawing.Size(53, 13);
            this.latestVersion.TabIndex = 3;
            this.latestVersion.Text = "Unknown";
            // 
            // autoCheck
            // 
            this.autoCheck.AutoSize = true;
            this.autoCheck.BackColor = System.Drawing.Color.Transparent;
            this.autoCheck.Location = new System.Drawing.Point(175, 41);
            this.autoCheck.Name = "autoCheck";
            this.autoCheck.Size = new System.Drawing.Size(180, 17);
            this.autoCheck.TabIndex = 4;
            this.autoCheck.Text = "Check for updates automatically.";
            this.autoCheck.UseVisualStyleBackColor = false;
            this.autoCheck.CheckedChanged += new System.EventHandler(this.autoCheck_CheckedChanged);
            // 
            // autoInstall
            // 
            this.autoInstall.AutoSize = true;
            this.autoInstall.BackColor = System.Drawing.Color.Transparent;
            this.autoInstall.Location = new System.Drawing.Point(175, 55);
            this.autoInstall.Name = "autoInstall";
            this.autoInstall.Size = new System.Drawing.Size(161, 17);
            this.autoInstall.TabIndex = 4;
            this.autoInstall.Text = "Install updates automatically.";
            this.autoInstall.UseVisualStyleBackColor = false;
            this.autoInstall.CheckedChanged += new System.EventHandler(this.autoInstall_CheckedChanged);
            // 
            // UpdateForm
            // 
            this.AcceptButton = this.update;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.close;
            this.ClientSize = new System.Drawing.Size(441, 110);
            this.Controls.Add(this.update);
            this.Controls.Add(this.close);
            this.Controls.Add(this.autoInstall);
            this.Controls.Add(this.autoCheck);
            this.Controls.Add(label3);
            this.Controls.Add(this.latestVersion);
            this.Controls.Add(this.currentVersion);
            this.Controls.Add(label2);
            this.Controls.Add(this.mainLabel);
            this.Controls.Add(this.progress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "UpdateForm";
            this.ShowInTaskbar = false;
            this.Text = "Update Excode Author";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UpdateForm_Paint);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UpdateForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Label mainLabel;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Label currentVersion;
        private System.Windows.Forms.Label latestVersion;
        private System.Windows.Forms.CheckBox autoCheck;
        private System.Windows.Forms.CheckBox autoInstall;

    }
}
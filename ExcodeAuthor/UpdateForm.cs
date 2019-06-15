using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Deployment.Application;

namespace ExcodeAuthor
{
    public partial class UpdateForm : Form
    {
        private static readonly bool DisableProgramaticUpdates = true;

        public UpdateForm(ToolStripButton button, ExcodeForm owner) {
            this.button = button;
            this.owner = owner;
            InitializeComponent();
            if (DisableProgramaticUpdates) {
                UpToDate = true;
                Checking = false;
                UpdateStatus();
                button.Visible = false;
                return;
            }
            autoCheck.Checked = Properties.Settings.Default.AutoCheckForUpdates;
            autoInstall.Checked = Properties.Settings.Default.AutoInstallUpdates;
            if (ApplicationDeployment.IsNetworkDeployed) {
                deployment = ApplicationDeployment.CurrentDeployment;
                deployment.CheckForUpdateCompleted += new CheckForUpdateCompletedEventHandler(CheckForUpdatesComplete);
                deployment.UpdateProgressChanged += new DeploymentProgressChangedEventHandler(ProgressChanged);
                deployment.UpdateCompleted += new AsyncCompletedEventHandler(UpdateComplete);
                currentVersion.Text = deployment.CurrentVersion.ToString();
                UpToDate = true;
                Checking = false;
                UpdateStatus();
                mainLabel.Text = "Click to Check to check for updates.";
                if (deployment.IsFirstRun) {
                    if (autoCheck.Checked && MessageBox.Show("Welcome to Excode Author v" + deployment.CurrentVersion.ToString() + "\n\nThis application is set to check for updates automatically.  Is this OK? (Nothing will install until you click the Update button, or enable auto-install.)", "Automatic Check for Updates", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        autoCheck.Checked = false;
                    if (autoCheck.Checked)
                        CheckForUpdates();
                }
            }
            else {
                button.Visible = false;
                UpToDate = true;
                Checking = false;
                UpdateStatus();
                mainLabel.Text = "This build is not updatable.";
            }
        }


        public bool Checking { get; set; }
        public bool UpToDate { get; set; }
        private ToolStripButton button;
        private ExcodeForm owner;
        ApplicationDeployment deployment;

        private void UpdateStatus() {
            if (Checking) button.Image = Properties.Resources.yellowButton;
            else if (UpToDate) button.Image = Properties.Resources.greenButton;
            else button.Image = Properties.Resources.redButton;
            Invalidate();
            owner.Invalidate(new Rectangle(0, owner.Height / 2, owner.Width, owner.Height / 2), false);
        }

        private void CheckForUpdates() {
            UpToDate = false;
            Checking = true;
            UpdateStatus();
            update.Enabled = false;
            AcceptButton = close;
            mainLabel.Text = "Checking for updates...";
            button.Text = "Checking for Updates";
            progress.Style = ProgressBarStyle.Marquee;
            deployment.CheckForUpdateAsync();
        }

        private void CheckForUpdatesComplete(object sender, CheckForUpdateCompletedEventArgs e) {
            progress.Style = ProgressBarStyle.Continuous;
            progress.Value = 0;
            if (e.Cancelled) {
                UpToDate = true;
                Checking = false;
                UpdateStatus();
                update.Enabled = true;
                AcceptButton = update;
                mainLabel.Text = "Check for updates cancelled.";
                button.Text = "Click to Update!";
                return;
            }
            if (e.Error != null) {
                UpToDate = true;
                Checking = false;
                UpdateStatus();
                update.Enabled = true;
                AcceptButton = update;
                mainLabel.Text = "Error: " + e.Error.Message;
                button.Text = "Error While Updating";
                return;
            }
            latestVersion.Text = e.AvailableVersion.ToString();
            if (e.UpdateAvailable) {
                if (autoInstall.Checked) UpdateNow();
                else {
                    UpToDate = false;
                    Checking = false;
                    UpdateStatus();
                    AcceptButton = update;
                    mainLabel.Text = "Ready for update!  Click Update Now.";
                    update.Enabled = true;
                    update.Text = "&Update Now";
                    button.Text = "Update Ready";
                }
            }
        }

        private void UpdateNow() {
            UpToDate = false;
            Checking = true;
            UpdateStatus();
            update.Enabled = false;
            AcceptButton = close;
            mainLabel.Text = "Installing update...";
            button.Text = "Installing Update";
            progress.Style = ProgressBarStyle.Marquee;
            deployment.UpdateAsync();
        }

        private void ProgressChanged(object sender, DeploymentProgressChangedEventArgs e) {
            progress.Style = ProgressBarStyle.Continuous;
            progress.Maximum = (int)e.BytesTotal;
            progress.Value = (int)e.BytesCompleted;
        }

        void UpdateComplete(object sender, AsyncCompletedEventArgs e) {
            progress.Style = ProgressBarStyle.Continuous;
            progress.Value = 0;
            if (e.Cancelled) {
                UpToDate = false;
                Checking = false;
                UpdateStatus();
                update.Enabled = true;
                AcceptButton = update;
                mainLabel.Text = "Update cancelled.";
                button.Text = "Update Found!";
                return;
            }
            if (e.Error != null) {
                UpToDate = false;
                Checking = false;
                UpdateStatus();
                update.Enabled = true;
                AcceptButton = update;
                mainLabel.Text = "Error: " + e.Error.Message;
                button.Text = "Error While Updating";
                return;
            }
            mainLabel.Text = "Updated!  Just restart the program.";
            UpToDate = false;
            Checking = false;
            UpdateStatus();
            button.Text = "Restart!";
            update.Text = "&Restart";
            update.Enabled = true;
            AcceptButton = update;
        }

        private void UpdateForm_Paint(object sender, PaintEventArgs e) {
            LinearGradientBrush brush;
            if (Checking) brush = new LinearGradientBrush(Point.Empty, new Point(300, 0), Color.FromArgb(192, 255, 255, 0), Color.FromArgb(0, 255, 255, 0));
            else if (UpToDate) brush = new LinearGradientBrush(Point.Empty, new Point(300, 0), Color.FromArgb(192, 0, 255, 0), Color.FromArgb(0, 0, 255, 0));
            else brush = new LinearGradientBrush(Point.Empty, new Point(300, 0), Color.FromArgb(128, 255, 0, 0), Color.FromArgb(0, 255, 0, 0));
            e.Graphics.FillRectangle(brush, new Rectangle(0, 0, 300, Height));
            brush.Dispose();
        }

        private void UpdateForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                Hide();
                e.Cancel = true;
            }
        }

        private void close_Click(object sender, EventArgs e) {
            Hide();
        }

        private void autoInstall_CheckedChanged(object sender, EventArgs e) {
            Properties.Settings.Default.AutoInstallUpdates = autoInstall.Checked;
            Properties.Settings.Default.Save();
        }

        private void autoCheck_CheckedChanged(object sender, EventArgs e) {
            Properties.Settings.Default.AutoCheckForUpdates = autoCheck.Checked;
            Properties.Settings.Default.Save();
        }

        private void update_Click(object sender, EventArgs e) {
            switch (update.Text) {
                case "C&heck":
                    CheckForUpdates();
                    return;
                case "&Update Now":
                    UpdateNow();
                    return;
                case "&Restart":
                    Hide();
                    Application.Restart();
                    return;
            }
        }
    }
}

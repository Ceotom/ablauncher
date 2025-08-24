namespace ablauncher
{
    partial class OnboardingForm
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
            if (disposing && (components != null))
            {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OnboardingForm));
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbText = new System.Windows.Forms.Label();
            this.chCheckForUpdates = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbLanguage = new System.Windows.Forms.ComboBox();
            this.bContinue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            resources.ApplyResources(this.lbTitle, "lbTitle");
            this.lbTitle.Name = "lbTitle";
            // 
            // lbText
            // 
            resources.ApplyResources(this.lbText, "lbText");
            this.lbText.Name = "lbText";
            // 
            // chCheckForUpdates
            // 
            resources.ApplyResources(this.chCheckForUpdates, "chCheckForUpdates");
            this.chCheckForUpdates.Checked = true;
            this.chCheckForUpdates.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chCheckForUpdates.Name = "chCheckForUpdates";
            this.chCheckForUpdates.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // cbLanguage
            // 
            resources.ApplyResources(this.cbLanguage, "cbLanguage");
            this.cbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLanguage.Items.AddRange(new object[] {
            resources.GetString("cbLanguage.Items"),
            resources.GetString("cbLanguage.Items1"),
            resources.GetString("cbLanguage.Items2")});
            this.cbLanguage.Name = "cbLanguage";
            this.cbLanguage.SelectedIndexChanged += new System.EventHandler(this.cbLanguage_SelectedIndexChanged);
            // 
            // bContinue
            // 
            resources.ApplyResources(this.bContinue, "bContinue");
            this.bContinue.Name = "bContinue";
            this.bContinue.UseVisualStyleBackColor = true;
            this.bContinue.Click += new System.EventHandler(this.bContinue_Click);
            // 
            // OnboardingForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bContinue);
            this.Controls.Add(this.chCheckForUpdates);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbLanguage);
            this.Controls.Add(this.lbText);
            this.Controls.Add(this.lbTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OnboardingForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnboardingForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbText;
        private System.Windows.Forms.CheckBox chCheckForUpdates;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbLanguage;
        private System.Windows.Forms.Button bContinue;
    }
}
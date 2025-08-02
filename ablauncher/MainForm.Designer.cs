namespace ablauncher {
    partial class MainForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.txNodeName = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.previewBox = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chRandomStart = new System.Windows.Forms.CheckBox();
            this.cbConveyorSpeed = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbPlaytime = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbEnclosure = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbMap = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rdTeamGame = new System.Windows.Forms.RadioButton();
            this.rdMeleeGame = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chAutoKeys = new System.Windows.Forms.CheckBox();
            this.tpKeys1 = new System.Windows.Forms.GroupBox();
            this.tpKeys0 = new System.Windows.Forms.GroupBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.label9 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbVersion = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btStart = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txNodeName
            // 
            resources.ApplyResources(this.txNodeName, "txNodeName");
            this.txNodeName.Name = "txNodeName";
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.previewBox);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // previewBox
            // 
            resources.ApplyResources(this.previewBox, "previewBox");
            this.previewBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewBox.Name = "previewBox";
            this.previewBox.TabStop = false;
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.chRandomStart);
            this.groupBox1.Controls.Add(this.cbConveyorSpeed);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cbPlaytime);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbEnclosure);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbMap);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.rdTeamGame);
            this.groupBox1.Controls.Add(this.rdMeleeGame);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // chRandomStart
            // 
            resources.ApplyResources(this.chRandomStart, "chRandomStart");
            this.chRandomStart.Name = "chRandomStart";
            this.chRandomStart.UseVisualStyleBackColor = true;
            this.chRandomStart.CheckedChanged += new System.EventHandler(this.chRandomStart_CheckedChanged);
            // 
            // cbConveyorSpeed
            // 
            resources.ApplyResources(this.cbConveyorSpeed, "cbConveyorSpeed");
            this.cbConveyorSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConveyorSpeed.FormattingEnabled = true;
            this.cbConveyorSpeed.Items.AddRange(new object[] {
            resources.GetString("cbConveyorSpeed.Items"),
            resources.GetString("cbConveyorSpeed.Items1"),
            resources.GetString("cbConveyorSpeed.Items2")});
            this.cbConveyorSpeed.Name = "cbConveyorSpeed";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // cbPlaytime
            // 
            resources.ApplyResources(this.cbPlaytime, "cbPlaytime");
            this.cbPlaytime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlaytime.FormattingEnabled = true;
            this.cbPlaytime.Items.AddRange(new object[] {
            resources.GetString("cbPlaytime.Items"),
            resources.GetString("cbPlaytime.Items1"),
            resources.GetString("cbPlaytime.Items2"),
            resources.GetString("cbPlaytime.Items3"),
            resources.GetString("cbPlaytime.Items4"),
            resources.GetString("cbPlaytime.Items5"),
            resources.GetString("cbPlaytime.Items6"),
            resources.GetString("cbPlaytime.Items7"),
            resources.GetString("cbPlaytime.Items8")});
            this.cbPlaytime.Name = "cbPlaytime";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // cbEnclosure
            // 
            resources.ApplyResources(this.cbEnclosure, "cbEnclosure");
            this.cbEnclosure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEnclosure.FormattingEnabled = true;
            this.cbEnclosure.Items.AddRange(new object[] {
            resources.GetString("cbEnclosure.Items"),
            resources.GetString("cbEnclosure.Items1"),
            resources.GetString("cbEnclosure.Items2"),
            resources.GetString("cbEnclosure.Items3")});
            this.cbEnclosure.Name = "cbEnclosure";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // cbMap
            // 
            resources.ApplyResources(this.cbMap, "cbMap");
            this.cbMap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMap.FormattingEnabled = true;
            this.cbMap.Name = "cbMap";
            this.cbMap.SelectedIndexChanged += new System.EventHandler(this.cbMap_SelectedIndexChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // rdTeamGame
            // 
            resources.ApplyResources(this.rdTeamGame, "rdTeamGame");
            this.rdTeamGame.Name = "rdTeamGame";
            this.rdTeamGame.UseVisualStyleBackColor = true;
            // 
            // rdMeleeGame
            // 
            resources.ApplyResources(this.rdMeleeGame, "rdMeleeGame");
            this.rdMeleeGame.Checked = true;
            this.rdMeleeGame.Name = "rdMeleeGame";
            this.rdMeleeGame.TabStop = true;
            this.rdMeleeGame.UseVisualStyleBackColor = true;
            this.rdMeleeGame.CheckedChanged += new System.EventHandler(this.rdMeleeGame_CheckedChanged);
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Controls.Add(this.chAutoKeys);
            this.tabPage2.Controls.Add(this.tpKeys1);
            this.tabPage2.Controls.Add(this.tpKeys0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chAutoKeys
            // 
            resources.ApplyResources(this.chAutoKeys, "chAutoKeys");
            this.chAutoKeys.Name = "chAutoKeys";
            this.chAutoKeys.UseVisualStyleBackColor = true;
            this.chAutoKeys.CheckedChanged += new System.EventHandler(this.chAutoKeys1_CheckedChanged);
            // 
            // tpKeys1
            // 
            resources.ApplyResources(this.tpKeys1, "tpKeys1");
            this.tpKeys1.Name = "tpKeys1";
            this.tpKeys1.TabStop = false;
            // 
            // tpKeys0
            // 
            resources.ApplyResources(this.tpKeys0, "tpKeys0");
            this.tpKeys0.Name = "tpKeys0";
            this.tpKeys0.TabStop = false;
            // 
            // tabPage3
            // 
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Controls.Add(this.linkLabel2);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.linkLabel1);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.lbVersion);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.pictureBox2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // linkLabel2
            // 
            resources.ApplyResources(this.linkLabel2, "linkLabel2");
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.TabStop = true;
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // linkLabel1
            // 
            resources.ApplyResources(this.linkLabel1, "linkLabel1");
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.TabStop = true;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // lbVersion
            // 
            resources.ApplyResources(this.lbVersion, "lbVersion");
            this.lbVersion.Name = "lbVersion";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // pictureBox2
            // 
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Image = global::ablauncher.Properties.Resources.POWKICK;
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // btStart
            // 
            resources.ApplyResources(this.btStart, "btStart");
            this.btStart.Name = "btStart";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // tabPage4
            // 
            resources.ApplyResources(this.tabPage4, "tabPage4");
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txNodeName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txNodeName;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdTeamGame;
        private System.Windows.Forms.RadioButton rdMeleeGame;
        private System.Windows.Forms.ComboBox cbMap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox previewBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbEnclosure;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbPlaytime;
        private System.Windows.Forms.ComboBox cbConveyorSpeed;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox tpKeys1;
        private System.Windows.Forms.GroupBox tpKeys0;
        private System.Windows.Forms.CheckBox chAutoKeys;
        private System.Windows.Forms.CheckBox chRandomStart;
        private System.Windows.Forms.TabPage tabPage4;
    }
}


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
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.spKeys0 = new System.Windows.Forms.GroupBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tpKeys1 = new System.Windows.Forms.GroupBox();
            this.tpKeys0 = new System.Windows.Forms.GroupBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.label9 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbVersion = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btStart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbPlayers = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chAutoKeys1 = new System.Windows.Forms.CheckBox();
            this.chAutoKeys2 = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(155, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Node &name";
            // 
            // txNodeName
            // 
            this.txNodeName.Location = new System.Drawing.Point(223, 12);
            this.txNodeName.Name = "txNodeName";
            this.txNodeName.Size = new System.Drawing.Size(128, 21);
            this.txNodeName.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(139, 42);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(512, 225);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(504, 199);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Host game";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.previewBox);
            this.groupBox2.Location = new System.Drawing.Point(315, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(172, 141);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Map preview";
            // 
            // previewBox
            // 
            this.previewBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewBox.Location = new System.Drawing.Point(10, 18);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(150, 110);
            this.previewBox.TabIndex = 0;
            this.previewBox.TabStop = false;
            // 
            // groupBox1
            // 
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
            this.groupBox1.Location = new System.Drawing.Point(15, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 170);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Game";
            // 
            // cbConveyorSpeed
            // 
            this.cbConveyorSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConveyorSpeed.FormattingEnabled = true;
            this.cbConveyorSpeed.Items.AddRange(new object[] {
            "Low",
            "Medium",
            "High"});
            this.cbConveyorSpeed.Location = new System.Drawing.Point(121, 135);
            this.cbConveyorSpeed.Name = "cbConveyorSpeed";
            this.cbConveyorSpeed.Size = new System.Drawing.Size(74, 21);
            this.cbConveyorSpeed.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 138);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Conveyor belt speed";
            // 
            // cbPlaytime
            // 
            this.cbPlaytime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlaytime.FormattingEnabled = true;
            this.cbPlaytime.Items.AddRange(new object[] {
            "1:00",
            "1:30",
            "2:00",
            "2:30",
            "3:00",
            "4:00",
            "5:00",
            "10:00",
            "Infinite"});
            this.cbPlaytime.Location = new System.Drawing.Point(121, 81);
            this.cbPlaytime.Name = "cbPlaytime";
            this.cbPlaytime.Size = new System.Drawing.Size(69, 21);
            this.cbPlaytime.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(65, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Play time";
            // 
            // cbEnclosure
            // 
            this.cbEnclosure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEnclosure.FormattingEnabled = true;
            this.cbEnclosure.Items.AddRange(new object[] {
            "None",
            "A little",
            "A lot",
            "All the way!"});
            this.cbEnclosure.Location = new System.Drawing.Point(121, 108);
            this.cbEnclosure.Name = "cbEnclosure";
            this.cbEnclosure.Size = new System.Drawing.Size(121, 21);
            this.cbEnclosure.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Enclosure depth";
            // 
            // cbMap
            // 
            this.cbMap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMap.FormattingEnabled = true;
            this.cbMap.Location = new System.Drawing.Point(48, 44);
            this.cbMap.Name = "cbMap";
            this.cbMap.Size = new System.Drawing.Size(219, 21);
            this.cbMap.TabIndex = 4;
            this.cbMap.SelectedIndexChanged += new System.EventHandler(this.cbMap_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Map";
            // 
            // rdTeamGame
            // 
            this.rdTeamGame.AutoSize = true;
            this.rdTeamGame.Location = new System.Drawing.Point(139, 19);
            this.rdTeamGame.Name = "rdTeamGame";
            this.rdTeamGame.Size = new System.Drawing.Size(51, 17);
            this.rdTeamGame.TabIndex = 1;
            this.rdTeamGame.Text = "Team";
            this.rdTeamGame.UseVisualStyleBackColor = true;
            // 
            // rdMeleeGame
            // 
            this.rdMeleeGame.AutoSize = true;
            this.rdMeleeGame.Checked = true;
            this.rdMeleeGame.Location = new System.Drawing.Point(50, 19);
            this.rdMeleeGame.Name = "rdMeleeGame";
            this.rdMeleeGame.Size = new System.Drawing.Size(77, 17);
            this.rdMeleeGame.TabIndex = 0;
            this.rdMeleeGame.TabStop = true;
            this.rdMeleeGame.Text = "Free for all";
            this.rdMeleeGame.UseVisualStyleBackColor = true;
            this.rdMeleeGame.CheckedChanged += new System.EventHandler(this.rdMeleeGame_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(504, 199);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Join game";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.Location = new System.Drawing.Point(140, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 30);
            this.label3.TabIndex = 0;
            this.label3.Text = "To join a game, launch the game and select \"Join network game\" from the main menu" +
                ".";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chAutoKeys1);
            this.tabPage3.Controls.Add(this.spKeys0);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(504, 199);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "1-player keys";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // spKeys0
            // 
            this.spKeys0.Location = new System.Drawing.Point(140, 15);
            this.spKeys0.Name = "spKeys0";
            this.spKeys0.Size = new System.Drawing.Size(205, 149);
            this.spKeys0.TabIndex = 0;
            this.spKeys0.TabStop = false;
            this.spKeys0.Text = "KEY 0";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.chAutoKeys2);
            this.tabPage4.Controls.Add(this.tpKeys1);
            this.tabPage4.Controls.Add(this.tpKeys0);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(504, 199);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "2-player keys";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tpKeys1
            // 
            this.tpKeys1.Location = new System.Drawing.Point(268, 15);
            this.tpKeys1.Name = "tpKeys1";
            this.tpKeys1.Size = new System.Drawing.Size(205, 149);
            this.tpKeys1.TabIndex = 2;
            this.tpKeys1.TabStop = false;
            this.tpKeys1.Text = "KEY 1";
            // 
            // tpKeys0
            // 
            this.tpKeys0.Location = new System.Drawing.Point(27, 15);
            this.tpKeys0.Name = "tpKeys0";
            this.tpKeys0.Size = new System.Drawing.Size(205, 149);
            this.tpKeys0.TabIndex = 1;
            this.tpKeys0.TabStop = false;
            this.tpKeys0.Text = "KEY 0";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.linkLabel2);
            this.tabPage5.Controls.Add(this.label9);
            this.tabPage5.Controls.Add(this.linkLabel1);
            this.tabPage5.Controls.Add(this.label10);
            this.tabPage5.Controls.Add(this.label8);
            this.tabPage5.Controls.Add(this.lbVersion);
            this.tabPage5.Controls.Add(this.label7);
            this.tabPage5.Controls.Add(this.pictureBox2);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(504, 199);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "About";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(12, 172);
            this.linkLabel2.Margin = new System.Windows.Forms.Padding(3);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(238, 13);
            this.linkLabel2.TabIndex = 12;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "http://ablauncher.sourceforge.net/settings.php";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 156);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(412, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Click here for a comprehensive list of settings Atomic Bomberman Launcher changes" +
                ":";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(12, 121);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(3);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(178, 13);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://ablauncher.sourceforge.net/";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(313, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Be sure to visit the website for news, suggestions and updates:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(416, 26);
            this.label8.TabIndex = 3;
            this.label8.Text = "Atomic Bomberman Launcher quickly configures your bomberman game settings for a \r" +
                "\nfun network game! Atomic Bomberman Launcher is free and released under the GPL." +
                "";
            // 
            // lbVersion
            // 
            this.lbVersion.AutoSize = true;
            this.lbVersion.Location = new System.Drawing.Point(77, 37);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(29, 13);
            this.lbVersion.TabIndex = 2;
            this.lbVersion.Text = "v9.9";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(76, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(291, 23);
            this.label7.TabIndex = 1;
            this.label7.Text = "Atomic Bomberman Launcher";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ablauncher.Properties.Resources.POWKICK;
            this.pictureBox2.Location = new System.Drawing.Point(15, 14);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 36);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // btStart
            // 
            this.btStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btStart.Location = new System.Drawing.Point(549, 273);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(100, 23);
            this.btStart.TabIndex = 6;
            this.btStart.Text = "&Launch game!";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(384, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "&Players";
            // 
            // cbPlayers
            // 
            this.cbPlayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlayers.FormattingEnabled = true;
            this.cbPlayers.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cbPlayers.Location = new System.Drawing.Point(431, 12);
            this.cbPlayers.Name = "cbPlayers";
            this.cbPlayers.Size = new System.Drawing.Size(39, 21);
            this.cbPlayers.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::ablauncher.Properties.Resources.bomberman;
            this.pictureBox1.Location = new System.Drawing.Point(4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(129, 295);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // chAutoKeys1
            // 
            this.chAutoKeys1.AutoSize = true;
            this.chAutoKeys1.Location = new System.Drawing.Point(141, 170);
            this.chAutoKeys1.Name = "chAutoKeys1";
            this.chAutoKeys1.Size = new System.Drawing.Size(204, 17);
            this.chAutoKeys1.TabIndex = 1;
            this.chAutoKeys1.Text = "Automatically assign keyboard player";
            this.chAutoKeys1.UseVisualStyleBackColor = true;
            this.chAutoKeys1.CheckedChanged += new System.EventHandler(this.chAutoKeys1_CheckedChanged);
            // 
            // chAutoKeys2
            // 
            this.chAutoKeys2.AutoSize = true;
            this.chAutoKeys2.Location = new System.Drawing.Point(141, 170);
            this.chAutoKeys2.Name = "chAutoKeys2";
            this.chAutoKeys2.Size = new System.Drawing.Size(204, 17);
            this.chAutoKeys2.TabIndex = 3;
            this.chAutoKeys2.Text = "Automatically assign keyboard player";
            this.chAutoKeys2.UseVisualStyleBackColor = true;
            this.chAutoKeys2.CheckedChanged += new System.EventHandler(this.chAutoKeys1_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 303);
            this.Controls.Add(this.cbPlayers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txNodeName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atomic Bomberman Launcher";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txNodeName;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbPlayers;
        private System.Windows.Forms.Label label3;
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
        private System.Windows.Forms.TabPage tabPage5;
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
        private System.Windows.Forms.GroupBox spKeys0;
        private System.Windows.Forms.GroupBox tpKeys1;
        private System.Windows.Forms.GroupBox tpKeys0;
        private System.Windows.Forms.CheckBox chAutoKeys1;
        private System.Windows.Forms.CheckBox chAutoKeys2;
    }
}


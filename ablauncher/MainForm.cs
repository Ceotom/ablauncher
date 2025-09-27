using ablauncher.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ablauncher {
    public partial class MainForm : Form {
        private AtomicBomberman game;
        private bool escapeNoClose = false;

        public static bool settingsIsLoading = true;

        private KeyBindControls keysP0;
        private KeyBindControls keysP1;

        public MainForm(AtomicBomberman game) {
            InitializeComponent();

            this.game = game;


            keysP0 = createKeyPad(tpKeys0);
            keysP1 = createKeyPad(tpKeys1);

            btRunIpxconfig.Enabled = game.checkTool("ipxconfig.exe");
            btRunCncDrawConfig.Enabled = game.checkTool("cnc-ddraw config.exe");
            btRunIntro.Enabled = game.checkTool("INTRO\\BMINTRO.EXE");
            btRunIntro.Visible = game.checkTool("INTRO\\BMINTRO.EXE");
            if (game.checkTool("ipxwrapper.dll")) chUsePublicIPXServer.Enabled = true;
            else game.UsePublicIPXServer = false;

            chUsePublicIPXServer.Enabled = Program.allowNetworking;
            chCheckForUpdates.Enabled = Program.allowNetworking;
            btCheckForUpdates.Enabled = Program.allowNetworking;

            chUseNewBombs.Visible = Program.isTne;
            chUseNewBombs.Enabled = Program.isTne;
            chUseAnimatedPower.Visible = Program.isTne;
            chUseAnimatedPower.Enabled = Program.isTne;
            clbRandomStages.Visible = Program.isTne;
            clbRandomStages.Enabled = Program.isTne;
            label9.Visible = Program.isTne;
        }

        private void MainForm_Load(object sender, EventArgs e) {
            lbVersion.Text = "v" + Program.Version;
            if (Program.isTne) lbVersion.Text = lbVersion.Text + " TNE";
            loadSettings();
            drawMapPreview();

        }

        /**
         * Creates a keypad layout in the given parent container
         */
        private KeyBindControls createKeyPad(GroupBox parent) {
            int groupX = 60;
            int w = 50;

            KeyBindControls ctrl = new KeyBindControls();
            ctrl.up = addKeyBox(parent, groupX - w / 2, 37, w);
            ctrl.left = addKeyBox(parent, groupX - w - 1, 64, w);
            ctrl.right = addKeyBox(parent, groupX + 1, 64, w);
            ctrl.down = addKeyBox(parent, groupX - w / 2, 91, w);
            addLabel(parent, groupX - 50, 115, 103, ContentAlignment.TopCenter, Localization.getLocalizedString("Controls_Move"));

            int actionOfs = 100;

            addLabel(parent, actionOfs + 5, 40, 50, ContentAlignment.TopRight, Localization.getLocalizedString("Controls_Bomb"));
            ctrl.action1 = addKeyBox(parent, actionOfs + 70, 37, w);
            addLabel(parent, actionOfs, 94, 60, ContentAlignment.TopRight, Localization.getLocalizedString("Controls_Special"));
            ctrl.action2 = addKeyBox(parent, actionOfs + 70, 91, w);

            return ctrl;
        }

        private TextBox addKeyBox(GroupBox parent, int x, int y, int width) {
            TextBox b = new TextBox();
            parent.Controls.Add(b);
            
            b.Width = width;
            b.Left = x;
            b.Top = y;
            b.TextAlign = HorizontalAlignment.Center;
            b.Tag = new KeyBindControlState();
            b.KeyPress += new KeyPressEventHandler(keyBoxKeyPress);
            b.KeyDown += new KeyEventHandler(keyBoxKeyDown);
            b.Leave += new EventHandler(keyBoxLeave);
            b.Click += new EventHandler(keyBoxClick);

            return b;
        }

        void keyBoxClick(object sender, EventArgs e) {
            // Click is immediate capture begin
            beginCapture((TextBox)sender);
        }

        void keyBoxLeave(object sender, EventArgs e) {
            // Leave is immediate capture cancel
            endCapture((TextBox)sender, Keys.None);
        }

        private void beginCapture(TextBox keyBox) {
            KeyBindControlState state = (KeyBindControlState)keyBox.Tag;
            keyBox.BackColor = Color.Yellow;
            state.capturing = true;
            escapeNoClose = true;
        }

        private void endCapture(TextBox keyBox, Keys key) {
            KeyBindControlState state = (KeyBindControlState)keyBox.Tag;
            if (!state.capturing) return;

            state.capturing = false;
            escapeNoClose = false;
            if (key != Keys.None) state.key = key;
            keyBox.BackColor = SystemColors.Window;
            KeyBindControls.updateBox(keyBox);
            // Update box contents
        }

        private void keyBoxKeyPress(object sender, KeyPressEventArgs e) {
            // Disable regular keypresses
            e.Handled = true;
        }

        internal static bool keyDown(Keys key) {
            short k = User32.GetAsyncKeyState((int)key);
            return (k & 0x8000) != 0;
        }

        private void keyBoxKeyDown(object sender, KeyEventArgs e) {
            TextBox box               = (TextBox)sender;
            KeyBindControlState state = (KeyBindControlState)box.Tag;

            // When focused, space starts capturing
            if (!state.capturing && e.KeyCode == Keys.Space) {
                beginCapture(box);
                return;
            }

            // When capturing, escape ends capturing
            if (state.capturing && e.KeyCode == Keys.Escape) {
                endCapture(box, Keys.None);
                return;
            }

            // Otherwise, normal capture end
            if (state.capturing) {
                // First, do some checking for keys that the .NET events don't handle well correctly
                
                if (keyDown(Keys.LControlKey)) endCapture(box, Keys.LControlKey);
                else if (keyDown(Keys.RControlKey)) endCapture(box, Keys.RControlKey);
                else if (keyDown(Keys.LShiftKey)) endCapture(box, Keys.LShiftKey);
                else if (keyDown(Keys.RShiftKey)) endCapture(box, Keys.RShiftKey);
                else if (keyDown(Keys.LMenu)) endCapture(box, Keys.LMenu);
                else if (keyDown(Keys.RMenu)) endCapture(box, Keys.RMenu);
                else endCapture(box, e.KeyCode);
            }
        }

        private Label addLabel(GroupBox parent, int x, int y, int w, ContentAlignment align, string text) {
            Label l = new Label();
            parent.Controls.Add(l);

            l.Left = x;
            l.Top = y;
            l.Text = text;
            l.TextAlign = align;
            l.Width = w;

            return l;
        }

        private void loadSettings() {
            settingsIsLoading = true;
            txNodeName.Text = game.NodeName;
            cbEnclosure.SelectedIndex = (int)game.EnclosureDepth;
            cbConveyorSpeed.SelectedIndex = (int)game.ConveyorBeltSpeed;
            chAutoKeys.Checked = game.AutoAssign;
            chRandomStart.Checked = game.RandomStart;
            cbLanguage.SelectedIndex = game.Language;
            chShowAllSchemes.Checked = game.ShowAllSchemes;
            chStompedBombsDetonate.Checked = game.StompedBombsDetonate;
            chWinByKills.Checked = game.WinByKills;
            chGoldMan.Checked = game.GoldMan;
            chLostNetRevertAi.Checked = game.LostNetRevertAi;
            chDiseasesDestroyable.Checked = game.DiseasesDestroyable;
            chCheckForUpdates.Checked = game.CheckForUpdates;
            chUsePublicIPXServer.Checked = game.UsePublicIPXServer;

            if (Program.isTne)
            {
                clbRandomStages.Items.Clear();
                chUseNewBombs.Checked = game.masterAliGet(TNEmanifest.TNEmanifestRoot.useNewBombsTrue, TNEmanifest.TNEmanifestRoot.useNewBombsFalse, "useNewBombs");
                chUseAnimatedPower.Checked = game.masterAliGet(TNEmanifest.TNEmanifestRoot.useAnimatedPowerTrue, TNEmanifest.TNEmanifestRoot.useAnimatedPowerFalse, "useAnimatedPower");
                foreach (var stage in TNEmanifest.TNEmanifestRoot.stages)
                {
                    CultureInfo culture = Thread.CurrentThread.CurrentUICulture;
                    if (culture.TwoLetterISOLanguageName == "ru") clbRandomStages.Items.Add(stage.nameRU);
                    else clbRandomStages.Items.Add(stage.name);
                    int listItem = stage.value - 1150;
                    clbRandomStages.SetItemChecked(listItem, game.getValue(stage.value));
                }
            }

            // Find playtime
            int playTime = game.PlayTime;
            cbPlaytime.SelectedIndex = 0;
            for (int i = 0; i < cbPlaytime.Items.Count; i++) {
                if (playTime <= textToSeconds(cbPlaytime.Items[i].ToString())) {
                    cbPlaytime.SelectedIndex = i;
                    break;
                }
            }

            // Find map file
            if (!chShowAllSchemes.Checked)
            {
                string currentScheme = game.SchemeFile;
                int index = findMap(currentScheme, GameType.freeForAll);
                if (index != -1) rdMeleeGame.Checked = true;
                else
                {
                    index = findMap(currentScheme, GameType.team);
                    if (index != -1) rdTeamGame.Checked = true;
                    else index = 0;
                }
                fillMapList();
                cbMap.SelectedIndex = index;
            }
            else
            {
                if (game.TeamMode) rdTeamGame.Checked = true;
                else rdMeleeGame.Checked = true;
                string currentScheme = game.SchemeFile;
                int index = findMap(currentScheme);
                if (index == -1) index = 0;
                fillMapList();
                cbMap.SelectedIndex = index;
            }

            // Load keys
            keysP0.Keys = game.TwoPlayerKey0;
            keysP1.Keys = game.TwoPlayerKey1;

            settingsIsLoading = false;
        }

        private int findMap(string schemeFile, GameType? gameType = null) {
            return Array.FindIndex<AtomicBombermanMap>(game.getMaps(gameType), new Predicate<AtomicBombermanMap>(delegate (AtomicBombermanMap map) {
                return map.SchemeFile.ToLower() == schemeFile.ToLower();
            }));
        }

        private int textToSeconds(string text) {
            if (text.ToLower() == "infinite" || text.ToLower() == "бесконечное") return AtomicBomberman.INFINITE_TIME;

            string[] parts = text.Split(':');
            int minutes = Int32.Parse(parts[0]);
            int seconds = Int32.Parse(parts[1]);

            return minutes * 60 + seconds;
        }

        private void launchGame() {
            game.TeamMode = rdTeamGame.Checked;
            game.P1Keys = keysP0.Keys;
            game.P2Keys = keysP1.Keys;
            Visible = false;
            game.start(this, loadSettings);
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Escape && !escapeNoClose) Close();
        }

        private void fillMapList() {
            cbMap.Items.Clear();
            if (!chShowAllSchemes.Checked)
            {
                cbMap.Items.AddRange(game.getMaps(rdMeleeGame.Checked ? GameType.freeForAll : GameType.team));
                try
                {
                    cbMap.SelectedIndex = rdMeleeGame.Checked ? game.MeleeMapIndex : game.TeamMapIndex;
                }
                catch { cbMap.SelectedIndex = 0; }
            }
            else
            {
                cbMap.Items.AddRange(game.getMaps());
                try
                {
                    cbMap.SelectedIndex = game.AllMapsIndex;
                }
                catch { cbMap.SelectedIndex = 0; }
            }
            }

        private void rdMeleeGame_CheckedChanged(object sender, EventArgs e) {
            fillMapList();
            drawMapPreview();
        }

        private void drawMapPreview() {
            previewBox.Image = ((AtomicBombermanMap)cbMap.SelectedItem).getBitmap(new Bitmap[] { 
                Properties.Resources.tile_grass,  
                Properties.Resources.tile_brick,
                Properties.Resources.tile_rock
            });
        }

        private void cbMap_SelectedIndexChanged(object sender, EventArgs e) {
            if (!chShowAllSchemes.Checked)
            {
                if (rdMeleeGame.Checked)
                    game.MeleeMapIndex = cbMap.SelectedIndex;
                else
                    game.TeamMapIndex = cbMap.SelectedIndex;
            }
            else
            {
                game.AllMapsIndex = cbMap.SelectedIndex;
            }
            game.SchemeFile = ((AtomicBombermanMap)cbMap.SelectedItem).SchemeFile;
            drawMapPreview();
        }

        private void btStart_Click(object sender, EventArgs e) 
        {
            launchGame();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e) 
        {
            game.P1Keys = keysP0.Keys;
            game.P2Keys = keysP1.Keys;
            game.TeamMode = rdTeamGame.Checked;
        }

        private void chAutoKeys1_CheckedChanged(object sender, EventArgs e) {
            game.AutoAssign = ((CheckBox)sender).Checked;
            chAutoKeys.Checked = game.AutoAssign;
        }
        private void chRandomStart_CheckedChanged(object sender, EventArgs e)
        {
            game.RandomStart = ((CheckBox)sender).Checked;
            chRandomStart.Checked = game.RandomStart;
        }

        private void chStompedBombsDetonate_CheckedChanged(object sender, EventArgs e)
        {
            game.StompedBombsDetonate = ((CheckBox)sender).Checked;
            chStompedBombsDetonate.Checked = game.StompedBombsDetonate;
        }

        private void cbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!settingsIsLoading)
            {
                MessageBox.Show(Localization.getLocalizedString("RestartRequired_Message"), Localization.getLocalizedString("RestartRequired_Title"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                game.Language = cbLanguage.SelectedIndex;
            }
        }

        private void btOpenSchemesFolder_Click(object sender, EventArgs e)
        {
            string spath = Path.Combine(Directory.GetCurrentDirectory(), "DATA\\SCHEMES");
            Process.Start(spath);
        }

        private void chShowAllSchemes_CheckedChanged(object sender, EventArgs e)
        {
            if (!settingsIsLoading)
            {
                fillMapList();
                drawMapPreview();
                game.ShowAllSchemes = chShowAllSchemes.Checked;
            }
        }

        private void chWinByKills_CheckedChanged(object sender, EventArgs e)
        {
            game.WinByKills = ((CheckBox)sender).Checked;
            chWinByKills.Checked = game.WinByKills;
        }

        private void chGoldMan_CheckedChanged(object sender, EventArgs e)
        {
            game.GoldMan = ((CheckBox)sender).Checked;
            chGoldMan.Checked = game.GoldMan;
        }

        private void chLostNetRevertAi_CheckedChanged(object sender, EventArgs e)
        {
            game.LostNetRevertAi = ((CheckBox)sender).Checked;
            chLostNetRevertAi.Checked = game.LostNetRevertAi;
        }

        private void chDiseasesDestroyable_CheckedChanged(object sender, EventArgs e)
        {
            game.DiseasesDestroyable = ((CheckBox)sender).Checked;
            chDiseasesDestroyable.Checked = game.DiseasesDestroyable;
        }

        private void rdTeamGame_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTeamGame.Checked)
            {
                chWinByKills.Checked = false;
                chWinByKills.Enabled = false;
            }
            else
            {
                chWinByKills.Enabled = true;
            }
            game.TeamMode = rdTeamGame.Checked;
        }

        private void chCheckForUpdates_CheckedChanged(object sender, EventArgs e)
        {
            game.CheckForUpdates = ((CheckBox)sender).Checked;
            chCheckForUpdates.Checked = game.CheckForUpdates;
        }

        private void btCheckForUpdates_Click(object sender, EventArgs e)
        {
            Network.checkForUpdates(false);
        }

        private void btRunIpxconfig_Click(object sender, EventArgs e)
        {
            if (game.UsePublicIPXServer) MessageBox.Show(Localization.getLocalizedString("UsePublicIpxServerIpxConfigWarning_Message"), Localization.getLocalizedString("GenericWarning_Title"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            game.startTool("ipxconfig.exe");
        }

        private void btRunCncDrawConfig_Click(object sender, EventArgs e)
        {
            game.startTool("cnc-ddraw config.exe");
        }

        private void btRunIntro_Click(object sender, EventArgs e)
        {
            game.startTool("INTRO\\BMINTRO.EXE");
        }

        private void txNodeName_TextChanged(object sender, EventArgs e)
        {
            game.NodeName = txNodeName.Text;
        }

        private void cbEnclosure_SelectedIndexChanged(object sender, EventArgs e)
        {
            game.EnclosureDepth = (EncloseDepth)cbEnclosure.SelectedIndex;
        }

        private void cbConveyorSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            game.ConveyorBeltSpeed = (ConveyorSpeed)cbConveyorSpeed.SelectedIndex;
        }

        private void cbPlaytime_SelectedIndexChanged(object sender, EventArgs e)
        {
            game.PlayTime = textToSeconds(cbPlaytime.Text);
        }

        private void chUsePublicIPXServer_CheckedChanged(object sender, EventArgs e)
        {
            game.UsePublicIPXServer = chUsePublicIPXServer.Checked;
            label3.Visible = chUsePublicIPXServer.Checked;
            cbServersList.Visible = chUsePublicIPXServer.Checked;
            cbServersList.SelectedIndexChanged -= cbServersList_SelectedIndexChanged;
            cbServersList.Items.Clear();
            if (game.UsePublicIPXServer)
            {
                if (game.getIpxWrapperIniHash(false) == null || game.getIpxWrapperIniHash(false) == game.IpxWrapperIniHash)
                {
                    Network.retriveServerList();
                    if (Network.serverList != null)
                    {
                        if (Network.serverList.enabled)
                        {
                            cbServersList.Enabled = true;
                            foreach (var server in Network.serverList.servers) cbServersList.Items.Add(server.displayName);
                            cbServersList.SelectedIndexChanged += cbServersList_SelectedIndexChanged;
                            try 
                            {
                                cbServersList.SelectedIndex = game.SelectedIpxServer; 
                            }
                            catch
                            {
                                MessageBox.Show(Localization.getLocalizedString("UsePublicIpxServer_ServerRemovedFromList_Message"), Localization.getLocalizedString("GenericWarning_Title"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                cbServersList.SelectedIndex = 0;
                            }
                        }
                        else
                        {
                            cbServersList.Enabled = false;
                            cbServersList.Items.Add(Localization.getLocalizedString("UsePublicIPXServer_RemotelyDisabled"));
                            cbServersList.SelectedIndex = 0;
                        }
                    }
                    else
                    {
                        cbServersList.Enabled = false;
                        cbServersList.Items.Add(Localization.getLocalizedString("UsePublicIPXServer_NoData"));
                        cbServersList.SelectedIndex = 0;
                    }
                }
                else
                {
                    MessageBox.Show(Localization.getLocalizedString("UsePublicIpxServer_FileAlreadyExsistsOrModified_Message"), Localization.getLocalizedString("GenericError_Title"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    chUsePublicIPXServer.CheckedChanged -= chUsePublicIPXServer_CheckedChanged;
                    chUsePublicIPXServer.Checked = false;
                    game.UsePublicIPXServer = false;
                    game.SelectedIpxServer = 0;
                    game.IpxWrapperIniHash = null;
                    label3.Visible = chUsePublicIPXServer.Checked;
                    cbServersList.Visible = chUsePublicIPXServer.Checked;
                    chUsePublicIPXServer.CheckedChanged += chUsePublicIPXServer_CheckedChanged;
                }
            }
            else
            {
                if (game.getIpxWrapperIniHash(false) == game.IpxWrapperIniHash)
                {
                    game.deleteIpxWrapperIni();
                }
                else
                {
                    MessageBox.Show(Localization.getLocalizedString("UsePublicIpxServer_FileAlreadyExsistsOrModified_Message"), Localization.getLocalizedString("GenericError_Title"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    chUsePublicIPXServer.CheckedChanged -= chUsePublicIPXServer_CheckedChanged;
                    chUsePublicIPXServer.Checked = false;
                    game.UsePublicIPXServer = false;
                    game.SelectedIpxServer = 0;
                    game.IpxWrapperIniHash = null;
                    label3.Visible = chUsePublicIPXServer.Checked;
                    cbServersList.Visible = chUsePublicIPXServer.Checked;
                    chUsePublicIPXServer.CheckedChanged += chUsePublicIPXServer_CheckedChanged;
                }

            }
        }

        private void cbServersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            game.writeIpxWrapperIni(cbServersList.SelectedIndex);
            game.getIpxWrapperIniHash(true);
            game.SelectedIpxServer = cbServersList.SelectedIndex;
        }

        private void btLicense_Click(object sender, EventArgs e)
        {
            using (License licenseForm = new License())
            {
                licenseForm.ShowDialog();
            }
        }

        private void btGitHub_Click(object sender, EventArgs e)
        {
            Network.openUrl("https://github.com/Ceotom/ablauncher");
        }

        private void btRepairPath_Click(object sender, EventArgs e)
        {
            game.repairPath();
        }

        private void chUseNewBombs_CheckedChanged(object sender, EventArgs e)
        {
           if (((CheckBox)sender).Checked) game.masterAliSet(TNEmanifest.TNEmanifestRoot.useNewBombsTrue, TNEmanifest.TNEmanifestRoot.useNewBombsFalse, "useNewBombs");
           else game.masterAliSet(TNEmanifest.TNEmanifestRoot.useNewBombsFalse, TNEmanifest.TNEmanifestRoot.useNewBombsTrue, "useNewBombs");
        }

        private void chUseAnimatedPower_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked) game.masterAliSet(TNEmanifest.TNEmanifestRoot.useAnimatedPowerTrue, TNEmanifest.TNEmanifestRoot.useAnimatedPowerFalse, "useAnimatedPower");
            else game.masterAliSet(TNEmanifest.TNEmanifestRoot.useAnimatedPowerFalse, TNEmanifest.TNEmanifestRoot.useAnimatedPowerTrue, "useAnimatedPower");
        }

        private void clbRandomStages_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckedListBox clb = (CheckedListBox)sender;
            int changedIndex = clb.SelectedIndex;
            int number = 0;

            if (changedIndex != -1)
            {
                bool isChecked = clb.GetItemChecked(changedIndex);
                if (isChecked) number = 1;

                game.setValue(number, changedIndex + 1150);
            }
        }
    }

    class KeyBindControls {
        public TextBox up;
        public TextBox down;
        public TextBox left;
        public TextBox right;
        public TextBox action1;
        public TextBox action2;

        public AtomicBombermanKeys Keys {
            get {
                AtomicBombermanKeys r = new AtomicBombermanKeys();
                r.up = ((KeyBindControlState)up.Tag).key;
                r.down = ((KeyBindControlState)down.Tag).key;
                r.left = ((KeyBindControlState)left.Tag).key;
                r.right = ((KeyBindControlState)right.Tag).key;
                r.action1 = ((KeyBindControlState)action1.Tag).key;
                r.action2 = ((KeyBindControlState)action2.Tag).key;
                return r;
            }

            set {
                ((KeyBindControlState)up.Tag).key = value.up;
                ((KeyBindControlState)down.Tag).key = value.down;
                ((KeyBindControlState)left.Tag).key = value.left;
                ((KeyBindControlState)right.Tag).key = value.right;
                ((KeyBindControlState)action1.Tag).key = value.action1;
                ((KeyBindControlState)action2.Tag).key = value.action2;
                updateAll();
            }
        }

        public void updateAll() {
            updateBox(up);
            updateBox(down);
            updateBox(left);
            updateBox(right);
            updateBox(action1);
            updateBox(action2);
        }

        public static void updateBox(TextBox box) {
            KeysConverter conv = new KeysConverter();
            box.Text = conv.ConvertToString(((KeyBindControlState)box.Tag).key);
       }
    }

    class KeyBindControlState {
        public Keys key = Keys.None;
        public bool capturing = false;
    }

    class User32 {
        [DllImport("user32.dll")]
        internal static extern short GetAsyncKeyState(int vKey);
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ablauncher {
    public partial class MainForm : Form {
        private AtomicBomberman game;
        private bool escapeNoClose = false;

        private KeyBindControls kOne0;
        private KeyBindControls kTwo0;
        private KeyBindControls kTwo1;

        public MainForm(AtomicBomberman game) {
            InitializeComponent();

            this.game = game;

            kOne0 = createKeyPad(spKeys0);
            kTwo0 = createKeyPad(tpKeys0);
            kTwo1 = createKeyPad(tpKeys1);
        }

        private void MainForm_Load(object sender, EventArgs e) {
            lbVersion.Text = "v" + Program.Version;

            cbPlayers.SelectedIndex = 0;

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
            addLabel(parent, groupX - 15, 115, "Move");

            int actionOfs = 100;

            addLabel(parent, actionOfs + 5, 40, "Bomb");
            ctrl.action1 = addKeyBox(parent, actionOfs + 40, 37, w);
            addLabel(parent, actionOfs, 94, "Special");
            ctrl.action2 = addKeyBox(parent, actionOfs + 40, 91, w);

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

        private Label addLabel(GroupBox parent, int x, int y, string text) {
            Label l = new Label();
            parent.Controls.Add(l);

            l.Left = x;
            l.Top = y;
            l.Text = text;
            l.AutoSize = true;

            return l;
        }

        private void loadSettings() {
            txNodeName.Text = game.NodeName;
            cbEnclosure.SelectedIndex = (int)game.EnclosureDepth;
            cbConveyorSpeed.SelectedIndex = (int)game.ConveyorBeltSpeed;
            chAutoKeys1.Checked = game.AutoAssign;
            chAutoKeys2.Checked = game.AutoAssign;

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
            string currentScheme = game.SchemeFile;
            int index = findMap(currentScheme, GameType.freeForAll);
            if (index != -1) rdMeleeGame.Checked = true;
            else {
                index = findMap(currentScheme, GameType.team);
                if (index != -1) rdTeamGame.Checked = true;
                else index = 0;
            }
            fillMapList();
            cbMap.SelectedIndex = index;

            // Load keys
            kOne0.Keys = game.OnePlayerKey0;
            kTwo0.Keys = game.TwoPlayerKey0;
            kTwo1.Keys = game.TwoPlayerKey1;
        }

        private void saveKeySets() {
            game.OnePlayerKey0 = kOne0.Keys;
            game.TwoPlayerKey0 = kTwo0.Keys;
            game.TwoPlayerKey1 = kTwo1.Keys;
        }

        private int findMap(string schemeFile, GameType gameType) {
            return Array.FindIndex<AtomicBombermanMap>(game.getMaps(gameType), new Predicate<AtomicBombermanMap>(delegate (AtomicBombermanMap map) {
                return map.SchemeFile.ToLower() == schemeFile.ToLower();
            }));
        }

        private int textToSeconds(string text) {
            if (text.ToLower() == "infinite") return AtomicBomberman.INFINITE_TIME;

            string[] parts = text.Split(':');
            int minutes = Int32.Parse(parts[0]);
            int seconds = Int32.Parse(parts[1]);

            return minutes * 60 + seconds;
        }

        private void launchGame() {
            saveKeySets();

            game.NodeName = txNodeName.Text;
            game.DefaultProtocol = 1;
            game.SchemeFile = ((AtomicBombermanMap)cbMap.SelectedItem).SchemeFile;
            game.EnclosureDepth = (EncloseDepth)cbEnclosure.SelectedIndex;
            game.ConveyorBeltSpeed = (ConveyorSpeed)cbConveyorSpeed.SelectedIndex;
            game.PlayTime = textToSeconds(cbPlaytime.Text);
            game.TeamMode = rdTeamGame.Checked;
            if (cbPlayers.SelectedIndex == 0) {
                // 1 player
                game.P1Keys = kOne0.Keys;
            }
            else {
                // 2 players
                game.P1Keys = kTwo0.Keys;
                game.P2Keys = kTwo1.Keys;
            }

            game.start();
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Escape && !escapeNoClose) Close();
        }

        private void fillMapList() {
            cbMap.Items.Clear();
            cbMap.Items.AddRange(game.getMaps(rdMeleeGame.Checked ? GameType.freeForAll : GameType.team));
            cbMap.SelectedIndex = rdMeleeGame.Checked ? game.MeleeMapIndex : game.TeamMapIndex;
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
            if (rdMeleeGame.Checked)
                game.MeleeMapIndex = cbMap.SelectedIndex;
            else
                game.TeamMapIndex = cbMap.SelectedIndex;
            drawMapPreview();
        }

        private void btStart_Click(object sender, EventArgs e) {
            launchGame();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start(linkLabel1.Text);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
            saveKeySets();
        }

        private void chAutoKeys1_CheckedChanged(object sender, EventArgs e) {
            game.AutoAssign = ((CheckBox)sender).Checked;
            chAutoKeys1.Checked = game.AutoAssign;
            chAutoKeys2.Checked = game.AutoAssign;
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
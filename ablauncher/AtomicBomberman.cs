using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Reflection;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace ablauncher {

    public enum GameType { freeForAll, team };
    public enum EncloseDepth { none, aLittle, aLot, allTheWay };
    public enum ConveyorSpeed { low, medium, high };

    public class AtomicBombermanKeys {
        public Keys up;
        public Keys down;
        public Keys left;
        public Keys right;
        public Keys action1;
        public Keys action2;
    }

    public class AtomicBomberman {
        const string SENTINEL_FILE    = "BM95.EXE";
        const string EXECUTABLE_FILE = "BM95.EXE";
        const string PROCESS_NAME = "BM95";
        const string MAP_DIRECTORY    = "DATA\\SCHEMES";
        const string NODENAME_FILE    = "NODENAME.INI";
        const string OPTIONS_FILE     = "OPTIONS.INI";
        const string LAUNCHER_OPTIONS_FILE     = "ablauncher.ini";
        const string DIRHOME_FILE     = "CFG.INI";
        const string TWEAKS_FILE      = "DATA\\RES\\VALUELST.RES";

        public const int INFINITE_TIME = 1001;

        public string gameDirectory;
        private BombermanKeys keyMap = new BombermanKeys();

        private AtomicBomberman(string gameDirectory) {
            this.gameDirectory = gameDirectory;
        }

        public static AtomicBomberman construct() {
            string dir = "";
            string[] args = Environment.GetCommandLineArgs();
            if (dir == "") dir = tryDirectory(Environment.CurrentDirectory);
            if (dir == "") dir = tryDirectory(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
            if (dir == "" && args.Length > 1) dir = tryDirectory(args[1]);

            if (dir == "") return null;
            return new AtomicBomberman(dir);
        }

        private static string tryDirectory(string directory) {
            if (File.Exists(Path.Combine(directory, SENTINEL_FILE))) return directory;
            return "";
        }

        public AtomicBombermanMap[] getMaps(GameType? gameType = null) {
            List<AtomicBombermanMap> maps = new List<AtomicBombermanMap>();

            foreach (string mapFile in Directory.GetFiles(Path.Combine(gameDirectory, MAP_DIRECTORY))) {
                try {
                    AtomicBombermanMap map = new AtomicBombermanMap(mapFile);

                    if (gameType == null || (gameType == GameType.team) == map.isTeamMap())
                    {
                        maps.Add(map);
                    }
                }
                catch (Exception) { /* Ignore */ }
            }

            return maps.ToArray();
        }

        public string NodeName {
            get { return File.ReadAllText(Path.Combine(gameDirectory, NODENAME_FILE)).Trim(); }
            set 
            {
                checkIfGameRunning(true);
                File.WriteAllText(Path.Combine(gameDirectory, NODENAME_FILE), value); 
            }
        }

        public EncloseDepth EnclosureDepth {
            get { return (EncloseDepth)getOption("enclosement_depth", (int)EncloseDepth.aLot); }
            set { setOption("enclosement_depth", (int)value); }
        }

        public ConveyorSpeed ConveyorBeltSpeed {
            get { return (ConveyorSpeed)getOption("conveyor_speed", (int)ConveyorSpeed.medium); }
            set { setOption("conveyor_speed", (int)value); }
        }

        public string SchemeFile {
            get { return getOption("schemefilename"); }
            set { setOption("schemefilename", value); }
        }

        public int PlayTime {
            get { return getOption("playtime", 150); }
            set { setOption("playtime", value); }
        }

        public bool TeamMode {
            get { return getOption("team_play", 0) == 1; }
            set { setOption("team_play", value ? 1 : 0); }
        }

        public bool RandomStart {
            get { return getOption("random_start", 0) == 1; }
            set { setOption("random_start", value ? 1 : 0); }
        }

        public bool StompedBombsDetonate
        {
            get { return getOption("stomped_bombs_detonate", 0) == 1; }
            set { setOption("stomped_bombs_detonate", value ? 1 : 0); }
        }

        public bool WinByKills
        {
            get { return getOption("win_by_kills", 0) == 1; }
            set { setOption("win_by_kills", value ? 1 : 0); }
        }

        public bool GoldMan
        {
            get { return getOption("goldman", 0) == 1; }
            set { setOption("goldman", value ? 1 : 0); }
        }

        public bool LostNetRevertAi
        {
            get { return getOption("lost_net_revert_ai", 0) == 1; }
            set { setOption("lost_net_revert_ai", value ? 1 : 0); }
        }

        public bool DiseasesDestroyable
        {
            get { return getOption("diseases_destroyable", 0) == 1; }
            set { setOption("diseases_destroyable", value ? 1 : 0); }
        }

        public bool AutoAssign {
            get { return getOption("assign_keyboards", 0) == 1; }
            set { setOption("assign_keyboards", value ? 1 : 0); }
        }

        public AtomicBombermanKeys P1Keys {
            get { return getKeySet("keydef", 0); }
            set { setKeySet("keydef", 0, value); }
        }

        public AtomicBombermanKeys P2Keys {
            get { return getKeySet("keydef", 1); }
            set { setKeySet("keydef", 1, value); }
        }

        public AtomicBombermanKeys TwoPlayerKey0 {
            get { return getKeySet("keydef", 0); }
        }

        public AtomicBombermanKeys TwoPlayerKey1 {
            get { return getKeySet("keydef", 1); }
        }

        public int MeleeMapIndex {
            get { return getLauncherOption("abl_preselect_melee", 0); }
            set { setLauncherOption("abl_preselect_melee", value); }
        }
        
        public int Language
        {
            get { return getLauncherOption("abl_language", 0); }
            set { setLauncherOption("abl_language", value); }
        }

        public bool FinishedOnboarding
        {
            get { return getLauncherOption("abl_onboard", 0) == 1; }
            set { setLauncherOption("abl_onboard", value ? 1 : 0); }
        }

        public bool ShowAllSchemes
        {
            get { return getLauncherOption("abl_show_all_schemes", 0) == 1; }
            set { setLauncherOption("abl_show_all_schemes", value ? 1 : 0); }
        }

        public int TeamMapIndex {
            get { return getLauncherOption("abl_preselect_team", 0); }
            set { setLauncherOption("abl_preselect_team", value); }
        }

        public int AllMapsIndex
        {
            get { return getLauncherOption("abl_preselect_all", 0); }
            set { setLauncherOption("abl_preselect_all", value); }
        }

        public bool CheckForUpdates
        {
            get { return getLauncherOption("abl_check_for_updates", 0) == 1; }
            set { setLauncherOption("abl_check_for_updates", value ? 1 : 0); }
        }

        private AtomicBombermanKeys getKeySet(string set, int player) {
            AtomicBombermanKeys r = new AtomicBombermanKeys();
            r.up      = getKey(set, player, 0);
            r.right   = getKey(set, player, 1);
            r.down    = getKey(set, player, 2);
            r.left    = getKey(set, player, 3);
            r.action1 = getKey(set, player, 4);
            r.action2 = getKey(set, player, 5);
            return r;
        }

        private Keys getKey(string set, int player, int action) {
            return keyMap.BmToWindows(getBmKey(set, player, action));
        }

        private int getBmKey(string set, int player, int action) {
            try {
                return Int32.Parse(iniGet(Path.Combine(gameDirectory, OPTIONS_FILE), string.Format("{0}={1},{2}", set, player, action), ","));
            }
            catch (FormatException) {
                return 0;
            }
        }

        private void setKeySet(string set, int player, AtomicBombermanKeys keySet) {
            setKey(set, player, 0, keySet.up);
            setKey(set, player, 1, keySet.right);
            setKey(set, player, 2, keySet.down);
            setKey(set, player, 3, keySet.left);
            setKey(set, player, 4, keySet.action1);
            setKey(set, player, 5, keySet.action2);
        }

        private void setKey(string set, int player, int action, Keys key) {
            setBmKey(set, player, action, keyMap.WindowsToBm(key));
        }

        private void setBmKey(string set, int player, int action, int keyCode) {
            iniSet(Path.Combine(gameDirectory, OPTIONS_FILE), string.Format("{0}={1},{2}", set, player, action), keyCode.ToString(), ",");
        }

        public bool checkIfGameRunning(bool terminateProgram)
        {
            Process [] process = Process.GetProcessesByName(PROCESS_NAME);
            if (process.Length != 0)
            {
                if (terminateProgram)
                {
                    MessageBox.Show(Localization.getLocalizedString("GameIsRunningError_Message"), Localization.getLocalizedString("GenericError_Title"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Program.ReleaseLauncherMutex();
                    Environment.Exit(0);
                }
                return true;
            }
            return false;
        }

        public void start(Form MainForm, Action loadSettings) {
            checkIfGameRunning(true);
            string path = Path.Combine(gameDirectory, EXECUTABLE_FILE);
            if (!File.Exists(path)) throw new Exception("No executable found");

            // Write proper directory to CFG.INI (a bit of zeroconf work)
            writeDirHome(Path.GetDirectoryName(path));

            // Start in the proper directory
            Process process = new Process();
            process.StartInfo.FileName = path;
            process.StartInfo.WorkingDirectory = Path.GetDirectoryName(path);   
            process.EnableRaisingEvents = true;
            process.Exited += (sender, e) => 
            {
                MainForm.Invoke((MethodInvoker)delegate 
                { 
                    loadSettings();
                    MainForm.Visible = true;
                    MainForm.Activate();
                });

            };
            process.Start();
        }

        public void startTool(string tool)
        {
            string path = Path.Combine(gameDirectory, tool);
            if (!File.Exists(path)) throw new Exception("No executable found");

            ProcessStartInfo info = new ProcessStartInfo(path);
            info.WorkingDirectory = Path.GetDirectoryName(path);
            Process.Start(info);
        }

        public bool checkTool(string tool)
        {
            string path = Path.Combine(gameDirectory, tool);
            if (File.Exists(path)) return true; else return false;
        }
        /**
         * Write the directory of the game to the proper ini file
         */
        private void writeDirHome(string directory) {
            iniSet(Path.Combine(gameDirectory, DIRHOME_FILE), "hdhome", directory, "=");
            iniSet(Path.Combine(gameDirectory, DIRHOME_FILE), "cdhome", directory, "=");
        }

        private void tweak(int number, int value) {
            iniSet(Path.Combine(gameDirectory, TWEAKS_FILE), number.ToString(), value.ToString(), ",");
        }

        private string getOption(string key) {
            return iniGet(Path.Combine(gameDirectory, OPTIONS_FILE), key, "=");
        }

        private int getOption(string key, int def) {
            try {
                return Int32.Parse(getOption(key));
            }
            catch (Exception) {
                return def;
            }
        }

        private string getLauncherOption(string key) {
            return iniGet(Path.Combine(gameDirectory, LAUNCHER_OPTIONS_FILE), key, "=");
        }

        private int getLauncherOption(string key, int def) {
            try {
                return Int32.Parse(getLauncherOption(key));
            }
            catch (Exception) {
                return def;
            }
        }

        private void setOption(string key, string value) {
            iniSet(Path.Combine(gameDirectory, OPTIONS_FILE), key, value, "=");
        }

        private void setOption(string key, int value) {
            setOption(key, value.ToString());
        }

        private void setLauncherOption(string key, string value) {
            iniSet(Path.Combine(gameDirectory, LAUNCHER_OPTIONS_FILE), key, value, "=");
        }

        private void setLauncherOption(string key, int value) {
            setLauncherOption(key, value.ToString());
        }

        private string iniGet(string fileName, string key, string delim) {
            string file = File.ReadAllText(fileName);
            Match m = Regex.Match(file, "^" + Regex.Escape(key) + Regex.Escape(delim) + "(.*)$", RegexOptions.Multiline);
            if (m.Success) return m.Groups[1].Value.Trim();
            return "";
        }

        private void iniSet(string fileName, string key, string value, string delim) {
            if (!MainForm.settingsIsLoading || OnboardingForm.onOnboardingScreen)
            {
                checkIfGameRunning(true);
                string file = File.ReadAllText(fileName), newFile;
                Regex r = new Regex("^(" + Regex.Escape(key) + ")" + Regex.Escape(delim) + ".*$", RegexOptions.Multiline);

                if (r.IsMatch(file))
                    newFile = r.Replace(file, "$1" + delim + value + "\r" /* Need to add the \r back, because the regex has stripped it */);
                else
                    newFile = file + key + delim + value + Environment.NewLine;

                try { File.WriteAllText(fileName, newFile); }
                catch (IOException) { /* Swallow it, better to just go on than to throw an error */ }
            }
        }
    }

    public enum TileType { grass = 0, brick, rock };

    public class AtomicBombermanMap {
        public const int HTILES = 15;
        public const int VTILES = 11;

        private string mapFile;
        private string fileName;
        private string mapTitle;

        private TileType[,] tiles = new TileType[VTILES,HTILES];

        public AtomicBombermanMap(string mapFile) {
            this.mapFile  = mapFile;
            this.fileName = Path.GetFileNameWithoutExtension(mapFile).ToLower();
            this.mapTitle = "?";
            parseFile();
        }

        public string SchemeFile {
            get { return Path.GetFileName(mapFile); }
        }

        private void parseFile() {
            string contents = File.ReadAllText(mapFile);

            // Read title
            Match m = Regex.Match(contents, "^-N,(.*)$", RegexOptions.Multiline);
            if (m.Success) mapTitle = m.Groups[1].Value.Trim();

            // Read map definition
            foreach (Match l in Regex.Matches(contents, @"^-R,([\d ]+),([:#.]+)", RegexOptions.Multiline)) {
                int row = Int32.Parse(l.Groups[1].Value);
                string def = l.Groups[2].Value;

                for (int col = 0; col < HTILES; col++) {
                    tiles[row, col] = 
                        def[col] == '.' ? TileType.grass : 
                        def[col] == '#' ? TileType.rock :
                        def[col] == ':' ? TileType.brick : TileType.rock;
                }
            }
        }

        public override string ToString() {
            return string.Format("{0}: {1}", fileName, mapTitle);
        }

        public bool isTeamMap() {
            return mapTitle.IndexOf(")(") > -1;
        }

        public Bitmap getBitmap(Bitmap[] tileImages) {
            int w = tileImages[0].Width, h = tileImages[0].Height;
            Bitmap bmp = new Bitmap(HTILES * w, VTILES * h);

            using (Graphics g = Graphics.FromImage(bmp)) {
                for (int y = 0; y < VTILES; y++)
                    for (int x = 0; x < HTILES; x++)
                        g.DrawImage(tileImages[(int)tiles[y,x]], x * w, y * h);
            }

            return bmp;
        }
    }
}

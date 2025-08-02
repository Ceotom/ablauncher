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
        const string EXECUTABLE_FILE1 = "BM.EXE";
        const string EXECUTABLE_FILE2 = "BM95.EXE";
        const string MAP_DIRECTORY    = "DATA\\SCHEMES";
        const string NODENAME_FILE    = "NODENAME.INI";
        const string OPTIONS_FILE     = "OPTIONS.INI";
        const string DIRHOME_FILE     = "CFG.INI";
        const string TWEAKS_FILE      = "DATA\\RES\\VALUELST.RES";

        public const int INFINITE_TIME = 1001;

        private string gameDirectory;
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

        public AtomicBombermanMap[] getMaps(GameType gameType) {
            List<AtomicBombermanMap> maps = new List<AtomicBombermanMap>();

            foreach (string mapFile in Directory.GetFiles(Path.Combine(gameDirectory, MAP_DIRECTORY))) {
                try {
                    AtomicBombermanMap map = new AtomicBombermanMap(mapFile);

                    if ((gameType == GameType.team) == (map.isTeamMap())) maps.Add(map);
                }
                catch (Exception) { /* Ignore */ }
            }

            return maps.ToArray();
        }

        public string NodeName {
            get { return File.ReadAllText(Path.Combine(gameDirectory, NODENAME_FILE)).Trim(); }
            set { File.WriteAllText(Path.Combine(gameDirectory, NODENAME_FILE), value); }
        }

        public int DefaultProtocol {
            get { return getOption("netprotocol", 0); }
            set { setOption("netprotocol", value); }
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
            set {
                setOption("team_play", value ? 1 : 0);
                setOption("random_start", value ? 0 : 1);
            }
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

        public AtomicBombermanKeys OnePlayerKey0 {
            get { if (getOption("abl_1p_keys") != "") return getKeySet("abl_1p_keys", 0); else return getKeySet("keydef", 0); }
            set { setKeySet("abl_1p_keys", 0, value); }
        }

        public AtomicBombermanKeys TwoPlayerKey0 {
            get { if (getOption("abl_2p_keys") != "") return getKeySet("abl_2p_keys", 0); else return getKeySet("keydef", 0); }
            set { setKeySet("abl_2p_keys", 0, value); }
        }

        public AtomicBombermanKeys TwoPlayerKey1 {
            get { if (getOption("abl_2p_keys") != "") return getKeySet("abl_2p_keys", 1); else return getKeySet("keydef", 1); }
            set { setKeySet("abl_2p_keys", 1, value); }
        }

        public int MeleeMapIndex {
            get { return getOption("abl_preselect_melee", 0); }
            set { setOption("abl_preselect_melee", value); }
        }

        public int TeamMapIndex {
            get { return getOption("abl_preselect_team", 0); }
            set { setOption("abl_preselect_team", value); }
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

        public void start() {
            string path = Path.Combine(gameDirectory, EXECUTABLE_FILE1);
            if (!File.Exists(path)) path = Path.Combine(gameDirectory, EXECUTABLE_FILE2);
            if (!File.Exists(path)) throw new Exception("No executable found");

            // Write proper directory to CFG.INI (a bit of zeroconf work)
            writeDirHome(Path.GetDirectoryName(path));
            writeTweaks();

            // Start in the proper directory
            ProcessStartInfo info = new ProcessStartInfo(path);
            info.WorkingDirectory = Path.GetDirectoryName(path);            
            Process.Start(info);
        }

        /**
         * Write the directory of the game to the proper ini file
         */
        private void writeDirHome(string directory) {
            iniSet(Path.Combine(gameDirectory, DIRHOME_FILE), "hdhome", directory, "=");
            iniSet(Path.Combine(gameDirectory, DIRHOME_FILE), "cdhome", directory, "=");
        }

        /**
         * Write a number of other tweaks
         */
        private void writeTweaks() {
            // Decrease the wait-between-screens delay from 3 (default) to 2 seconds.
            // I don't dare set it to 1, I've seen a recent computer fail to catch up to that :|.
            tweak(13, 2);
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

        private void setOption(string key, string value) {
            iniSet(Path.Combine(gameDirectory, OPTIONS_FILE), key, value, "=");
        }

        private void setOption(string key, int value) {
            setOption(key, value.ToString());
        }

        private string iniGet(string fileName, string key, string delim) {
            string file = File.ReadAllText(fileName);
            Match m = Regex.Match(file, "^" + Regex.Escape(key) + Regex.Escape(delim) + "(.*)$", RegexOptions.Multiline);
            if (m.Success) return m.Groups[1].Value.Trim();
            return "";
        }

        private void iniSet(string fileName, string key, string value, string delim) {
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
            return string.Format("{0} ({1})", fileName, mapTitle);
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

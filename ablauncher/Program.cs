using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;
using System.Globalization;
using System.Threading;

namespace ablauncher {
    static class Program {
        public static string VERSION = "0.1";
        public static string REVISION = "$Revision: 12 $";
        public static string DATE = "$Date: 2008-05-13 22:41:25 +0200 (di, 13 mei 2008) $";

        public static string Version {
            get {
                Version v = Assembly.GetExecutingAssembly().GetName().Version;

                return string.Format("{0}.{1}.{2}", v.Major, v.Minor, v.Build);
            }
        }

        public static string VersionDate {
            get { return DATE.Replace("$", "").Trim(); }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           // Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");

            AtomicBomberman game = AtomicBomberman.construct();
            if (game == null) {
                MessageBox.Show("Atomic Bomberman game not found!\n\nPlease place Atomic Bomberman Launcher in the same directory as the game.", "Atomic Bomberman not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Application.Run(new MainForm(game));
        }
    }
}
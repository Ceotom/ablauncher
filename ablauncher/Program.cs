using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;
using System.Globalization;
using System.Threading;
using ablauncher.Properties;

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

            AtomicBomberman game = AtomicBomberman.construct();
            if (game == null) {
                MessageBox.Show(Localization.getLocalizedString("GameNotFound_Message"), Localization.getLocalizedString("GameNotFound_Title"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            switch (game.Language)
            {
                case 0:
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.InstalledUICulture;
                    break;
                case 1:
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    break;
                case 2:
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");
                    break;
                default:
                    game.Language = 0;
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.InstalledUICulture;
                    break;
            }
            if (game.CheckForUpdates) Network.checkForUpdates(true);
            Application.Run(new MainForm(game));
        }
    }
}
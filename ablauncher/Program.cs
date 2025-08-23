using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;
using System.Globalization;
using System.Threading;
using ablauncher.Properties;
using System.Runtime.InteropServices;

namespace ablauncher {
    static class Program {
        public static string Version {
            get {
                Version v = Assembly.GetExecutingAssembly().GetName().Version;

                return string.Format("{0}.{1}.{2}", v.Major, v.Minor, v.Build);
            }
        }
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        private static Mutex mutex = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void BringOldInstanceWindow()
        {
            IntPtr hWnd = FindWindow(null, "Atomic Bomberman Launcher2");
            if (hWnd != IntPtr.Zero)
            {
                ShowWindow(hWnd, 9);
                SetForegroundWindow(hWnd);
            }
        }
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

            bool isNewLauncherInstance = false;
            mutex = new Mutex(true, "ablauncher", out isNewLauncherInstance);
            if (!isNewLauncherInstance)
            {
                BringOldInstanceWindow();
                return;
            }

            if (game.CheckForUpdates) Network.checkForUpdates(true);
            Application.Run(new MainForm(game));
            mutex.ReleaseMutex();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;
using System.Globalization;
using System.Threading;
using ablauncher.Properties;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;

namespace ablauncher
{
    public class Tray
    {
        public static event Action<bool> TrayVisibilityChanged;
        public static int gameProcPid;

        public static void InitTray()
        {
            Thread trayThread = new Thread(() =>
            {
                NotifyIcon trayIcon = new NotifyIcon();
                trayIcon.Icon = Resources.AppIcon;
                trayIcon.Visible = false;
                trayIcon.Text = "Atomic Bomberman Launcher2";
                ContextMenuStrip trayMenu = new ContextMenuStrip();
                trayMenu.Items.Add(Localization.getLocalizedString("TerminateGame_Message"), null, (sender, e) => terminateGame(gameProcPid));
                trayIcon.ContextMenuStrip = trayMenu;

                TrayVisibilityChanged += visible =>
                {
                    if (trayIcon != null)
                        trayIcon.Visible = visible;
                };

                Application.Run();
            });
            trayThread.SetApartmentState(ApartmentState.STA);
            trayThread.IsBackground = true;
            trayThread.Start();
        }

        private static void terminateGame(int pid)
        {
            var gameProc = Process.GetProcessById(pid);
            try
            {
                gameProc.Kill();
            }
            catch { }

        }

        public static void setTrayVisibility(bool visible)
        {
            TrayVisibilityChanged?.Invoke(visible);
        }
    }

}

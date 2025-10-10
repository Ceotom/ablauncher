using ablauncher.Properties;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

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
            if (pid <= 0) return;

            try
            {
                var gameProc = Process.GetProcessById(pid);
                if (!gameProc.HasExited) gameProc.Kill();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Localization.getLocalizedString("FailedToTerminateProcess_Message")} {ex.Message}", Localization.getLocalizedString("GenericError_Title"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public static void setTrayVisibility(bool visible)
        {
            TrayVisibilityChanged?.Invoke(visible);
        }
    }

}

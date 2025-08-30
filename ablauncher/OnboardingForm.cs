using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ablauncher
{
    public partial class OnboardingForm : Form
    {
        private AtomicBomberman game;
        public static bool onOnboardingScreen = true;
        private bool formInit = true;
        private int tempLanguage;
        private bool tempCheckForUpdates;
        private bool tempUsePublicIPXServer;
        private bool restoringTempSettings = false;

        public OnboardingForm(AtomicBomberman game)
        {
            InitializeComponent();
            this.game = game;
            cbLanguage.SelectedIndex = 0;
            chUsePublicIPXServer.Enabled = game.checkTool("ipxwrapper.dll");
            formInit = false;
        }

        private void OnboardingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!game.FinishedOnboarding)
            {
                Program.ReleaseLauncherMutex();
                Environment.Exit(0);
            }
        }

        private void bContinue_Click(object sender, EventArgs e)
        {
            game.FinishedOnboarding = true;
            game.Language = cbLanguage.SelectedIndex;
            game.CheckForUpdates = chCheckForUpdates.Checked;
            game.UsePublicIPXServer = chUsePublicIPXServer.Checked;
            Network.retriveServerList();
            if (Network.serverList != null && Network.serverList.enabled)
            {
                game.writeIpxWrapperIni(0);
                game.getIpxWrapperIniHash(true);
                game.SelectedIpxServer = 0;
            }
            onOnboardingScreen = false;
            Close();
        }

        private void saveTempSettings()
        {
            tempLanguage = cbLanguage.SelectedIndex;
            tempCheckForUpdates = chCheckForUpdates.Checked;
            tempUsePublicIPXServer = chUsePublicIPXServer.Checked;
        }

        private void restoreTempSettings()
        {
             restoringTempSettings = true;
             cbLanguage.SelectedIndex = tempLanguage;
             chCheckForUpdates.Checked = tempCheckForUpdates;
             chUsePublicIPXServer.Checked = tempUsePublicIPXServer;
             restoringTempSettings = false;
        }

        private void cbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!formInit || !restoringTempSettings)
            {
                saveTempSettings();
                switch (cbLanguage.SelectedIndex)
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
                }
                Controls.Clear();
                InitializeComponent();
                cbLanguage.SelectedIndexChanged -= cbLanguage_SelectedIndexChanged;
                restoreTempSettings();
                cbLanguage.SelectedIndexChanged += cbLanguage_SelectedIndexChanged;
                chUsePublicIPXServer.Enabled = game.checkTool("ipxwrapper.dll");
            }
        }
    }
}

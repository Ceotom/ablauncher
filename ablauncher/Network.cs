using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows.Forms;

namespace ablauncher
{
    public class Network
    {
        const string UPDATES_URL = "https://api.github.com/repos/Ceotom/ablauncher/releases/latest";
        public static bool updatesAvailable = false;
        public static bool lastGetRemoteJsonDataSucceed = false;
        public static HttpStatusCode lastGetRemoteJsonDataResponseCode = 0;

        private static string getRemoteJsonData(string url)
        {
           
            try 
            {
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "application/json";
                request.Accept = "application/vnd.github+json";
                request.Headers.Add("X-GitHub-Api-Version", "2022-11-28");
                request.Timeout = 3000;
                request.UserAgent = "ablauncher";

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                        {
                            lastGetRemoteJsonDataSucceed = true;
                            lastGetRemoteJsonDataResponseCode = response.StatusCode;
                            return reader.ReadToEnd();
                        }
                    }
                    else
                    {
                        lastGetRemoteJsonDataSucceed = false;
                        lastGetRemoteJsonDataResponseCode = response.StatusCode;
                        return null;
                    }
                }

            }
            catch (WebException webEx)
            {
                lastGetRemoteJsonDataSucceed = false;
                lastGetRemoteJsonDataResponseCode = 0;
                if (webEx.Response != null)
                {
                    using (var responseError = (HttpWebResponse)webEx.Response)
                    {
                        lastGetRemoteJsonDataResponseCode = responseError.StatusCode;
                    }
                }
                return null;
            }
        }
        public static void checkForUpdates(bool onStartup)
        {
            Version currentVersion = Assembly.GetExecutingAssembly().GetName().Version;
            string response = getRemoteJsonData(UPDATES_URL);
            if (response != null)
            {
                JObject obj = JObject.Parse(response);
                string newVersionStr = Convert.ToString(obj["name"]);
                Version newVersion = new Version(newVersionStr);
                if (newVersion >= currentVersion) updatesAvailable = true;
                else updatesAvailable = false;
                if (updatesAvailable)
                {
                    var answer = MessageBox.Show(Localization.getLocalizedString("UpdatesAvailable_Message"), Localization.getLocalizedString("UpdatesAvailable_Title"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (answer == DialogResult.Yes) Process.Start(Convert.ToString(obj["html_url"]));
                }
                else if (!onStartup) MessageBox.Show(Localization.getLocalizedString("NoUpdatesAvailable_Message"), Localization.getLocalizedString("NoUpdatesAvailable_Title"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (!onStartup && lastGetRemoteJsonDataResponseCode != 0) MessageBox.Show($"{Localization.getLocalizedString("UpdatesError_Message")} {lastGetRemoteJsonDataResponseCode}\n{Localization.getLocalizedString("UpdatesError_Message2")}", Localization.getLocalizedString("NetworkError_Title"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (!onStartup && lastGetRemoteJsonDataResponseCode == 0) MessageBox.Show(Localization.getLocalizedString("UpdatesNetworkError_Message"), Localization.getLocalizedString("NetworkError_Title"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
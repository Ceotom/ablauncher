using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Windows.Forms;

namespace ablauncher
{
    public class Network
    {
        const string UPDATES_URL = "http://127.0.0.1:8080/updates.json";
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
            catch 
            { 
                lastGetRemoteJsonDataSucceed = false;
                lastGetRemoteJsonDataResponseCode = 0;
                return null; 
            }
        }
        public static void checkForUpdates()
        {
            Version currentVersion = Assembly.GetExecutingAssembly().GetName().Version;
            string response = getRemoteJsonData(UPDATES_URL);
            if (response != null)
            {
                JObject obj = JObject.Parse(response);
                string newVersionStr = Convert.ToString(obj["name"]);
                Version newVersion = new Version(newVersionStr);
                if (newVersion >= currentVersion) updatesAvailable = true;
                MessageBox.Show($"Url= {obj["html_url"]}, Ver= {obj["name"]}, UpdatesAvailable = { updatesAvailable } ");
            }
            if (!lastGetRemoteJsonDataSucceed)
            {
                if (lastGetRemoteJsonDataResponseCode != 0) MessageBox.Show(Convert.ToString(lastGetRemoteJsonDataResponseCode));
                else MessageBox.Show("Network error");
            }
        }
    }
}
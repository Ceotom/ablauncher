using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ablauncher
{
    class TNEmanifest
    {
        const int SUPPORTED_MANIFEST_VERSION = 1;
        public static ManifestRoot TNEmanifestRoot;

        public static void parseManifest(string manifestPath)
        {
            TNEmanifestRoot = null;
            using (StreamReader stream = new StreamReader(manifestPath))
            {
                string json = stream.ReadToEnd();
                TNEmanifestRoot = JsonConvert.DeserializeObject<ManifestRoot>(json);
            }
        }

        public static void checkManifestVersion()
        {
            if (TNEmanifestRoot.manifestVersion <= SUPPORTED_MANIFEST_VERSION && TNEmanifestRoot.manifestVersion > 0) Program.isTne = true;
            else MessageBox.Show($"Not supported manifest version: {TNEmanifestRoot.manifestVersion}, supported {SUPPORTED_MANIFEST_VERSION}");
        }

        public class ManifestRoot
        {
            public int manifestVersion { get; set; }
            public string useNewBombsTrue { get; set; }
            public string useNewBombsFalse { get; set; }
            public string useAnimatedPowerTrue { get; set; }
            public string useAnimatedPowerFalse { get; set; }
        }
    }
}
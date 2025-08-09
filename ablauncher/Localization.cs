using System;
using System.Collections.Generic;
using System.Reflection;
using System.Globalization;
using System.Resources;

namespace ablauncher
{
    class Localization
    {
        private static readonly ResourceManager resource = new ResourceManager("ablauncher.Properties.LStrings", typeof(Program).Assembly);
        public static string getLocalizedString(string arg) {
            return resource.GetString(arg) ??  $"NO SUCH STRING ({arg})"; 
        }
    }
}

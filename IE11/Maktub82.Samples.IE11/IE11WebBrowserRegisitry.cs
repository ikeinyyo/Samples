using System.Diagnostics;
using Microsoft.Win32;

namespace Maktub82.Samples.IE11
{
    static class IE11WebBrowserRegisitry
    {
        private const string BrowserEmulationSubKey = @"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION";
        private const int BrowserEmulationValue = BrowserEmulationValueEdge14;

        // Browser Emulation Values: https://msdn.microsoft.com/en-us/library/ee330730(v=vs.85).aspx 
        private const int BrowserEmulationValueEdge14 = 0x00002EE1; // Microsoft Edge
        private const int BrowserEmulationValueIE11 = 0x00002AF9; // IE11
        private const int BrowserEmulationValueIE10 = 0x00002711; // IE10 
        private const int BrowserEmulationValueIE9 = 0x0000270F; // IE9 

        public static void ChangeInternetExplorerVersion()
        {
            RegistryKey registrybrowser = Registry.CurrentUser.OpenSubKey(BrowserEmulationSubKey, true);

            if (registrybrowser == null)
            {
                registrybrowser = Registry.CurrentUser.CreateSubKey(BrowserEmulationSubKey, RegistryKeyPermissionCheck.ReadWriteSubTree);
            }

            string applicationName = GetApplicationName();

            object currentValue = registrybrowser?.GetValue(applicationName);

            if (currentValue == null || (int)currentValue != BrowserEmulationValue)
            {
                registrybrowser?.SetValue(applicationName, BrowserEmulationValue, RegistryValueKind.DWord);
            }
            registrybrowser?.Close();
        }

        public static void RemoveRegistry()
        {
            RegistryKey registrybrowser = Registry.CurrentUser.OpenSubKey(BrowserEmulationSubKey, true);
            string applicationName = GetApplicationName();
            object currentValue = registrybrowser?.GetValue(applicationName);

            if (currentValue != null)
            {
                registrybrowser?.DeleteValue(applicationName);
            }
            registrybrowser?.Close();
        }

        private static string GetApplicationName()
        {
            string applicationName = "*";
#if RELEASE
            applicationName = $"{Process.GetCurrentProcess().ProcessName}.exe";
#endif
            return applicationName;
        }
    }
}

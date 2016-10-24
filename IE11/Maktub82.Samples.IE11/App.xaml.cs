using System;
using System.Windows;

namespace Maktub82.Samples.IE11
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            IE11WebBrowserRegisitry.ChangeInternetExplorerVersion();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            IE11WebBrowserRegisitry.RemoveRegistry();
        }
    }
}

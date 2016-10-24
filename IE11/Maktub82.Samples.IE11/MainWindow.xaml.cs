using System;
using System.Windows;

namespace Maktub82.Samples.IE11
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Browser.Source = new Uri("https://whatbrowser.org");
        }
    }
}

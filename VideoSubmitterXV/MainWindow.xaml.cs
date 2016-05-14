using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro;
using System.Configuration;
using System.Collections.Specialized;

namespace VideoSubmitterXV
{
    /// <summary>
    /// Per ogni utente, ciclare (se presenti) tutti i proxy
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private static void UpdateSetting(string key, string value)
        {
            string configPath = System.IO.Path.Combine(System.Environment.CurrentDirectory, "VideoSubmitterXV.exe");
            Configuration config = ConfigurationManager.OpenExeConfiguration(configPath);
            config.AppSettings.Settings[key].Value = value;
            config.Save();
        }

        private void openFlyout(object sender, RoutedEventArgs e)
        {   
            SettingsFlyout.IsOpen = true;
        }

        private void mainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Test();
            string Theme = ConfigurationManager.AppSettings["theme"];
            ThemeChanger(Theme);
            RightWindowCommandsOverlayBehavior = MahApps.Metro.Controls.WindowCommandsOverlayBehavior.Never;
        }

        private void ThemeChanger(string Theme)
        {
            if(Theme != null)
            ThemeManager.ChangeAppStyle(Application.Current,
                ThemeManager.GetAccent("Steel"),
                ThemeManager.GetAppTheme(Theme));
        }
        public class ProfileTest
        {
            public bool Enabled { get; set; }
            public string ProfileName { get; set; }
            public string ProfilePath { get; set; }
        }
        private void Test()
        {
            
            //ProfileTest test = new ProfileTest { Enabled = true, ProfileName = "asd", ProfilePath = "asd" };
;           //dataGrid_profiles.Items.Add(test);
        }

        private void savebutton_Click(object sender, RoutedEventArgs e)
        {
            string Theme = comboBox_Theme.SelectedValue.ToString();
            UpdateSetting("theme", Theme);
            ThemeChanger(Theme);
        }
    }
}

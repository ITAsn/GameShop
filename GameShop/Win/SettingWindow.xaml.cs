using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace GameShop.Win
{
    /// <summary>
    /// Логика взаимодействия для SettingWindow.xaml
    /// </summary>
    public partial class SettingWindow : Window
    {
        public SettingWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(ipText.Text))
            App.adress = ipText.Text;
            if (!string.IsNullOrEmpty(gamePathText.Text))
            App.PCPath = gamePathText.Text;
           
        }
        bool LanCha = false;
        private void Ru_Click(object sender, RoutedEventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ru-RU");
            App.main.Canc = true;
            App.main.Close();
            MainWindow main = new MainWindow();

            LanCha = true;
            Close();
            LanCha = false;
            main.Show();
            main.sett();
          
        }

        private void En_Click(object sender, RoutedEventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-EN");
            App.main.Canc = true;
            App.main.Close();
            MainWindow main = new MainWindow();

            LanCha = true;
            Close();
            LanCha = false;
            main.Show();
            main.sett();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog folderBrowser = new OpenFileDialog();
            // Set validate names and check file exists to false otherwise windows will
            // not let you select "Folder Selection."
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            // Always default to Folder Selection.
            folderBrowser.FileName = "Folder Selection.";
            if (folderBrowser.ShowDialog() == true)
            {
                string folderPath = System.IO.Path.GetDirectoryName(folderBrowser.FileName);
                gamePathText.Text = folderPath+"\\";
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Autorization autorization = new Autorization();
            autorization.Show();

            App.user = null;
            Close();
            App.main.Canc = true;
            App.main.Close();
           

        }
    }
}

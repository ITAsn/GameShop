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
using System.Windows.Shapes;

namespace GameShop.Win
{
    /// <summary>
    /// Логика взаимодействия для Registation.xaml
    /// </summary>
    public partial class Registation : Window
    {
        public Registation()
        {
            InitializeComponent();
        }
        bool LanCha = false;
        private void Ru_Click(object sender, RoutedEventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ru-RU");
            Registation registation = new Registation();
            LanCha = true;
            Close();
            LanCha = false;
            registation.Show();

        }

        private void En_Click(object sender, RoutedEventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-EN");
            Registation registation = new Registation();
            LanCha = true;
            Close();
            LanCha = false;
            registation.Show();

        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RegistrationClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(loginText.Text) && !string.IsNullOrEmpty(passwordText.Password))
            {
                try
                {

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Properties.Resources.ResourceManager.GetString("ErrorText"), MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show(Languages.Language.ResourceManager.GetString("LogPasNotExist"), Languages.Language.ResourceManager.GetString("ErrorText"), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

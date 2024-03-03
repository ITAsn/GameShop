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
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Window
    {
        public Autorization()
        {
            InitializeComponent();
        }
        bool LanCha=false;


        private void Ru_Click(object sender, RoutedEventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ru-RU");
            Autorization autorization = new Autorization();
            LanCha = true;
            Close();
            LanCha = false;
            autorization.Show();
           
        }

        private void En_Click(object sender, RoutedEventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-EN");
            Autorization autorization = new Autorization();
            LanCha = true;
            Close();
            LanCha = false;
            autorization.Show();
          
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(loginText.Text) && !string.IsNullOrEmpty(passwordText.Password))
            {
                try
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    LanCha = true;
                    Close();
                   
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message,Properties.Resources.ResourceManager.GetString("ErrorText"),MessageBoxButton.OK ,MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show(Languages.Language.ResourceManager.GetString("LogPasNotExist"), Languages.Language.ResourceManager.GetString("ErrorText"), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!LanCha)
            {
                MessageBoxResult res = MessageBox.Show(Languages.Language.ResourceManager.GetString("ExitText"), Languages.Language.ResourceManager.GetString("QuestionText"), MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (res == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = false;
            }

        }

        private void RegistrationButton(object sender, RoutedEventArgs e)
        {
            Registation re = new Registation();
            re.ShowDialog();

        }
    }
}

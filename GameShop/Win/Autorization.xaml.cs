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
        GameShopDBEntities bd = new GameShopDBEntities();
        public Autorization()
        {
            InitializeComponent();
          //  System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-EN");
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
                   List<Users> users = bd.Users.Where(c => c.Login == loginText.Text).ToList();
                    if (users != null)
                    {
                        if (users[0].Passw == passwordText.Password)
                        {

                            App.user = users[0];
                            if(!string.IsNullOrEmpty(App.user.Games))
                            App.user.Games = App.user.Games.Trim();
                            bd.SaveChanges();
                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();
                            LanCha = true;
                           
                            Close();
                        }
                        else
                        {
                            MessageBox.Show(Languages.Language.ResourceManager.GetString("PasswordOrUserNameErrorText"), Languages.Language.ResourceManager.GetString("ErrorText"), MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show(Languages.Language.ResourceManager.GetString("PasswordOrUserNameErrorText"), Languages.Language.ResourceManager.GetString("ErrorText"), MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                
                   
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, Languages.Language.ResourceManager.GetString("ErrorText"),MessageBoxButton.OK ,MessageBoxImage.Error);
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

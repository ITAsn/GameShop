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
        GameShopDBEntities entities = new GameShopDBEntities();
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
            this.DialogResult = false;
        }

        private void RegistrationClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(loginText.Text) && !string.IsNullOrEmpty(passwordText.Password))
            {
                try
                {
                    if(!string.IsNullOrEmpty(loginText.Text)&& !string.IsNullOrEmpty(UsernNameText.Text) &&
                        !string.IsNullOrEmpty(passwordText.Password) && !string.IsNullOrEmpty(passwordText1.Password))
                    {

                        List<Users> u = entities.Users.Where(c => c.Login == loginText.Text).ToList();
                        if (u.Count == 0)
                        {
                            if (passwordText.Password == passwordText1.Password)
                            {

                           
                             Users users = new Users();
                            Random rnd = new Random();
                            int id1;
                            Users users1;
                            do
                            {
                                users1 = null;
                                id1 = rnd.Next(10000000);
                                users1 = entities.Users.Find(id1);
                            } while (users1 != null);
                            users.ID = id1;
                            users.Login = loginText.Text;
                            users.UserName = UsernNameText.Text;
                            users.Passw = passwordText1.Password;
                                entities.Users.Add(users);
                                entities.Logs.Add(new Logs
                                {
                                    IdLog=entities.Logs.ToList().Last().IdLog+1,
                                    dateTime = DateTime.Now,
                                    LogText = $"{users.Login} was created",

                                });

                                entities.SaveChanges();
                                this.DialogResult = true;

                            }
                        }
                        else
                        {
                            MessageBox.Show(Languages.Language.ResourceManager.GetString("WrongLoginText"));
                        }
                       
                        
                    }
                 

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Languages.Language.ResourceManager.GetString("ErrorText"), MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show(Languages.Language.ResourceManager.GetString("LogPasNotExist"), Languages.Language.ResourceManager.GetString("ErrorText"), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

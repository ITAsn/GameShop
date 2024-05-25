using GameShop.Frames;
using GameShop.Win;
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

namespace GameShop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int lan = 1;
        public MainWindow()
        {
            InitializeComponent();
            
            App.frame = mainFrame;
            App.main = this;
            UserName.Header = App.user.UserName;// Properties.Resources.ResourceManager.GetString("PublisherText");
        }

        private void SettingOpen(object sender, RoutedEventArgs e)
        {
            sett();
        }
       public void sett()
        {
            Win.SettingWindow settingWindow = new Win.SettingWindow();
            settingWindow.Show();
        }

        private void AboutUs(object sender, RoutedEventArgs e)
        {
            AboutUsPage aboutUsPage = new AboutUsPage();
            mainFrame.Navigate(aboutUsPage);
        }

        private void ExitButton(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Shop_Open(object sender, RoutedEventArgs e)
        {
            Shop shop = new Shop();
            mainFrame.Navigate(shop);
        }
        public bool Canc=false;
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!Canc)
            {
                MessageBoxResult res = MessageBox.Show(Languages.Language.ResourceManager.GetString("ExitText"), Languages.Language.ResourceManager.GetString("QuestionText"), MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (res == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel=false;
            }
              
            }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            object frame1 = App.frame;
            if(App.frame.NavigationService.CanGoBack)
                App.frame.GoBack();
            else
                MessageBox.Show(Languages.Language.ResourceManager.GetString("CantBackText"), Languages.Language.ResourceManager.GetString("ErrorText"), MessageBoxButton.OK, MessageBoxImage.Error);
            if (frame1 == App.frame)
            {
                Shop shop = new Shop();
                App.frame.Navigate(shop);
            }
        }

        private void LibraryOpen(object sender, RoutedEventArgs e)
        {
            Library library = new Library();
            mainFrame.Navigate(library);
        }



        private void mainFrame_Navigated(object sender, NavigationEventArgs e)
        {
          
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            GameAdd ga = new GameAdd();
            ga.ShowDialog();


        }
    }
    }


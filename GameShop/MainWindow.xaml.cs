using GameShop.Frames;
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
        public MainWindow()
        {
            InitializeComponent();
            App.frame = mainFrame;
        }

        private void SettingOpen(object sender, RoutedEventArgs e)
        {

        }

        private void AboutUs(object sender, RoutedEventArgs e)
        {

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
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
                MessageBoxResult res = MessageBox.Show(Languages.Language.ResourceManager.GetString("ExitText"), Languages.Language.ResourceManager.GetString("QuestionText"), MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (res == MessageBoxResult.No)
                {
                    e.Cancel = true;
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
    }
    }


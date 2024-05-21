using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace GameShop.Frames
{
    /// <summary>
    /// Логика взаимодействия для Library.xaml
    /// </summary>
    public partial class Library : Page
    {
        Games selectedGame;
        public Library()
        {
            InitializeComponent();
        
          
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedGame = listBox.SelectedItem as Games;
            gameName.Text = selectedGame.Name; 
            DI.Text = "Издатель: " + selectedGame.Publisher + "\nРазработчик: " + selectedGame.Developer;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FtpDownUpl ftp = new FtpDownUpl();


            ftp.Download(App.adress, "/", selectedGame.Path, App.PCPath, "Pro", "123456");

        }
    }
}

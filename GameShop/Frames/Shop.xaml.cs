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

namespace GameShop.Frames
{
    /// <summary>
    /// Логика взаимодействия для Shop.xaml
    /// </summary>
    public class Game
    {
        public int Id { get; set; }
        public  BitmapImage path { get; set; }
        public string Name { get; set; }
        public string Cost { get; set; }



    }
    public partial class Shop : Page
    {
        public Shop()
        {
            InitializeComponent();
            Game game = new Game();
            game.Id = 0;
            game.Name = "Tetris";
            game.Cost = "Cost: " + 120 + "r";
            game.path = new BitmapImage(new Uri("/Photos/noImage.png", UriKind.Relative));
            shopList1.Items.Add(game);
            Game game1 = new Game();
            game1.Id = 0;
            game1.Name = "Speed";
            game1.path = new BitmapImage(new Uri("/Photos/noImage.png", UriKind.Relative));
            game1.Cost = "Cost: " + 300 + "r";
            shopList1.Items.Add(game1);
        }

     

        private void OpenSearch(object sender, RoutedEventArgs e)
        {
            ShopSearch shopSearch = new ShopSearch();
            App.frame.Navigate(shopSearch);
        }

        private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ShopAbout shopAbout = new ShopAbout();
            App.frame.Navigate(shopAbout);
        }
    }
}

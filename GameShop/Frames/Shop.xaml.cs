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
        public  byte[] path { get; set; }
        public BitmapImage path1 { get; set; }
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
            game.Cost = "120";
            game.path1 = (new BitmapImage(new Uri("/Frames/noImage.png", UriKind.Relative)));
            shopList1.Items.Add(game);
            Game game1 = new Game();
            game1.Id = 1;
            game1.Name = "Speed";
          
            game1.path1 =(new BitmapImage(new Uri("/Frames/noImage.png", UriKind.Relative)));
            game1.Cost = "300" ;
            shopList1.Items.Add(game1);
        }
       


        private void OpenSearch(object sender, RoutedEventArgs e)
        {
            ShopSearch shopSearch = new ShopSearch();
            App.frame.Navigate(shopSearch);
        }



        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //ListBoxItem listBoxItem = new ListBoxItem();
            //Game games = shopList1.SelectedItem as Game;
            //ShopAbout shopAbout = new ShopAbout(games);
            //App.frame.Navigate(shopAbout);
        }



        private void shopList1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem listBoxItem = new ListBoxItem();
            Game games = shopList1.SelectedItem as Game;
            ShopAbout shopAbout = new ShopAbout(games);
            App.frame.Navigate(shopAbout);
        }
    }
}

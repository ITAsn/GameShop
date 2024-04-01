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
    /// Логика взаимодействия для ShopSearch.xaml
    /// </summary>
    public partial class ShopSearch : Page
    {
        public ShopSearch()
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

            game1.path1 = (new BitmapImage(new Uri("/Frames/noImage.png", UriKind.Relative)));
            game1.Cost = "300";
            shopList1.Items.Add(game1);
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

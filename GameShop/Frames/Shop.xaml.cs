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
    
    public partial class Shop : Page
    {
        GameShopDBEntities entities = new GameShopDBEntities();
        public Shop()
        {
            InitializeComponent();
            shopList1.ItemsSource = entities.Games.ToList();
           
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
            Games games = shopList1.SelectedItem as Games;
            ShopAbout shopAbout = new ShopAbout(games);
            App.frame.Navigate(shopAbout);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        GameShopDBEntities entities = new GameShopDBEntities();
        List<Games> games;
        public ShopSearch()
        {
            InitializeComponent();
            shopList1.ItemsSource = entities.Games.ToList() ;
            games = entities.Games.ToList();
        }
        private void shopList1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem listBoxItem = new ListBoxItem();
            Games games = shopList1.SelectedItem as Games;
            ShopAbout shopAbout = new ShopAbout(games);
            App.frame.Navigate(shopAbout);

        }

        private void CostBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search();
        }

        private void CostBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search();
        }

        private void CheckBox1_Click(object sender, RoutedEventArgs e)
        {
            Search();
        }
        void Search()
        {
            int c1 = 0, c2 = 99999999;
            string searchText = "";
            if (!string.IsNullOrEmpty(CostBox1.Text))
            {
                c1 = Convert.ToInt32(CostBox1.Text);
            }
            if (!string.IsNullOrEmpty(CostBox2.Text))
            {
                c2 = Convert.ToInt32(CostBox2.Text);
            }

            if (!string.IsNullOrEmpty(searchText1.Text))
            {
                searchText = searchText1.Text;
            }
            shopList1.ItemsSource = null;
            shopList1.Items.Clear();
            for (int i = 0; i < games.Count; i++)
            {
                if (games[i] != null)
                {                  
                    
                    if (games[i].Cost >= c1 && games[i].Cost <= c2 && games[i].Name.Contains(searchText))
                    {
                        Games game = games[i];
                        shopList1.Items.Add(game);
                    }
                }
            }
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }


        private void searchText1_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search();
        }
    }
}

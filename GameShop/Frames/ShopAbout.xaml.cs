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
    /// Логика взаимодействия для ShopAbout.xaml
    /// </summary>
    public partial class ShopAbout : Page
    {
        Game game;
        public ShopAbout(Game game)
        {
            InitializeComponent();
            this.game = game;
            nameText.Text = game.Name;
            costText.Text = game.Cost + " руб.";
            if (game.path != null)
            {
                imageBox.Source = App.ByteToImage(game.path);
            }
           
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

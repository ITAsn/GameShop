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
           
            D1Text.Text = "Объем диска: " + game.D1;
            CP1Text.Text = "ЦП:" + game.CP1;
            OP1Text.Text = "Оперативная память: " + game.OP1;
            GPD1Text.Text = "Видеокарта: " + game.GPD1;
            D2Text.Text = "Объем диска: " + game.D2;
            CP2Text.Text = "ЦП:" + game.CP2;
            OP2Text.Text = "Оперативная память: " + game.OP2;
            GPD2Text.Text = "Видеокарта: " + game.GPD2;
            DI.Text = "Издатель: " + game.Publisher + "\nРазработчик: " + game.Developer;

        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

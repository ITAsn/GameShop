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
        GameShopDBEntities entities = new GameShopDBEntities();
        Games gamePage;
        public ShopAbout(Games game)
        {
            InitializeComponent();
            gamePage = game;
            nameText.Text = game.Name;
            costText.Text = game.Cost.ToString() ;
            descriptionText.Text = game.Description;
            CP1Text.Text = game.CP1;
            OP1Text.Text = game.OP1;
            GPD1Text.Text = game.GPD1;
            D1Text.Text = game.D1;

            CP2Text.Text = game.CP2;
            OP2Text.Text = game.OP2;
            GPD2Text.Text = game.GDP2;
            D2Text.Text = game.D2;

        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            Logs logs = entities.Logs.ToList().Last();
            entities.Logs.Add(new Logs
            {
                IdLog = logs.IdLog+1,
                LogText = $"{App.user.Login} bought {gamePage.ID}",
                dateTime = DateTime.Now
            }) ;
            Users user=entities.Users.Find(App.user.ID);
            user.Games += gamePage.ID + ";";
            entities.SaveChanges();
            MessageBox.Show("You bought this game!!!");
        }
    }
}

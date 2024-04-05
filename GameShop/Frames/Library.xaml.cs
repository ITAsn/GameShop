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
    /// Логика взаимодействия для Library.xaml
    /// </summary>
    public partial class Library : Page
    {
        public Library()
        {
            InitializeComponent();
        
            Game game = new Game();
            game.Id = 0;
            game.Name = "Tetris";
            game.Cost = "120";
            game.Descrition = "Cool game for everyone!";
            game.CP1 = "Intel Atom"; game.D1 = "100 MB"; game.OP1 = "50 MB"; game.GPD1 = "------";
            game.CP2 = "Intel Atom"; game.D2 = "100 MB"; game.OP2 = "50 MB"; game.GPD2 = "------";
            game.path1 = (new BitmapImage(new Uri("/Frames/noImage.png", UriKind.Relative)));
            listBox.Items.Add(game);
            Game game1 = new Game();
            game1.Id = 1;
            game1.Name = "Speed";
            game1.CP1 = "Intel Atom"; game1.D1 = "100 MB"; game1.OP1 = "50 MB"; game1.GPD1 = "------";
            game1.CP2 = "Intel Atom"; game1.D2 = "100 MB"; game1.OP2 = "50 MB"; game1.GPD2 = "------";
            game1.Descrition = "Good race for this time!";
            game1.path1 = (new BitmapImage(new Uri("/Frames/noImage.png", UriKind.Relative)));
            game1.Cost = "300";
            listBox.Items.Add(game1);
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Game game = listBox.SelectedItem as Game;
            ima.Source = game.path1;
            gameName.Text = game.Name;
            DescriptionText.Text = game.Descrition;
            D1Text.Text ="Объем диска: "+ game.D1;
            CP1Text.Text = "ЦП:" + game.CP1;
            OP1Text.Text = "Оперативная память: "+ game.OP1;
            GPD1Text.Text ="Видеокарта: "+ game.GPD1;
            D2Text.Text = "Объем диска: " + game.D2;
            CP2Text.Text = "ЦП:" + game.CP2;
            OP2Text.Text = "Оперативная память: " + game.OP2;
            GPD2Text.Text = "Видеокарта: " + game.GPD2;
            DI.Text = "Издатель: " + game.Publisher+"\nРазработчик: "+game.Developer;
        }
    }
}

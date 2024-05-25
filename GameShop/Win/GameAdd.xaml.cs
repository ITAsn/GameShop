using Microsoft.Win32;
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
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace GameShop.Win
{
    /// <summary>
    /// Логика взаимодействия для GameAdd.xaml
    /// </summary>
    public partial class GameAdd : Window
    {
        public GameAdd()
        {
            InitializeComponent();
            publisherTextBox.ItemsSource = entities.Publishers.ToList();
            developerTextBox.ItemsSource = entities.Developers.ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            GameShop.GameShopDBDataSet gameShopDBDataSet = ((GameShop.GameShopDBDataSet)(this.FindResource("gameShopDBDataSet")));
            // Загрузить данные в таблицу Games. Можно изменить этот код как требуется.
            GameShop.GameShopDBDataSetTableAdapters.GamesTableAdapter gameShopDBDataSetGamesTableAdapter = new GameShop.GameShopDBDataSetTableAdapters.GamesTableAdapter();
            gameShopDBDataSetGamesTableAdapter.Fill(gameShopDBDataSet.Games);
            System.Windows.Data.CollectionViewSource gamesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("gamesViewSource")));
            gamesViewSource.View.MoveCurrentToFirst();
        }
        byte[] image_bytes;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog(); // создаем диалоговое окно
            openFileDialog.ShowDialog(); // показываем
          image_bytes = File.ReadAllBytes(openFileDialog.FileName); // получаем байты выбранного файла

            MemoryStream byteStream = new MemoryStream(image_bytes);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = byteStream;
            image.EndInit();
            iamgeI.Source = image;

        }
        GameShopDBEntities entities = new GameShopDBEntities();
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Games games = new Games
            {
                ID=Convert.ToInt32(iDTextBox.Text),
                Name = nameTextBox.Text,
                Path = pathTextBox.Text,
                Cost = Convert.ToInt32(costTextBox.Text),
                Description = descriptionTextBox.Text,
                Publisher = publisherTextBox.SelectedIndex,
                Developer=developerTextBox.SelectedIndex,
                CP1=cP1TextBox.Text,
                CP2=cP2TextBox.Text,
                OP1=oP1TextBox.Text,
                OP2=oP2TextBox.Text,
                GPD1=gPD1TextBox.Text,
                GDP2=gDP2TextBox.Text,
                D1=d1TextBox.Text,
                D2=d2TextBox.Text,
                Image= image_bytes

        };
            try
            {
                entities.Games.Add(games);
                entities.SaveChanges();
                DialogResult = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}

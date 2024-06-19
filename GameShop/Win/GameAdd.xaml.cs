using GameShop.Frames;
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
            if (!string.IsNullOrEmpty(openFileDialog.FileName))
            {
                image_bytes = File.ReadAllBytes(openFileDialog.FileName); // получаем байты выбранного файла

                MemoryStream byteStream = new MemoryStream(image_bytes);
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = byteStream;
                image.EndInit();
                iamgeI.Source = image;
            }
       

        }
        GameShopDBEntities entities = new GameShopDBEntities();
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int id1 = entities.Games.ToList().Last().ID + 1;
            string[] paths = pathTextBox.Text.Split('\\');
            string path = paths[paths.Length - 1];
            Games games = new Games
            {
                ID=id1,
                Name = nameTextBox.Text,
                Path = path,
                Cost = 0,
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
                Shop shop = new Shop();
                App.frame.Navigate(shop);
                FtpDownUpl ftpDownUpl = new FtpDownUpl();
                string FTPServer = App.adress;
                string remotePath = "/";
             //   string fileNameToUpload = selectedGame.Path;
                string saveToLocalPath = App.PCPath;
                string user = "Pro";
                string password = "123456";
                ftpDownUpl.Upload(FTPServer, remotePath,pathTextBox.Text,user,password );
                MessageBox.Show("Ready");
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

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            OpenFileDialog folderBrowser = new OpenFileDialog();
            // Set validate names and check file exists to false otherwise windows will
            // not let you select "Folder Selection."
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            // Always default to Folder Selection.
            folderBrowser.FileName = "Folder Selection.";
            if (folderBrowser.ShowDialog() == true)
            {
                string folderPath = System.IO.Path.GetFullPath(folderBrowser.FileName);
                pathTextBox.Text = folderPath ;
            }
        }

        private void Add_Developer(object sender, RoutedEventArgs e)
        {
            SomeAdd someAdd = new SomeAdd(true);
            
            someAdd.ShowDialog();
            if (someAdd.DialogResult==true)
            {
                publisherTextBox.ItemsSource = null;
                developerTextBox.ItemsSource = null;
                publisherTextBox.Items.Clear();
                developerTextBox.Items.Clear();
                publisherTextBox.ItemsSource = entities.Publishers.ToList();
                developerTextBox.ItemsSource = entities.Developers.ToList();
            }
            else
            {

            }
        }

        private void Add_Publisher(object sender, RoutedEventArgs e)
        {
            SomeAdd someAdd = new SomeAdd(false);
            someAdd.ShowDialog();
            if (someAdd.DialogResult == true)
            {
                publisherTextBox.ItemsSource = null;
                developerTextBox.ItemsSource = null;
                publisherTextBox.Items.Clear();
                developerTextBox.Items.Clear();
                publisherTextBox.ItemsSource = entities.Publishers.ToList();
                developerTextBox.ItemsSource = entities.Developers.ToList();
            }
            else
            {

            }
        }
    }
}

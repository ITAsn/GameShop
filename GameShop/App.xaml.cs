using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace GameShop
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static System.Windows.Controls.Frame frame = new System.Windows.Controls.Frame();
        public static ImageSource ByteToImage(byte[] imageData)// Conveter SQL Image to WPF image
        {
            var bitmap = new BitmapImage();
            MemoryStream ms = new MemoryStream(imageData);
            bitmap.BeginInit();
            bitmap.StreamSource = ms;
            bitmap.EndInit();

            return (ImageSource)bitmap;
        }
        public static Users user;
        public static String adress= "127.0.0.1:21";//IP FTP server
        public static String PCPath = "C:\\Program Files";//Way for games
        public static MainWindow main;
        App()
        {

        }
      
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
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
using System.Threading;
using System.Net.NetworkInformation;
using Microsoft.Toolkit.Uwp.Notifications;
using System.IO.Compression;
using Windows.UI.Xaml.Shapes;
namespace GameShop.Frames
{
    /// <summary>
    /// Логика взаимодействия для Library.xaml
    /// </summary>
    public partial class Library : Page
    {

        GameShopDBEntities entities = new GameShopDBEntities();
        Games selectedGame;
        Thread myThread;
        public Library()
        {
            InitializeComponent();
            myThread = new Thread(downloadF);
            if (!string.IsNullOrEmpty(App.user.Games))
            {
                string[] games = App.user.Games.Split(';');

                List<Games> gamesSQL = new List<Games>();
                for (int i = 0; games.Length > i; i++)
                {
                    if (!string.IsNullOrEmpty(games[i]))
                        gamesSQL.Add(entities.Games.Find(Convert.ToInt32(games[i])));
                }
                listBox.ItemsSource = gamesSQL;
            }
      
          //  buttDow.IsEnabled = true;

        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            buttDow.IsEnabled = true;
            selectedGame = listBox.SelectedItem as Games;
            MemoryStream byteStream = new MemoryStream(selectedGame.Image);
            BitmapImage image1 = new BitmapImage();
            image1.BeginInit();
            image1.StreamSource = byteStream;
            image1.EndInit();
            ima.Source = image1;
            // buttDow.IsEnabled = true;
            gameName.Text = selectedGame.Name; 
            DI.Text = Languages.Language.ResourceManager.GetString("PublisherText") + selectedGame.Publishers.PublisherName + "\n"+ Languages.Language.ResourceManager.GetString("DeveloperText") + selectedGame.Developers.DeveloperName;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //FtpDownUpl ftp = new FtpDownUpl();


            //ftp.Download(App.adress, "/", selectedGame.Path, App.PCPath, "Pro", "123456");
            myThread.Start();
        }
        void downloadF()
        {
            buttDow.IsEnabled = false;
            string FTPServer = App.adress;
            string remotePath = "/";
            string fileNameToDownload = selectedGame.Path;
            string saveToLocalPath = App.PCPath;
            string user = "Pro";
            string password = "123456";
            try
            {
                FtpWebRequest request1 = (FtpWebRequest)FtpWebRequest.Create(new Uri(@"ftp://" + FTPServer + @"/" + remotePath + @"/" + fileNameToDownload));
                request1.Proxy = null;
              
                if (!string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(password))
                    request1.Credentials = new NetworkCredential(user, password);

                request1.Method = WebRequestMethods.Ftp.GetFileSize;
                FtpWebResponse response1 = (FtpWebResponse)request1.GetResponse();
                double size = response1.ContentLength;
                response1.Close();
                //Get FTP web resquest object.
                FtpWebRequest request = FtpWebRequest.Create(new Uri(@"ftp://" + FTPServer + @"/" + remotePath + @"/" + fileNameToDownload)) as FtpWebRequest;
                request.UseBinary = true;
                request.KeepAlive = false;
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                if (!string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(password))
                    request.Credentials = new NetworkCredential(user, password);
                
                FtpWebResponse response = request.GetResponse() as FtpWebResponse;

                Stream responseStream = response.GetResponseStream();
                FileStream outputStream = new FileStream(saveToLocalPath + "\\" + fileNameToDownload, FileMode.Create);
               

                int bufferSize = 10240;
                int readCount;
                byte[] buffer = new byte[bufferSize]; 
                string rSize = "";
                float size1 = (float)size;
                if (size / 1024 > 1)
                {
                    if (size / 1024 / 1024 > 1)
                    {
                        if (size / 1024 / 1024 / 1024 > 1)
                        {
                            
                            size = Math.Round((size / 1024 / 1024 / 1024),2);
                            rSize = size.ToString() + "GB";

                        }
                        else
                        {
                            size = Math.Round((size / 1024 / 1024),2);
                            rSize = size.ToString() + " MB";
                        }
                    }
                    else
                    {
                        size = Math.Round((size / 1024),2);
                        rSize = size.ToString() + "KB";
                    }
                }
                else
                {

                    rSize = size.ToString() + "B";
                }
               
                
                readCount = responseStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = responseStream.Read(buffer, 0, bufferSize);
                    this.Dispatcher.Invoke(() =>
                    {
                        double position =Convert.ToDouble(outputStream.Position);
                        var position1 = (outputStream.Position);
                        if (position / 1024 > 1)
                        {
                            if (position / 1024 / 1024 > 1)
                            {
                                if (position / 1024 / 1024/1024  > 1)
                                {
                                    position = Math.Round((position / 1024 / 1024/1024),2);
                                    App.main.prog.Text = position.ToString() + "GB"+$"/{rSize}";

                                }
                                else
                                {
                                    position = Math.Round((position / 1024 / 1024),2);
                                    App.main.prog.Text = position.ToString() + " MB" + $"/{rSize}";
                                }
                            }
                            else
                            {
                                position = Math.Round((position / 1024),2);
                                App.main.prog.Text = position.ToString() + "KB" + $"/{rSize}";
                            }
                        }
                        else
                        {
                            
                            App.main.prog.Text = position.ToString() + "B" + $"/{rSize}";
                        }
                        App.main.progressBar1.Maximum = size1;
                        App.main.progressBar1.Value = position1;
                        // App.main.prog.Text = position.ToString();
                     
                    });
                  
                }
                string statusDescription = response.StatusDescription;
                responseStream.Close();
                outputStream.Close();
                response.Close();
                //try
                //{
                //    // DirectoryInfo di = Directory.CreateDirectory(saveToLocalPath+"\\"+ fileNameToDownload.Remove(fileNameToDownload.Length-4));

                    
                //    //saveToLocalPath + @"\" + fileNameToDownload.Remove(fileNameToDownload.Length - 4) ;
                //    ZipFile.ExtractToDirectory("C:\\Users\\AlFredo\\Desktop\\projects c\\GameShop\\GameShop\\bin\\Debug" + "\\" + fileNameToDownload.Remove(fileNameToDownload.Length - 4), saveToLocalPath+"\\"+fileNameToDownload
                //    );
                //}
                //catch
                //{

                //}
             
                new ToastContentBuilder().AddArgument("action", "viewConversation").AddArgument("conversationId",9813).AddText(selectedGame.Name).AddText(Languages.Language.ResourceManager.GetString("DownloadCText")).Show();

            }
            catch (Exception xe)
            {
                throw new Exception("Error downloading from URL " + "ftp://" + FTPServer + @"/" + remotePath + @"/" + fileNameToDownload, xe);
            }
            buttDow.IsEnabled = true;
        }
        
    }
}

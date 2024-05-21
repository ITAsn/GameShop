using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GameShop
{
    class FtpDownUpl
    {
        public string Upload(string FTPServer, string remotePath, string fileToUpload, string user, string password)
        {
            try
            {
                //Get FTP web resquest object.
                FtpWebRequest request = FtpWebRequest.Create(new Uri(@"ftp://" + FTPServer + @"/" + remotePath + @"/" + System.IO.Path.GetFileName(fileToUpload))) as FtpWebRequest;
                request.UseBinary = true;
                request.KeepAlive = false;
                request.Method = WebRequestMethods.Ftp.UploadFile;
                if (!string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(password))
                    request.Credentials = new NetworkCredential(user, password);

                //Get physical file
                FileInfo fi = new FileInfo(fileToUpload);
                Byte[] contents = new Byte[fi.Length];

                //Read file
                FileStream fs = fi.OpenRead();
                fs.Read(contents, 0, Convert.ToInt32(fi.Length));
                fs.Close();

                //Write file contents to FTP server
                Stream rs = request.GetRequestStream();
                rs.Write(contents, 0, Convert.ToInt32(fi.Length));
                rs.Close();

                FtpWebResponse response = request.GetResponse() as FtpWebResponse;
                string statusDescription = response.StatusDescription;
                response.Close();
                return statusDescription;
            }
            catch (Exception e)
            {
                throw new Exception("Error uploading to URL " + "ftp://" + FTPServer + @"/" + remotePath + @"/" + System.IO.Path.GetFileName(fileToUpload), e);
            }
        }

        public string Download(string FTPServer, string remotePath, string fileNameToDownload, string saveToLocalPath, string user, string password)
        {
            try
            {
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


                int bufferSize = 1024;
                int readCount;
                byte[] buffer = new byte[bufferSize];

                readCount = responseStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = responseStream.Read(buffer, 0, bufferSize);
                }
                string statusDescription = response.StatusDescription;
                responseStream.Close();
                outputStream.Close();
                response.Close();
                return statusDescription;
            }
            catch (Exception e)
            {
                throw new Exception("Error downloading from URL " + "ftp://" + FTPServer + @"/" + remotePath + @"/" + fileNameToDownload, e);
            }
        }


    }
}

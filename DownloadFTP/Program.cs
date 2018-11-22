using System;
using System.IO;
using System.Net;
using System.Text;


namespace DownloadFTP
{
    class Program
    {
        static string url = "Enter your server details";
        static string username = @"Enter your details";
        static string password = "Enter your details";
        static void Main(string[] args)
        {
            string output = "";

            Console.WriteLine("Enter path for .text file on the server  without extension : after BDAT1001-nital/");

            // Get the object used to communicate with the server.
            string filename = Console.ReadLine(); //create file on FTP
            if (filename == null || filename == "")
            {
                filename = "nital";
            }
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url + filename + ".txt");
            
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential(username, password);

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            Console.WriteLine(reader.ReadToEnd());

            Console.WriteLine($"Download Complete, status {response.StatusDescription}");
            Console.WriteLine("Please press any key to exit.");
            Console.ReadLine();
            reader.Close();
            response.Close();
        }
    }
}

using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Core
{
    public class Downloader
    {
        private const string UrlHost = @"http://cn.bing.com";
        private const string FileName = @"D:\Desktop\HelloWorld.jpg";
        private const string ImageArchive = @"http://www.bing.com/HPImageArchive.aspx?format=js&idx=0&n=1&mkt=zh-CN";

        private static Uri Url
        {
            get
            {
                var request = (HttpWebRequest)WebRequest.Create(ImageArchive);
                var response = request.GetResponse();
                var streamData = response.GetResponseStream() ?? new MemoryStream();
                var data = new StreamReader(streamData).ReadToEnd();
                var obj = JsonConvert.DeserializeObject<dynamic>(data);
                string urlBase = obj.images[0].urlbase;

                var urlStringBuilder = new StringBuilder();
                urlStringBuilder.AppendFormat("{0}{1}_{2}x{3}.jpg", UrlHost, urlBase, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

                return new Uri(urlStringBuilder.ToString());
            }
        }

        public async void Do()
        {
            await Task.Run(() =>
            {
                new WebClient().DownloadFile(Url, FileName);
                Console.WriteLine("Downloading thread " + Thread.CurrentThread.ManagedThreadId);
            });
        }
    }
}

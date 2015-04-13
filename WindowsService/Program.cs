using System;
using System.ServiceProcess;
using System.Threading;
using Core;
using Timer = System.Timers.Timer;

namespace WindowsService1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static void Main()
        {
            if (true)
            {
                const string fileName = @"D:\Desktop\HelloWorld.jpg";
                var timer = new Timer(10000);
                timer.Elapsed += (sender, e) => new WallpaperHandler().SetWallpaper(fileName);
                timer.Enabled = true;
                new WallpaperHandler().SetWallpaper(fileName);
                ServiceBase.Run(new Service());
            }
            else
            {
                Console.WriteLine("Begin thread " + Thread.CurrentThread.ManagedThreadId);
                new Downloader().Do();
                Console.WriteLine("End thread " + Thread.CurrentThread.ManagedThreadId);
                while (true) { }
            }
        }
    }
}

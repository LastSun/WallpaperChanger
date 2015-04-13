using System;
using System.Threading;
using Core;

namespace ConsoleApplication1
{
    class Program
    {
        private const string FileName = @"D:\Desktop\HelloWorld.jpg";

        private static void Main(string[] args)
        {
            Console.WriteLine("Main " + Thread.CurrentThread.ManagedThreadId);
            TestA();
            var i = 0;
            while (i++ < 1000000000)
            {
                if (i != 100000000) continue;
                Console.Write("." + Thread.CurrentThread.ManagedThreadId);
                i = 0;
            }
        }

        private static void TestA()
        {
            Console.WriteLine("Begin downloading " + Thread.CurrentThread.ManagedThreadId);
            new Downloader().Do();
            Console.WriteLine("End downloading and begin set wallpaper " + Thread.CurrentThread.ManagedThreadId);
            new WallpaperHandler().SetWallpaper(FileName);
            Console.WriteLine("End set wallpaper " + Thread.CurrentThread.ManagedThreadId);
        }
    }
}
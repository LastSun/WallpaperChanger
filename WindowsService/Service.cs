using System;
using System.ServiceProcess;
using System.Threading;
using Core;
using Timer = System.Timers.Timer;

namespace WindowsService1
{
    public partial class Service : ServiceBase
    {
        public Service()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Console.WriteLine("Begin thread " + Thread.CurrentThread.ManagedThreadId);
            var timer = new Timer(10000);
            timer.Elapsed += (sender, e) => new Downloader().Do();
            timer.Enabled = true;
            Console.WriteLine("End thread " + Thread.CurrentThread.ManagedThreadId);
        }

        protected override void OnStop()
        {
        }
    }
}

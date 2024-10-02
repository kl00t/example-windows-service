using Example.Application;
using System;
using System.ServiceProcess;
using System.Timers;

namespace Example.WindowsService
{
    public partial class SomeService : ServiceBase
    {
        private readonly Timer _timer;
        private readonly ISomeApplication _someApplication;

        public SomeService(ISomeApplication someApplication)
        {
            _someApplication = someApplication ?? throw new ArgumentNullException(nameof(someApplication));

            InitializeComponent();
            _timer = new Timer
            {
                AutoReset = false, 
                Enabled = false, 
                Interval = 1 * 1000
            };

            _timer.Elapsed += OnTimerElapsed;
        }

        public void StartConsole(string[] args)
        {
            OnStart(args);
        }

        public void StopConsole()
        {
            OnStop();
        }

        protected override void OnStart(string[] args)
        {
            _timer.Start();
            var dateTime = _someApplication.OutputDateTime();
            Console.WriteLine(dateTime);
        }
 
        protected override void OnStop()
        {
            _timer.Stop();

            var dateTime = _someApplication.OutputDateTime();
            Console.WriteLine(dateTime);
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            _timer.Start();

            var dateTime = _someApplication.OutputDateTime();
            Console.WriteLine(dateTime);
        }
    }
}

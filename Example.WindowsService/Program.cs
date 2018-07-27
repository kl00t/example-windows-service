using System;
using System.ServiceProcess;
using Example.Application;
using Ninject;

namespace Example.WindowsService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(new SomeServiceModule());
            var someApplication = kernel.Get<ISomeApplication>();

            try
            {
                var mailerService = new SomeService(someApplication);
                if (Environment.UserInteractive)
                {
                    mailerService.StartConsole(args);
                    Console.Read();
                    mailerService.StopConsole();
                }
                else
                {
                    ServiceBase.Run(mailerService);
                }
            }
            catch (Exception exception)
            {
                if (Environment.UserInteractive)
                {
                    Console.WriteLine(exception);
                    Console.Read();
                }
            }
        }
    }
}

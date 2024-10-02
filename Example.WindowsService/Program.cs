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
                var someService = new SomeService(someApplication);
                if (Environment.UserInteractive)
                {
                    someService.StartConsole(args);
                    Console.Read();
                    someService.StopConsole();
                }
                else
                {
                    ServiceBase.Run(someService);
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

using Example.Application;
using Ninject.Modules;

namespace Example.WindowsService
{
    public class SomeServiceModule : NinjectModule
    {
        /// <inheritdoc />
        /// <summary>Loads the module into the kernel.</summary>
        public override void Load()
        {
            Bind<ISomeApplication>().To<SomeApplication>();
        }
    }
}

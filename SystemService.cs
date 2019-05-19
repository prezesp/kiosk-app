using Autofac;
using KioskApp.Utils.Printing;

namespace KioskApp
{
    public class SystemService
    {
        private readonly IContainer _container;

        public SystemService(IContainer container) 
        {
            this._container = container;
        }

        public T GetPrinter<T>() where T : IPrinter
        {
            return (T) this._container.Resolve<T>();
        }
    }
}

using System;
using Autofac;
using Avalonia;
using Avalonia.Logging.Serilog;
using KioskApp.Utils;
using KioskApp.Utils.Printing;

namespace KioskApp
{
    class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        public static void Main(string[] args) => BuildAvaloniaApp().Start(AppMain, args);

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToDebug();

        // Your application's entry point. Here you can initialize your MVVM framework, DI
        // container, etc.
        private static void AppMain(Application app, string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DummyPrinter>().As<IPrinter>();
            builder.RegisterType<DummyPrinter>().As<IPrinter>();
            builder.RegisterType<SystemService>().As<SystemService>();
            var container = builder.Build();

            // Register container itself
            var builder2 = new ContainerBuilder();
            builder2.RegisterInstance<IContainer>(container);
            builder2.Update(container);

            using (var scope = container.BeginLifetimeScope()) 
            {
                var main = new MainWindow(scope.Resolve<SystemService>());
                app.Run(main);
            }
        }
    }
}

using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.Configuration;
using Octopanel_POC.Core.Octoprint;
using Octopanel_POC.Core.Registration;
using Splat;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Octopanel_POC
{
    public class App : Application
    {

        private readonly IConfigurationRoot _configurationRoot;
        private Assembly _panelsAssembly;

        public App()
        {
            _configurationRoot = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
        }

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void RegisterServices()
        {
            base.RegisterServices();

            Locator.CurrentMutable.RegisterConstant(new OctoprintClient(), typeof(IOctoprintClient));

            _panelsAssembly = Assembly.Load(_configurationRoot["AppSettings:PanelsAssemblyName"]);
            var serviceRegistrations = _panelsAssembly.GetTypes()
                .Where(x => typeof(IServiceRegistration).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).ToList();
            foreach (var curReg in serviceRegistrations)
            {
                var regInstance = (IServiceRegistration)Activator.CreateInstance(curReg);
                regInstance.Register(Locator.CurrentMutable);
            }
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var splashPanelType = _panelsAssembly.GetType(_configurationRoot["AppSettings:SplashPanelType"]);
                desktop.MainWindow = (Avalonia.Controls.Window)Activator.CreateInstance(splashPanelType);
            }
            base.OnFrameworkInitializationCompleted();
        }
    }
}

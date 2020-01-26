using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Octopanel_POC.Core.Octoprint;
using Octopanel_POC.Core.Registration;
using Octopanel_POC.Core.UI;
using Splat;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Octopanel_POC
{
    public class App : Application
    {

        private readonly IConfigurationRoot _configuration;
        private IUiConfigLoader _uiConfigLoader;

        public App()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
        }

        private void LoadUiConfig()
        {
            _uiConfigLoader = Locator.Current.GetService<IUiConfigLoader>();
            var uiConfigPath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "uiconfig.json");
            _uiConfigLoader.Load(uiConfigPath);
        }

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void RegisterServices()
        {
            base.RegisterServices();

            Locator.CurrentMutable.RegisterConstant(new OctoprintClient(), typeof(IOctoprintClient));
            Locator.CurrentMutable.RegisterConstant(new UiConfigLoader(), typeof(IUiConfigLoader));

            LoadUiConfig();
        }

        public override void OnFrameworkInitializationCompleted()
        {          
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = _uiConfigLoader.LoadPanel("splash");
            }
            base.OnFrameworkInitializationCompleted();
        }
    }
}

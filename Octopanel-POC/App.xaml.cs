using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.Configuration;
using Octopanel_POC.Core.Config;
using Octopanel_POC.Core.Models;
using Octopanel_POC.Core.Octoprint;
using Octopanel_POC.Core.UI;
using Octopanel_POC.Views;
using Splat;
using System.IO;

namespace Octopanel_POC
{
    public class App : Application
    {

        private readonly IConfigurationRoot _configuration;
        private IUiConfigLoaderService _uiConfigLoader;
        private Main _main;

        public Main Main
        {
            get
            {
                if(_main == null)
                {
                    _main = new Main();
                }
                return _main;
            }
        }

        public App()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true)
                .AddEnvironmentVariables()
                .Build();
        }

        private void LoadUiConfig()
        {
            _uiConfigLoader = Locator.Current.GetService<IUiConfigLoaderService>();
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

            Locator.CurrentMutable.RegisterConstant(new AppSettingsService(), typeof(IAppSettingsService));
            Locator.CurrentMutable.RegisterConstant(new OctoprintClientService(), typeof(IOctoprintClientService));
            Locator.CurrentMutable.RegisterConstant(new OctoprintClientUpdaterService(), typeof(IOctoprintClientUpdaterService));
            Locator.CurrentMutable.RegisterConstant(new UiConfigLoaderService(), typeof(IUiConfigLoaderService));
            Locator.CurrentMutable.RegisterConstant(new Navigator(), typeof(INavigator));
            Locator.CurrentMutable.RegisterConstant(new Context(), typeof(IContext));

            LoadUiConfig();
        }

        public override void OnFrameworkInitializationCompleted()
        {          
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = Main;
            }
            base.OnFrameworkInitializationCompleted();
        }
    }
}

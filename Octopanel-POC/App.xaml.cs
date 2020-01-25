using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Octopanel_POC.Octoprint;
using Octopanel_POC.ViewModels;
using Octopanel_POC.Views;
using Splat;

namespace Octopanel_POC
{
    public class App : Application
    {

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void RegisterServices()
        {
            base.RegisterServices();

            Locator.CurrentMutable.RegisterConstant(new OctoprintClient(), typeof(IOctoprintClient));

            Locator.CurrentMutable.Register(() => new MainWindowViewModel("Hello World!"), typeof(IMainWindowViewModel));
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow();
            }
            base.OnFrameworkInitializationCompleted();
        }
    }
}

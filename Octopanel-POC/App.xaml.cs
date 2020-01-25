using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Octopanel_POC.Core.Octoprint;
using Octopanel_POC.Core.Registration;
using Octopanel_POC.Panels.Home;
using Octopanel_POC.Panels.ViewModels;
using Splat;
using System;
using System.Linq;
using System.Reflection;

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

            var panelsAssembly = Assembly.Load("Octopanel-POC.Panels");
            var serviceRegistrations = panelsAssembly.GetTypes()
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
                //set home panel
                desktop.MainWindow = new HomePanel();
            }
            base.OnFrameworkInitializationCompleted();
        }
    }
}

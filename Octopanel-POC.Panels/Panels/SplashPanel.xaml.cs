using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Octopanel_POC.Core.ViewModels;
using Octopanel_POC.Panels.ViewModels;
using ReactiveUI;
using Splat;

namespace Octopanel_POC.Panels.Panels
{
    public class SplashPanel : ReactiveWindow<ISplashPanelViewModel>
    {
        public SplashPanel()
        {
            this.InitializeComponent();
            var viewModel = Locator.Current.GetService(this.GetType().BaseType.GetGenericArguments()[0]);
            DataContext = viewModel;

#if DEBUG
            this.AttachDevTools();
#endif

            this.WhenActivated(disposableRegistration =>
            {

            });
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}

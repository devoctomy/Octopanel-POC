using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Octopanel_POC.Panels.ViewModels;
using Splat;

namespace Octopanel_POC.Panels.Views
{
    public class Splash : Window
    {
        public Splash()
        {
            this.InitializeComponent();
            DataContext = Locator.Current.GetService<ISplashPanelViewModel>();

#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}

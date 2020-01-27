using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Octopanel_POC.Panels.ViewModels;
using Splat;

namespace Octopanel_POC.Panels.Views
{
    public class Splash : UserControl
    {
        public Splash()
        {
            this.InitializeComponent();
            DataContext = Locator.Current.GetService<ISplashPanelViewModel>();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}

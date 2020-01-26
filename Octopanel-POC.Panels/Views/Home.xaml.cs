using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Octopanel_POC.Panels.ViewModels;
using Splat;

namespace Octopanel_POC.Panels.Views
{
    public class Home : Window
    {
        public Home()
        {
            this.InitializeComponent();
            DataContext = Locator.Current.GetService<IHomePanelViewModel>();

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

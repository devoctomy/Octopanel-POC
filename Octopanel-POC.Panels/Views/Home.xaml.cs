using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Octopanel_POC.Panels.ViewModels;
using Splat;

namespace Octopanel_POC.Panels.Views
{
    public class Home : UserControl
    {
        public Home()
        {
            this.InitializeComponent();
            DataContext = Locator.Current.GetService<IHomePanelViewModel>();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}

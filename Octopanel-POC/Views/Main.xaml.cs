using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Octopanel_POC.Core.UI;
using Splat;

namespace Octopanel_POC.Views
{
    public class Main : Window
    {
        private IUiConfigLoaderService _uiConfigLoader;
        private INavigator _navigator;

        public Main()
        {
            this.InitializeComponent();
            _uiConfigLoader = Locator.Current.GetService<IUiConfigLoaderService>();
            _navigator = Locator.Current.GetService<INavigator>();

#if DEBUG
            this.AttachDevTools();
#endif

            this.Activated += Main_Activated;
        }

        private void Main_Activated(object sender, System.EventArgs e)
        {
            var panelHost = this.FindControl<Grid>("PanelHost");          
            var panel = _navigator.ChangePage("splash");
            panel.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Stretch;
            panel.VerticalAlignment = Avalonia.Layout.VerticalAlignment.Stretch;
            panelHost.Children.Add(panel);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}

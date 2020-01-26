using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Octopanel_POC.Panels.ViewModels;
using Splat;
using System.Threading;

namespace Octopanel_POC.Panels.Panels
{
    public class SplashPanel : Window
    {
        public SplashPanel()
        {
            this.InitializeComponent();
            DataContext = Locator.Current.GetService<ISplashPanelViewModel>();

#if DEBUG
            this.AttachDevTools();
#endif

            var pop = this.FindControl<Button>("ARSE");
            pop.Click += Pop_Click;
        }

        private async void Pop_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var pop = await ((ISplashPanelViewModel)DataContext).Context.OctoprintClient.GetVersionAsync(CancellationToken.None);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}

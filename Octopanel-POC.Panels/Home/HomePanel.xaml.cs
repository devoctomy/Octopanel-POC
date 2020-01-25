using Avalonia;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Octopanel_POC.Panels.ViewModels;
using ReactiveUI;
using Splat;

namespace Octopanel_POC.Panels.Home
{
    public class HomePanel : ReactiveWindow<IHomePanelViewModel>
    {
        public HomePanel()
        {
            this.InitializeComponent();
            DataContext = Locator.Current.GetService(this.GetType().BaseType.GetGenericArguments()[0]);

#if DEBUG
            this.AttachDevTools();
#endif

            this.WhenActivated(disposableRegistration =>
            {
                WindowStartupLocation = Avalonia.Controls.WindowStartupLocation.CenterScreen;

                //view model is initialised by this point
                //add binding here
            });
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}

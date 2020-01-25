using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Octopanel_POC.Octoprint;
using Octopanel_POC.ViewModels;
using ReactiveUI;
using Splat;
using System;

namespace Octopanel_POC.Views
{
    public class MainWindow : ReactiveWindow<IMainWindowViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = Locator.Current.GetService(this.GetType().BaseType.GetGenericArguments()[0]);

#if DEBUG
            this.AttachDevTools();
#endif

            this.WhenActivated(disposableRegistration =>
            {
                //view model is initialised by this point
                //add binding here
            });
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            Opened += MainWindow_Opened;
        }

        private void MainWindow_Opened(object sender, EventArgs e)
        {
            //HasSystemDecorations = false;
            //WindowState = WindowState.Maximized;
            //Topmost = true;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
    }
}

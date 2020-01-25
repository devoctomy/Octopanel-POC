using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;

namespace Octopanel_POC.Views
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            Opened += MainWindow_Opened;
        }

        private void MainWindow_Opened(object sender, EventArgs e)
        {
            HasSystemDecorations = false;
            WindowState = WindowState.Maximized;
            Topmost = true;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
    }
}

using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

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
            WindowState = WindowState.Maximized;
        }
    }
}

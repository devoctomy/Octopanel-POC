using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Octopanel_POC.Core.Models;
using Octopanel_POC.Core.UI;
using Splat;

namespace Octopanel_POC.Views
{
    public class Main : Window, IMainHost
    {
        private IUiConfigLoaderService _uiConfigLoader;
        private IContext _context;
        private bool _activated;

        public Panel PanelHost
        {
            get
            {
                var panelHost = this.FindControl<Grid>("PanelHost");
                return panelHost;
            }
        }

        public Main()
        {
            this.InitializeComponent();
            _uiConfigLoader = Locator.Current.GetService<IUiConfigLoaderService>();
            _context = Locator.Current.GetService<IContext>();
            _context.MainHost = this;

#if DEBUG
            this.AttachDevTools();
#endif

            this.Activated += Main_Activated;
        }

        private void Main_Activated(object sender, System.EventArgs e)
        {
            if(_activated)
            {
                return;
            }
     
            _context.ChangePage("splash");

            _activated = true;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}

using Octopanel_POC.Core.Models;
using Octopanel_POC.Core.Octoprint;
using Octopanel_POC.Core.ViewModels;
using Splat;
using System.ComponentModel;

namespace Octopanel_POC.Panels.ViewModels
{
    public class HomePanelViewModel : ViewModelBase, IHomePanelViewModel
    {
        private IOctoprintClientUpdaterService _octoprintClientUpdaterService;
        private float _toolTemp = float.NaN;
        private float _bedTemp = float.NaN;

        public float ToolTempActual
        {
            get
            {
                return _toolTemp;
            }
            set
            {
                if(_toolTemp != value)
                {
                    _toolTemp = value;
                    RaisePropertyChanged(new PropertyChangedEventArgs(nameof(ToolTempActual)));
                }
            }
        }

        public float BedTempActual
        {
            get
            {
                return _bedTemp;
            }
            set
            {
                if (_bedTemp != value)
                {
                    _bedTemp = value;
                    RaisePropertyChanged(new PropertyChangedEventArgs(nameof(BedTempActual)));
                }
            }
        }


        public HomePanelViewModel()
            : base()
        {
        }

        public HomePanelViewModel(IContext context)
            : base(context)
        {
            _octoprintClientUpdaterService = Locator.Current.GetService<IOctoprintClientUpdaterService>();
            _octoprintClientUpdaterService.Update += _octoprintClientUpdaterService_Update;
        }

        private void _octoprintClientUpdaterService_Update(object sender, OctoprintClientUpdaterUpdateEventArgs e)
        {
            if (e.PrinterState == null) return;

            ToolTempActual = e.PrinterState.Temperature.Tool0.Actual;
            BedTempActual = e.PrinterState.Temperature.Bed.Actual;
        }

        public override void NavigatedTo()
        {
            _octoprintClientUpdaterService.Start();
        }

        public override void NavigatingAway()
        {
            _octoprintClientUpdaterService.Stop();
        }
    }
}

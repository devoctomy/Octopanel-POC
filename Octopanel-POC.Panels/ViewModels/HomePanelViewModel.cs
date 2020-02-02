using Octopanel_POC.Core.Converters;
using Octopanel_POC.Core.Models;
using Octopanel_POC.Core.Octoprint;
using Octopanel_POC.Core.Octoprint.Model;
using Octopanel_POC.Core.ViewModels;
using Splat;

namespace Octopanel_POC.Panels.ViewModels
{
    public class HomePanelViewModel : ViewModelBase, IHomePanelViewModel
    {
        private IOctoprintClientUpdaterService _octoprintClientUpdaterService;
        private TemperatureReading _toolTemp = new TemperatureReading();
        private TemperatureReading _bedTemp = new TemperatureReading();

        public float ToolTempActual
        {
            get
            {
                return _toolTemp.Actual;
            }
        }

        public float BedTempActual
        {
            get
            {
                return _bedTemp.Actual;
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
            e.PrinterState.Temperature.Tool0.CopyTo(_toolTemp);
            RaisePropertyChanged(new System.ComponentModel.PropertyChangedEventArgs(nameof(ToolTempActual)));

            e.PrinterState.Temperature.Bed.CopyTo(_bedTemp);
            RaisePropertyChanged(new System.ComponentModel.PropertyChangedEventArgs(nameof(BedTempActual)));
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

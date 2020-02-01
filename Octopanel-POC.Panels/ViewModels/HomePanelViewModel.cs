using Octopanel_POC.Core.Models;
using Octopanel_POC.Core.Octoprint;
using Octopanel_POC.Core.ViewModels;
using Splat;

namespace Octopanel_POC.Panels.ViewModels
{
    public class HomePanelViewModel : ViewModelBase, IHomePanelViewModel
    {
        private IOctoprintClientUpdaterService _octoprintClientUpdaterService;

        public HomePanelViewModel(IContext context)
            : base(context)
        {
            _octoprintClientUpdaterService = Locator.Current.GetService<IOctoprintClientUpdaterService>();
            _octoprintClientUpdaterService.Updated += _octoprintClientUpdaterService_Updated;
        }

        private void _octoprintClientUpdaterService_Updated(object sender, System.EventArgs e)
        {
            // TODO: Update view model with updated values here
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

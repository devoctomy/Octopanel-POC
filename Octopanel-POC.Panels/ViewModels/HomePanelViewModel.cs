using Octopanel_POC.Core.Models;
using Octopanel_POC.Core.ViewModels;

namespace Octopanel_POC.Panels.ViewModels
{
    public class HomePanelViewModel : ViewModelBase, IHomePanelViewModel
    {
        public HomePanelViewModel(IContext context)
            : base(context)
        {

        }
    }
}

using Octopanel_POC.Core.Models;
using Octopanel_POC.Core.Octoprint.Model;

namespace Octopanel_POC.Panels.ViewModels
{
    public interface IHomePanelViewModel
    {
        public IContext Context { get; }
        public float ToolTempActual { get; }
        public float BedTempActual { get; }

    }
}

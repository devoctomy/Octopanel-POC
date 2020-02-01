using Octopanel_POC.Core.Octoprint;
using Octopanel_POC.Core.UI;

namespace Octopanel_POC.Core.Models
{
    public interface IContext
    {
        INavigator Navigator { get; }
        IOctoprintClientService OctoprintClient { get; }
        IMainHost MainHost { get; set; }
        bool GoBack();
        void ChangePage(string key);
    }
}

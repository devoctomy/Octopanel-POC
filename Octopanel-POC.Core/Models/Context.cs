using Octopanel_POC.Core.Octoprint;
using Octopanel_POC.Core.UI;
using Splat;

namespace Octopanel_POC.Core.Models
{
    public class Context : IContext
    {
        public INavigator Navigator { get; }
        public IOctoprintClientService OctoprintClient { get; }
        public IMainHost MainHost { get; set; }

        public Context()
        {
            Navigator = Locator.Current.GetService<INavigator>();
            OctoprintClient = Locator.Current.GetService<IOctoprintClientService>();
        }

        public bool GoBack()
        {
            return Navigator.GoBack(this);
        }

        public void ChangePage(string key)
        {
            Navigator.ChangePage(this, key);
        }

    }
}

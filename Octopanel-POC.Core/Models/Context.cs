using Octopanel_POC.Core.Octoprint;
using Splat;

namespace Octopanel_POC.Core.Models
{
    public class Context
    {
        public IOctoprintClientService OctoprintClient { get; }

        public Context()
        {
            OctoprintClient = Locator.Current.GetService<IOctoprintClientService>();
        }
    }
}

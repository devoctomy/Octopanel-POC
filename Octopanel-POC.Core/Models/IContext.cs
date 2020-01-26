using Octopanel_POC.Core.Octoprint;

namespace Octopanel_POC.Core.Models
{
    public interface IContext
    {
        IOctoprintClientService OctoprintClient { get; }
    }
}

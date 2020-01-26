using Octopanel_POC.Core.Registration;
using Octopanel_POC.Panels.ViewModels;
using Splat;

namespace Octopanel_POC.Panels.Registration
{
    public class ServiceRegistrationService : IServiceRegistrationService
    {
        public void Register(IMutableDependencyResolver resolver)
        {
            resolver.Register(() => new SplashPanelViewModel(null), typeof(ISplashPanelViewModel));
            resolver.Register(() => new HomePanelViewModel(null), typeof(IHomePanelViewModel));
        }
    }
}

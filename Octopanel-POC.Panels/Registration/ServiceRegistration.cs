using Octopanel_POC.Core.Registration;
using Octopanel_POC.Panels.ViewModels;
using Splat;

namespace Octopanel_POC.Panels.Registration
{
    public class ServiceRegistration : IServiceRegistration
    {
        public void Register(IMutableDependencyResolver resolver)
        {
            resolver.Register(() => new HomePanelViewModel(null), typeof(IHomePanelViewModel));
        }
    }
}

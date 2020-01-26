using Octopanel_POC.Core.Models;
using Octopanel_POC.Core.Registration;
using Octopanel_POC.Panels.ViewModels;
using Splat;

namespace Octopanel_POC.Panels.Registration
{
    public class ServiceRegistrationService : IServiceRegistrationService
    {
        public void Register(IMutableDependencyResolver resolver)
        {
            resolver.Register(
                () => new SplashPanelViewModel(Locator.Current.GetService<IContext>()),
                typeof(ISplashPanelViewModel));

            resolver.Register(
                () => new HomePanelViewModel(Locator.Current.GetService<IContext>()),
                typeof(IHomePanelViewModel));
        }
    }
}

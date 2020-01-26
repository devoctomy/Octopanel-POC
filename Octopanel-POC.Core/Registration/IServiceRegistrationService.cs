using Splat;

namespace Octopanel_POC.Core.Registration
{
    public interface IServiceRegistrationService
    {
        void Register(IMutableDependencyResolver resolver);
    }
}

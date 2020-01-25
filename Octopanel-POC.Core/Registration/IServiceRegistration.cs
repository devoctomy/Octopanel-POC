using Splat;

namespace Octopanel_POC.Core.Registration
{
    public interface IServiceRegistration
    {
        void Register(IMutableDependencyResolver resolver);
    }
}

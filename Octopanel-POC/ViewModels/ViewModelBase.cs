using ReactiveUI;

namespace Octopanel_POC.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {
        public object Context { get; }

        public ViewModelBase(object context)
        {
            Context = context;
        }
    }
}

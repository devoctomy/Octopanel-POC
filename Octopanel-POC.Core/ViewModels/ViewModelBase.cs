using Octopanel_POC.Core.Models;
using ReactiveUI;

namespace Octopanel_POC.Core.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {
        public Context Context { get; }

        protected ViewModelBase(Context context)
        {
            Context = context;
        }

    }
}

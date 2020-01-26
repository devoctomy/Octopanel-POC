using Octopanel_POC.Core.Models;
using ReactiveUI;
using System.ComponentModel;

namespace Octopanel_POC.Core.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {
        public IContext Context { get; }

        protected ViewModelBase(IContext context)
        {
            Context = context;
        }

        protected void RaisePropertyChanged(PropertyChangedEventArgs args)
        {
            ((IReactiveObject)this).RaisePropertyChanged(args);
        }

    }
}

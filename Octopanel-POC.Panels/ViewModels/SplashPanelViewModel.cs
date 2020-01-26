using Octopanel_POC.Core.Models;
using Octopanel_POC.Core.ViewModels;
using System.Threading;

namespace Octopanel_POC.Panels.ViewModels
{
    public class SplashPanelViewModel : ViewModelBase, ISplashPanelViewModel, ISplashViewModel
    {
        private string _message;

        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                if(_message != value)
                {
                    _message = value;
                    RaisePropertyChanged(new System.ComponentModel.PropertyChangedEventArgs(nameof(Message)));
                }
            }
        }

        public SplashPanelViewModel(IContext context)
            : base(context)
        {
            
        }
    }
}

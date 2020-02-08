using Octopanel_POC.Core.Models;
using Octopanel_POC.Core.ViewModels;
using ReactiveUI;
using System;
using System.Reactive;

namespace Octopanel_POC.Panels.ViewModels
{
    public class SplashPanelViewModel : ViewModelBase, ISplashPanelViewModel, ISplashViewModel
    {
        private string _message;
        private ReactiveCommand<object, Unit> _logoCommand;

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

        public ReactiveCommand<object, Unit> LogoCommand
        {
            get
            {
                if(_logoCommand == null)
                {
                    _logoCommand = ReactiveCommand.Create<object>(GoHome);
                }
                return _logoCommand;
            }
        }

        public SplashPanelViewModel()
            : base()
        {

        }

        public SplashPanelViewModel(IContext context)
            : base(context)
        {
        }

        private void GoHome(object parameter)
        {
            Context.ChangePage("home");
        }
    }
}

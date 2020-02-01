using Octopanel_POC.Core.Models;
using ReactiveUI;
using System.Reactive;

namespace Octopanel_POC.Panels.ViewModels
{
    public interface ISplashPanelViewModel
    {
        IContext Context { get; }
        string Message { get; set; }
        ReactiveCommand<object, Unit> LogoCommand { get; }
    }
}

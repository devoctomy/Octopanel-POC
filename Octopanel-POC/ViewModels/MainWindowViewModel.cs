using ReactiveUI;

namespace Octopanel_POC.ViewModels
{
    public class MainWindowViewModel : ReactiveObject, IMainWindowViewModel
    {
        public string Greeting => "Welcome to Avalonia!";
    }
}

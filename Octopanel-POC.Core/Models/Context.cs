using Octopanel_POC.Core.Octoprint;
using Octopanel_POC.Core.UI;
using ReactiveUI;
using Splat;
using System;
using System.ComponentModel;

namespace Octopanel_POC.Core.Models
{
    public class Context : ReactiveObject, IContext
    {
        private System.Timers.Timer _updateTimer;
        private DateTime _dateTime;

        public INavigator Navigator { get; }
        public IOctoprintClientService OctoprintClient { get; }
        public IMainHost MainHost { get; set; }

        public DateTime DateTime
        {
            get
            {
                return _dateTime;
            }
            set
            {
                if(_dateTime != value)
                {
                    _dateTime = value;
                    RaisePropertyChanged(new PropertyChangedEventArgs(nameof(this.DateTime)));
                }
            }
        }

        public Context()
        {
            Navigator = Locator.Current.GetService<INavigator>();
            OctoprintClient = Locator.Current.GetService<IOctoprintClientService>();

            DateTime = DateTime.Now;
            _updateTimer = new System.Timers.Timer(1000);
            _updateTimer.Elapsed += _updateTimer_Elapsed;
            _updateTimer.Start();
        }

        protected void RaisePropertyChanged(PropertyChangedEventArgs args)
        {
            ((IReactiveObject)this).RaisePropertyChanged(args);
        }

        private void _updateTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            DateTime = DateTime.Now;
        }

        public bool GoBack()
        {
            return Navigator.GoBack(this);
        }

        public void ChangePage(string key)
        {
            Navigator.ChangePage(this, key);
        }

    }
}

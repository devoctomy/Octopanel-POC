using Splat;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;

namespace Octopanel_POC.Core.Octoprint
{
    public class OctoprintClientUpdaterService : IOctoprintClientUpdaterService
    {
        public event EventHandler<OctoprintClientUpdaterUpdateEventArgs> Update;
        public IOctoprintClientService Client { get; private set; }

        private CancellationTokenSource _cancellationTokenSource;
        private System.Timers.Timer _refreshTimer;
        private bool _running;
        private bool _refreshing;

        public OctoprintClientUpdaterService()
        {
            Client = Locator.Current.GetService<IOctoprintClientService>();

            _refreshTimer = new System.Timers.Timer(10000);
            _refreshTimer.Elapsed += _refreshTimer_Elapsed;
        }

        private async void _refreshTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if(_refreshing)
            {
                return;
            }

            try
            {
                _refreshing = true;
                var printerState = await Client.GetPrinterStateAsync(_cancellationTokenSource.Token);

                if(Update != null)
                {
                    var args = new OctoprintClientUpdaterUpdateEventArgs(printerState);
                    Update.Invoke(this, args);
                }
            }
            catch(HttpRequestException)
            {
                // TODO: Handle requet exception here
            }
            finally
            {
                _refreshing = false;
            }
        }

        public void Start()
        {
            if(_running)
            {
                return;
            }

            if(_cancellationTokenSource != null)
            {
                _cancellationTokenSource.Dispose();
                _cancellationTokenSource = null;
            }
            _cancellationTokenSource = new CancellationTokenSource();
            _refreshTimer.Start();
            _running = true;
        }

        public void Stop()
        {
            _cancellationTokenSource.Cancel();            
            _refreshTimer.Stop();
            _running = false;
        }
    }
}

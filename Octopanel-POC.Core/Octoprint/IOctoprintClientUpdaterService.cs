using System;
using System.Collections.Generic;
using System.Text;

namespace Octopanel_POC.Core.Octoprint
{
    public interface IOctoprintClientUpdaterService
    {
        event EventHandler<EventArgs> Updated;

        IOctoprintClientService Client { get; }
        void Start();
        void Stop();
    }
}

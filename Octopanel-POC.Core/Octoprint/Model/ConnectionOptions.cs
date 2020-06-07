using System;
using System.Collections.Generic;
using System.Text;

namespace Octopanel_POC.Core.Octoprint.Model
{
    public class ConnectionOptions
    {
        public List<string> Ports { get; set; }
        public List<int> BaudRates { get; set; }
        public List<PrinterProfile> PrinterProfiles { get; set; }
        public string PortPreference { get; set; }
        public int BaudRatePreference { get; set; }
        public string PrinterProfilePreference { get; set; }
        public bool AutoConnect { get; set; }
    }
}

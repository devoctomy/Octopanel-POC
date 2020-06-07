using System;
using System.Collections.Generic;
using System.Text;

namespace Octopanel_POC.Core.Octoprint.Model
{
    public class Connection
    {
        public string State { get; set; }
        public string Port { get; set; }
        public int BaudRate { get; set; }
        public string PrinterProfile { get; set; }
    }
}

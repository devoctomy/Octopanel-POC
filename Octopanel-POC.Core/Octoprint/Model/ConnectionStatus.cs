using System;
using System.Collections.Generic;
using System.Text;

namespace Octopanel_POC.Core.Octoprint.Model
{
    public class ConnectionStatus
    {
        public Connection Current { get; set; }
        public ConnectionOptions Options { get; set; }
    }
}

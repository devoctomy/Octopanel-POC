using System;
using System.Collections.Generic;
using System.Text;

namespace Octopanel_POC.Core.Octoprint.Model
{
    public class Flags
    {
        public bool Cancelling { get; set; }
        public bool ClosdedOnError { get; set; }
        public bool Error { get; set; }
        public bool Finishing { get; set; }
        public bool Operational { get; set; }
        public bool Paused { get; set; }
        public bool Pausing { get; set; }
        public bool Printing { get; set; }
        public bool Ready { get; set; }
        public bool Resuming { get; set; }
        public bool SdReady { get; set; }
    }
}

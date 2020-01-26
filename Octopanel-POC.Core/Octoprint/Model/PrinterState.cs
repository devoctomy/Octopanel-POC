using System;
using System.Collections.Generic;
using System.Text;

namespace Octopanel_POC.Core.Octoprint.Model
{
    public class PrinterState
    {
        public Sd Sd { get; set; }
        public State State { get; set; }
        public Temperature Temperature { get; set; }
    }
}

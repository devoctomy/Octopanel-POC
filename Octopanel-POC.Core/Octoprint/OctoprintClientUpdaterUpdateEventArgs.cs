using Octopanel_POC.Core.Octoprint.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Octopanel_POC.Core.Octoprint
{
    public class OctoprintClientUpdaterUpdateEventArgs : EventArgs
    {
        public PrinterState PrinterState { get; private set; }

        public OctoprintClientUpdaterUpdateEventArgs(PrinterState printerState)
        {
            PrinterState = printerState;
        }
    }
}

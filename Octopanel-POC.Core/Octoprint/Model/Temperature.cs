using System;
using System.Collections.Generic;
using System.Text;

namespace Octopanel_POC.Core.Octoprint.Model
{
    public class Temperature
    {
        public TemperatureReading Bed { get; set; }
        public TemperatureReading Tool0 { get; set; }
        public TemperatureReading Tool1 { get; set; }
    }
}

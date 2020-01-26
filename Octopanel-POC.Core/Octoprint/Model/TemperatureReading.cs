using System;
using System.Collections.Generic;
using System.Text;

namespace Octopanel_POC.Core.Octoprint.Model
{
    public class TemperatureReading
    {
        public float Actual { get; set; }
        public float Offset { get; set; }
        public float Target { get; set; }
    }
}

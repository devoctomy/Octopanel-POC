using ReactiveUI;
using System.ComponentModel;

namespace Octopanel_POC.Core.Octoprint.Model
{
    public class TemperatureReading
    {
        public float Actual { get; set; }
        public float Offset { get; set; }
        public float Target { get; set; }

        public void CopyTo(TemperatureReading destination)
        {
            destination.Actual = Actual;
            destination.Offset = Offset;
            destination.Target = Target;
        }
    }
}

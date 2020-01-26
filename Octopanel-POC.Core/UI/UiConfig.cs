using Octopanel_POC.Core.Registration;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Octopanel_POC.Core.UI
{
    public class UiConfig
    {
        public IEnumerable<string> ServiceRegistrations { get; set; }
        public string Splash { get; set; }
        public string Home { get; set; }
        public IEnumerable<MenuItem> Menu { get; set; }
    }
}

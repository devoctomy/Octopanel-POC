using Octopanel_POC.Core.Octoprint;
using Splat;
using System;
using System.Collections.Generic;
using System.Text;

namespace Octopanel_POC.Core.Models
{
    public class Context
    {
        public IOctoprintClient OctoprintClient { get; }

        public Context()
        {
            OctoprintClient = Locator.Current.GetService<IOctoprintClient>();
        }
    }
}

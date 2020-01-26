using System;
using System.Collections.Generic;
using System.Text;

namespace Octopanel_POC.Core.UI
{
    public class MenuItem
    {
        public string Key { get; set; }
        public string Text { get; set; }
        public string Panel { get; set; }
        public IEnumerable<MenuItem> Items { get; set; }
        public bool Visible { get; set; }
    }
}

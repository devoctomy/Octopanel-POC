using Avalonia.Controls;
using Octopanel_POC.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Octopanel_POC.Core.UI
{
    public interface INavigator
    {
        bool GoBack(IContext context);
        UserControl ChangePage(
            IContext context,
            string key);
    }
}

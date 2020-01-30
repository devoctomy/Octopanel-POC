using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Text;

namespace Octopanel_POC.Core.UI
{
    public interface INavigator
    {
        bool GoBack();
        UserControl ChangePage(string key);
    }
}

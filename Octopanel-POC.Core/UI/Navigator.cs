using Avalonia.Controls;
using Splat;
using System;
using System.Collections.Generic;
using System.Text;

namespace Octopanel_POC.Core.UI
{
    public class Navigator : INavigator
    {
        private readonly Stack<string> _panelStack;
        private IUiConfigLoaderService _uiConfigLoader;

        public Navigator()
        {
            _panelStack = new Stack<string>();
            _uiConfigLoader = Locator.Current.GetService<IUiConfigLoaderService>();
        }

        public bool GoBack()
        {
            if(_panelStack.Count > 1)
            {
                string prevPage = _panelStack.Pop();
                ChangePage(prevPage);
                return true;
            }
            else
            {
                return false;
            }
        }

        public UserControl ChangePage(string key)
        {           
            var panel = _uiConfigLoader.LoadPanel("splash");
            panel.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Stretch;
            panel.VerticalAlignment = Avalonia.Layout.VerticalAlignment.Stretch;
            _panelStack.Push(key);
            return panel;
        }

    }
}

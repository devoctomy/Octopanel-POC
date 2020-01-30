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
        private readonly Dictionary<string, UserControl> _panelCache;

        public Navigator()
        {
            _panelStack = new Stack<string>();
            _uiConfigLoader = Locator.Current.GetService<IUiConfigLoaderService>();
            _panelCache = new Dictionary<string, UserControl>();
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
            if(_panelCache.ContainsKey(key))
            {
                return _panelCache[key];
            }
            else
            {
                var panel = _uiConfigLoader.LoadPanel("splash");
                _panelStack.Push(key);
                _panelCache.Add(key, panel);
                return panel;
            }
        }

    }
}

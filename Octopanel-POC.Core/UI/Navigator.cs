using Avalonia.Controls;
using Octopanel_POC.Core.Models;
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
        private string curPanelKey;
        private UserControl curPanel;

        public Navigator()
        {
            _panelStack = new Stack<string>();
            _uiConfigLoader = Locator.Current.GetService<IUiConfigLoaderService>();
            _panelCache = new Dictionary<string, UserControl>();
        }

        public bool GoBack(IContext context)
        {
            if(_panelStack.Count > 1)
            {
                string prevPage = _panelStack.Pop();
                ChangePage(context, prevPage);
                return true;
            }
            else
            {
                return false;
            }
        }

        public UserControl ChangePage(
            IContext context,
            string key)
        {           
            if(curPanelKey == key)
            {
                return curPanel;
            }
            else
            {
                context.MainHost.PanelHost.Children.Remove(curPanel);
                curPanelKey = string.Empty;
                curPanel = null;
            }

            if(_panelCache.ContainsKey(key))
            {
                return _panelCache[key];
            }
            else
            {
                var panel = _uiConfigLoader.LoadPanel(key);
                _panelStack.Push(key);
                _panelCache.Add(key, panel);
                panel.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Stretch;
                panel.VerticalAlignment = Avalonia.Layout.VerticalAlignment.Stretch;
                context.MainHost.PanelHost.Children.Add(panel);
                curPanelKey = key;
                curPanel = panel;
                return panel;
            }
        }

    }
}

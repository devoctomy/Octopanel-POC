using Newtonsoft.Json;
using Octopanel_POC.Core.Registration;
using Splat;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Octopanel_POC.Core.UI
{
    public class UiConfigLoader : IUiConfigLoader
    {
        private readonly Dictionary<string, MenuItem> _menuItemCache;
        private IServiceRegistration _serviceRegistration;
        private UiConfig _uiConfig;

        public UiConfigLoader()
        {
            _menuItemCache = new Dictionary<string, MenuItem>();
        }

        public void Load(string uiConfigPath)
        {
            var uiConfigData = File.ReadAllText(uiConfigPath);
            _uiConfig = JsonConvert.DeserializeObject<UiConfig>(uiConfigData);
            RegisterServices();
        }

        public MenuItem FindMenuItem(string key)
        {
            if(_menuItemCache.ContainsKey(key))
            {
                return _menuItemCache[key];
            }
            else
            {
                return FindMenuItem(key, _uiConfig.Menu);
            }
        }

        private MenuItem FindMenuItem(
            string key,
            IEnumerable<MenuItem> menuItems)
        {
            foreach (var curMenuItem in menuItems)
            {
                if (curMenuItem.Key == key)
                {
                    _menuItemCache.Add(key, curMenuItem);
                    return curMenuItem;
                }

                if(curMenuItem.Items != null && curMenuItem.Items.Any())
                {
                    return FindMenuItem(
                        key,
                        curMenuItem.Items);
                }
            }
            return null;
        }

        public Avalonia.Controls.Window LoadPanel(string key)
        {
            var menuItem = FindMenuItem(key);
            var window = LoadType(menuItem.Panel, out _);
            return window as Avalonia.Controls.Window;
        }

        private void RegisterServices()
        {
            foreach(string curServiceRegistration in _uiConfig.ServiceRegistrations)
            {
                var serviceRegistration = LoadType(curServiceRegistration, out _) as IServiceRegistration;
                if(serviceRegistration != null)
                {
                    serviceRegistration.Register(Locator.CurrentMutable);
                }
            }
        }

        private Object LoadType(
            string typeName,
            out Type type)
        {
            var typeNameParts = typeName.Split(':');
            var assembly = Assembly.Load(typeNameParts[0]);
            type = assembly.GetType(typeNameParts[1]);
            return Activator.CreateInstance(type);
        }
    }
}

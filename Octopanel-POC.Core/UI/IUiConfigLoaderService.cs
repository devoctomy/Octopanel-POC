﻿using Octopanel_POC.Core.Registration;

namespace Octopanel_POC.Core.UI
{
    public interface IUiConfigLoaderService
    {
        bool Load(string uiConfigPath);
        MenuItem FindMenuItem(string key);
        Avalonia.Controls.Window LoadPanel(string key);
    }
}

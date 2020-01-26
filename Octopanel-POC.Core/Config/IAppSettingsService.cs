using System;
using System.Collections.Generic;
using System.Text;

namespace Octopanel_POC.Core.Config
{
    public interface IAppSettingsService
    {
        string ServerType { get; }
        string ServerUrl { get; }
        string ServerApiKey { get; }
        string ServerClientCert { get; }
        string ServerClientCertPassword { get; }
    }
}

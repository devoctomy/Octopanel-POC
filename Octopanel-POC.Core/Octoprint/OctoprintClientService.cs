using Octopanel_POC.Core.Config;
using Splat;
using System;
using System.Net.Http;

namespace Octopanel_POC.Core.Octoprint
{
    public class OctoprintClientService : IOctoprintClientService
    {
        private readonly IAppSettingsService _appSettings;
        private readonly HttpClient _httpClient;

        public OctoprintClientService()
        {
            _appSettings = Locator.Current.GetService<IAppSettingsService>();
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(_appSettings.ServerUrl)
            };
            _httpClient.DefaultRequestHeaders.Add("X-Api-Key", _appSettings.ServerApiKey);
        }
    }
}

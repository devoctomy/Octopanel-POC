using System;
using System.Net.Http;

namespace Octopanel_POC.Core.Octoprint
{
    public class OctoprintClientService : IOctoprintClientService
    {
        private readonly HttpClient _httpClient;

        public OctoprintClientService()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://www.pop.com")
            };
        }
    }
}

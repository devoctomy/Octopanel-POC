using System;
using System.Net.Http;

namespace Octopanel_POC.Core.Octoprint
{
    public class OctoprintClient : IOctoprintClient
    {
        private readonly HttpClient _httpClient;

        public OctoprintClient()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://www.pop.com")
            };
        }
    }
}

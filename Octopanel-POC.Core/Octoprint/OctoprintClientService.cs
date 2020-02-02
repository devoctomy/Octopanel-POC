using Newtonsoft.Json;
using Octopanel_POC.Core.Config;
using Octopanel_POC.Core.Octoprint.Model;
using Splat;
using System;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace Octopanel_POC.Core.Octoprint
{
    public class OctoprintClientService : IOctoprintClientService
    {
        private readonly IAppSettingsService _appSettings;
        private readonly HttpClient _httpClient;

        public OctoprintClientService()
        {
            _appSettings = Locator.Current.GetService<IAppSettingsService>();

            var socketsHandler = new SocketsHttpHandler();
            socketsHandler.SslOptions = new SslClientAuthenticationOptions
            {
                ClientCertificates = string.IsNullOrEmpty(_appSettings.ServerClientCert) ? null : new X509CertificateCollection(
                    new[]
                    {
                        new X509Certificate(
                            _appSettings.ServerClientCert,
                            _appSettings.ServerClientCertPassword)
                    }),
                RemoteCertificateValidationCallback = new RemoteCertificateValidationCallback((sender, certificate, chain, policyErrors) => { return true; })
            };

            _httpClient = new HttpClient(socketsHandler)
            {
                BaseAddress = new Uri(_appSettings.ServerUrl)
            };
            _httpClient.DefaultRequestHeaders.Add("X-Api-Key", _appSettings.ServerApiKey);
        }

        public async Task<Model.Version> GetVersionAsync(CancellationToken cancellationToken)
        {
            var httpResponseMessage = await _httpClient.GetAsync(
                new Uri("/api/version", UriKind.Relative),
                cancellationToken);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var responseString = await httpResponseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Model.Version>(responseString);
            }
            else
            {
                return null;
            }
        }

        public async Task<PrinterState> GetPrinterStateAsync(CancellationToken cancellationToken)
        {
            var httpResponseMessage = await _httpClient.GetAsync(
                new Uri("/api/printer", UriKind.Relative),
                cancellationToken);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var responseString = await httpResponseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<PrinterState>(responseString);
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}

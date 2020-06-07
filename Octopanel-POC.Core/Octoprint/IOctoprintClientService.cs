using Octopanel_POC.Core.Octoprint.Model;
using System.Threading;
using System.Threading.Tasks;

namespace Octopanel_POC.Core.Octoprint
{
    public interface IOctoprintClientService
    {
        Task<Version> GetVersionAsync(CancellationToken cancellationToken);
        Task<PrinterState> GetPrinterStateAsync(CancellationToken cancellationToken);
        Task<ConnectionStatus> GetConnectionStatusAsync(CancellationToken cancellationToken);

    }
}

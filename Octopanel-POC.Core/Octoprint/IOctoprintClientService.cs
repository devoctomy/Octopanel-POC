using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Octopanel_POC.Core.Octoprint
{
    public interface IOctoprintClientService
    {
        Task<Model.Version> GetVersionAsync(CancellationToken cancellationToken);
    }
}

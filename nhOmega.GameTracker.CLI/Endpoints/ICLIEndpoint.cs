using nhOmega.GameTracker.CLI.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace nhOmega.GameTracker.CLI.Endpoints
{
    public interface ICLIEndpoint
    {
        string CommandName { get; }
        ICLIEndpoint Init(List<string> commands);
        Task<string> RunAsync();
        Task<string> PrintHelp(string subCommand = null);
        StringBuilder PrintCommandList();
    }
}

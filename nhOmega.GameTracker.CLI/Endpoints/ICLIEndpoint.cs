using nhOmega.GameTracker.CLI.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace nhOmega.GameTracker.CLI.Endpoints
{
    public interface ICLIEndpoint
    {
        public string CommandName { get; }
        public ICLIEndpoint Init(List<string> commands);
        public void Run();
        public void PrintHelp(string subCommand = null);
        public StringBuilder PrintCommandList();
    }
}

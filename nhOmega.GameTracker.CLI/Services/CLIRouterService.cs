using nhOmega.GameTracker.CLI.Endpoints;
using nhOmega.GameTracker.CLI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nhOmega.GameTracker.CLI.Services
{
    public class CLIRouterService
    {
        private HelpEndpoint HelpEndpoint { get; }
        public SystemSetting SystemSettings { get; }
        public List<string> Commands { get; }

        public List<ICLIEndpoint> Endpoints { get; }

        public CLIRouterService(ArgumentsService argumentsService, IServiceProvider serviceProvider)
        {
            SystemSettings = argumentsService.SystemSettings;
            Commands = argumentsService.Commands;

            HelpEndpoint = new HelpEndpoint(this);

            Endpoints = new List<ICLIEndpoint>
            {
                HelpEndpoint,
                serviceProvider.GetService(typeof(GameEndpoint)) as ICLIEndpoint,
                serviceProvider.GetService(typeof(DatabaseEndpoint)) as ICLIEndpoint
            };
        }

        public ICLIEndpoint Route(string command = null)
        {
            command = SystemOverwriteCommand(command);
            if (command is null)
            {
                command = Commands.ElementAtOrDefault(0);
            }

            ICLIEndpoint endpoint = Endpoints.FirstOrDefault(endpoint => endpoint.CommandName.Equals(command, StringComparison.InvariantCultureIgnoreCase));
            if (endpoint is null)
            {
                HelpEndpoint.MissingCommand = command;
                endpoint = HelpEndpoint;
            }

            return endpoint.Init(Commands);
        }

        private string SystemOverwriteCommand(string command)
        {
            // if help is set the overide the command and return the default help message
            if (SystemSettings.Help)
                return "help";

            return command;
        }
    }
}

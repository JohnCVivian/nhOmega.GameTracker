﻿using nhOmega.GameTracker.CLI.Model;
using nhOmega.GameTracker.CLI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nhOmega.GameTracker.CLI.Endpoints
{
    public class HelpEndpoint : ICLIEndpoint
    {
        private List<string> Commands;
        
        private readonly CLIRouterService _router;

        private readonly string _commandName = "help";
        public string CommandName => _commandName;
        public string MissingCommand { get; set; }
        
        public HelpEndpoint(CLIRouterService router)
        {
            _router = router;
        }

        public ICLIEndpoint Init(List<string> commands)
        {
            Commands = commands;
            return this;
        }

        public void PrintHelp(string subCommand = null)
        {
            StringBuilder helpMessage = new StringBuilder();
            helpMessage.AppendLine("Welcome to nhOmega GameTracker");
            helpMessage.AppendLine();

            if (!string.IsNullOrEmpty(MissingCommand))
            {
                helpMessage.AppendLine($"The Command {MissingCommand} is invalid");
                helpMessage.AppendLine();
            }
            
            helpMessage.AppendLine("The Following commands are avalable");
            
            foreach(ICLIEndpoint endpoint in _router.Endpoints)
            {
                helpMessage.Append(endpoint.PrintCommandList());
            }

            Console.Write(helpMessage.ToString());
        }

        public StringBuilder PrintCommandList()
        {
            StringBuilder commandList = new StringBuilder();
            commandList.AppendLine("\tGet command Help");
            commandList.AppendLine("\t\thelp [command] [sub command]");
            return commandList;
        }

        public void Run()
        {
            if (string.IsNullOrEmpty(MissingCommand) && Commands.Count > 1)
            {
                ICLIEndpoint endpoint = _router.Route(Commands[1]);
                endpoint.PrintHelp(Commands.ElementAtOrDefault(2));
            }
            PrintHelp();
        }
    }
}

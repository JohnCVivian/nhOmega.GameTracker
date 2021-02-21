using nhOmega.GameTracker.CLI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nhOmega.GameTracker.CLI.Endpoints
{
    public class GameEndpoint : ICLIEndpoint
    {
        public readonly string _command = "game";

        public string CommandName => _command;

        private List<string> Commands;
        public SystemSetting SystemSettings { get; private set; }

        public GameEndpoint()
        {
        }


        public ICLIEndpoint Init(List<string> commands)
        {
            Commands = commands;
            return this;
        }

        public void PrintHelp(string subCommand = null)
        {
            throw new NotImplementedException();
        }

        public StringBuilder PrintCommandList()
        {
            StringBuilder commandList = new StringBuilder();
            commandList.AppendLine("\tGame commands");
            commandList.AppendLine("\t\tgame list\t\tList games");
            commandList.AppendLine("\t\tgame add\t\tAdd game");
            return commandList;
        }

        public void Run()
        {
            string subcommand = Commands.ElementAtOrDefault(1);

            if (subcommand is null)
            {
                PrintHelp();
                return;
            }

            switch(subcommand?.ToLowerInvariant())
            {
                case "list":
                    ListGames();
                    break;
                case "add":
                    AddGame();
                    break;
                case null:
                default:
                    PrintHelp();
                    break;
            }
        }

        private void ListGames()
        {
            throw new NotImplementedException();
        }

        private void AddGame()
        {
            throw new NotImplementedException();
        }

    }
}

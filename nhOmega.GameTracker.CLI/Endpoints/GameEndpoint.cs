using nhOmega.GameTracker.CLI.Model;
using nhOmega.GameTracker.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nhOmega.GameTracker.CLI.Endpoints
{
    public class GameEndpoint : ICLIEndpoint
    {
        private readonly string _command = "game";
        private List<string> Commands;
        private IGamesRepository GamesRepository { get; }

        public string CommandName => _command;

        public GameEndpoint(IGamesRepository gamesRepository)
        {
            GamesRepository = gamesRepository;
        }


        public ICLIEndpoint Init(List<string> commands)
        {
            Commands = commands;
            return this;
        }

        public Task<string> PrintHelp(string subCommand = null)
        {
            StringBuilder helpMessage = new StringBuilder();
            helpMessage.AppendLine("Game command to list/modfy the games collection");
            helpMessage.AppendLine();

            switch (subCommand?.ToLowerInvariant())
            {
                case "list":
                    helpMessage.AppendLine("List all the games tracked");
                    break;
                case "add":
                    helpMessage.AppendLine("adds a game to be tracked");
                    helpMessage.AppendLine("Usage");
                    helpMessage.AppendLine("\tgame add [JSON]");
                    helpMessage.AppendLine();
                    helpMessage.AppendLine("\tExample:");
                    helpMessage.AppendLine("\tgame add \"{'name':'DOOG', 'state':'Completed'}\"");
                    break;
                case null:
                default:
                    helpMessage.Append(PrintCommandList());
                    break;
            }

            return Task.FromResult(helpMessage.ToString());
        }

        public StringBuilder PrintCommandList()
        {
            StringBuilder commandList = new StringBuilder();
            commandList.AppendLine("\tGame commands");
            commandList.AppendLine("\t\tgame list\tList games");
            commandList.AppendLine("\t\tgame add\tAdd game");
            return commandList;
        }

        public async Task<string> RunAsync()
        {
            string result;
            string subcommand = Commands.ElementAtOrDefault(1);

            switch(subcommand?.ToLowerInvariant())
            {
                case "list":
                    result = await ListGamesAsync();
                    break;
                case "add":
                    result = await AddGame();
                    break;
                case null:
                default:
                    result = await PrintHelp();
                    break;
            }

            return result;
        }

        private async Task<string> ListGamesAsync()
        {
            StringBuilder results = new StringBuilder();
            results.AppendLine("Your Games are:");
            List<Core.Models.Game> games = await GamesRepository.GetAll();
            foreach(var game in games)
            {
                results.AppendLine($"\t{game.Name}");
                results.AppendLine($"\t  State: {game.State}");
                results.AppendLine($"\t  Updated: {game.Date}");
                results.AppendLine($"\t  Comment:");
                results.AppendLine($"\t\t{game.Comment}");
                results.AppendLine();
            }

            return results.ToString();
        }

        private Task<string> AddGame()
        {
            throw new NotImplementedException();
        }

    }
}

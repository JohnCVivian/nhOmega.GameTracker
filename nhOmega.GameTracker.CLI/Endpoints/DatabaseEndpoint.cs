using Microsoft.EntityFrameworkCore;
using nhOmega.GameTracker.Data.SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nhOmega.GameTracker.CLI.Endpoints
{
    public class DatabaseEndpoint : ICLIEndpoint
    {
        private readonly string _command = "database";
        private List<string> Commands;
        private SqLiteContext SqLiteContext { get; }

        public string CommandName => _command;

        public DatabaseEndpoint(SqLiteContext context)
        {
            SqLiteContext = context;
        }

        public ICLIEndpoint Init(List<string> commands)
        {
            Commands = commands;
            return this;
        }

        public StringBuilder PrintCommandList()
        {
            StringBuilder commandList = new StringBuilder();
            commandList.AppendLine("\tDatabase commands");
            commandList.AppendLine("\t\tdatabase conected\tTest Connection");
            commandList.AppendLine("\t\tdatabase update\tUpdates or creates the database");
            return commandList;
        }

        public Task<string> PrintHelp(string subCommand = null)
        {
            StringBuilder helpMessage = new StringBuilder();
            helpMessage.AppendLine("database command for basic database admin");
            helpMessage.AppendLine();

            switch (subCommand?.ToLowerInvariant())
            {
                case "conected":
                    helpMessage.AppendLine("checks to see if it can access the database");
                    break;
                case "update":
                    helpMessage.AppendLine("updates or creates the database");
                    helpMessage.AppendLine("Usage");
                    helpMessage.AppendLine("\tdatabase update");
                    break;
                case null:
                default:
                    helpMessage.Append(PrintCommandList());
                    break;
            }

            return Task.FromResult(helpMessage.ToString());
        }

        public async Task<string> RunAsync()
        {
            string result;
            string subcommand = Commands.ElementAtOrDefault(1);

            switch (subcommand?.ToLowerInvariant())
            {
                case "conected":
                    result = await TestConection();
                    break;
                case "update":
                    result = await UpdateDatabase();
                    break;
                case null:
                default:
                    result = await PrintHelp();
                    break;
            }

            return result;
        }

        private async Task<string> UpdateDatabase()
        {
            bool canConnect = await SqLiteContext.Database.CanConnectAsync();
            
            Console.WriteLine($"Database connected = {canConnect}");

            if (canConnect)
            {
                Console.WriteLine($"Updating Database");
            }
            else
            {
                Console.WriteLine($"Creating Database");
            }

            await SqLiteContext.Database.MigrateAsync();

            return "Database Updated";
        }

        private async Task<string> TestConection()
        {
            bool canConnect = await SqLiteContext.Database.CanConnectAsync();
            StringBuilder results = new StringBuilder();
            results.AppendLine($"Database connected = {canConnect}");

            if (canConnect)
            {
                var pendingMigrations = await SqLiteContext.Database.GetPendingMigrationsAsync();
                if (pendingMigrations.Count() > 0)
                {
                    results.AppendLine("Database is out of date, run the database update command");
                    results.AppendLine("Pending migrations :");
                    foreach (var migration in pendingMigrations)
                    {
                        results.AppendLine($"\t{migration}");
                    }
                }
            } 
            else
            {
                results.AppendLine("Database is not found, supply database Conection string or run the database update command to create the database");
            }

            return results.ToString();
        }
    }
}

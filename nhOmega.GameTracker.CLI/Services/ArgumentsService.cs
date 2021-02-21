using nhOmega.GameTracker.CLI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nhOmega.GameTracker.CLI.Services
{
    public class ArgumentsService
    {
        public List<string> Commands;
        public SystemSetting SystemSettings;

        public ArgumentsService(string[] args)
        {
            SystemSettings = new SystemSetting();
            Commands = new List<string>();

            foreach(string command in args)
            {
                if (IsSystemCommand(command))
                {
                    SetSystemCommand(command);
                } 
                else
                {
                    Commands.Add(command);
                }
            }

        }

        private void SetSystemCommand(string command)
        {
            command = command.TrimStart(SystemArgumentPrefex.ToArray());

            switch (command.ToLowerInvariant())
            {
                case "h":
                case "?":
                case "help":
                    SystemSettings.Help = true;
                    break;
                default:
                    SystemSettings.Help = true;
                    break;
            }
        }

        private bool IsSystemCommand(string command)
        {
            return SystemArgumentPrefex.Contains(command[0]);
        }

        private readonly List<char> SystemArgumentPrefex = new List<char>{
            '-',
            '/'
        };
    }
}

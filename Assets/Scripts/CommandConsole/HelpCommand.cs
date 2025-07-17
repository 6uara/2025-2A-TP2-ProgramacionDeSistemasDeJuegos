using System.Collections.Generic;

public class HelpCommand : ICommand
{
    public string Name => "help";
    public IEnumerable<string> Aliases => new[] { "h", "?" };
    public string Description => "Shows help information for a command. Usage: help <command>";

    public void Execute(string[] args, CommandConsole console)
    {
        if (args.Length == 0)
        {
            console.AppendOutput("Please specify a command. Usage: help <command>");
            return;
        }

        var cmdName = args[0].ToLower();
        var command = console.GetCommand(cmdName);
        if (command == null)
        {
            console.AppendOutput($"Command '{cmdName}' not found.");
            return;
        }
        console.AppendOutput($"{cmdName} - {command.Description}");
        if (command.Aliases != null)
        {
            console.AppendOutput($"Aliases: {string.Join(", ", command.Aliases)}");
        }
    }
}


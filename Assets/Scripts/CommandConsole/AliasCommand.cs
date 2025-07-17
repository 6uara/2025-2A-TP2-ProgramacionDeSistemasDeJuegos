using System.Collections.Generic;

public class AliasCommand : ICommand
{
    public string Name => "aliases";
    public IEnumerable<string> Aliases => new[] { "alias" };
    public string Description => "Lists all aliases for a command. Usage: aliases <command>";

    public void Execute(string[] args, CommandConsole console)
    {
        if (args.Length == 0)
        {
            console.AppendOutput("Please specify a command. Usage: aliases <command>");
            return;
        }

        var cmdName = args[0].ToLower();
        var command = console.GetCommand(cmdName);
        if (command == null)
        {
            console.AppendOutput($"Command '{cmdName}' not found.");
            return;
        }
        console.AppendOutput($"Aliases for '{cmdName}': {string.Join(", ", command.Aliases)}");
    }
}


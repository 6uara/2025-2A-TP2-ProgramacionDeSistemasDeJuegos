using UnityEngine;

public class HelpCommand : ICommand
{
    private readonly CommandConsole console;
    public HelpCommand(CommandConsole c) => console = c;

    public string Name => "help";
    public string[] Aliases => new[] { "h" };
    public string Description => "Shows help about commands use";

    public void Execute(string[] args)
    {
        if (args.Length == 0)
        {
            console.Log("Use: help [command]");
            return;
        }

        ICommand cmd = null;
        foreach (var c in console.GetAllCommands())
        {
            if (c.Name == args[0])
            {
                cmd = c;
                break;
            }
            foreach (var alias in c.Aliases)
            {
                if (alias == args[0])
                {
                    cmd = c;
                    break;
                }
            }
            if (cmd != null)
                break;
        }

        if (cmd != null)
            console.Log($"{cmd.Name} ({string.Join(", ", cmd.Aliases)}): {cmd.Description}");
        else
            console.Log("Command not found");
    }
}

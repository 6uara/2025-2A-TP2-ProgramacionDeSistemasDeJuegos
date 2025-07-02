using UnityEngine;

public class AliassesCommand : ICommand
{
    private readonly CommandConsole console;
    public AliassesCommand(CommandConsole c) => console = c;

    public string Name => "aliasses";
    public string[] Aliases => new[] { "alias" };
    public string Description => "Shows command alias";

    public void Execute(string[] args)
    {
        if (args.Length == 0)
        {
            console.Log("Use: aliasses [command]");
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
        }


        if (cmd != null)
            console.Log($"{cmd.Name}: {string.Join(", ", cmd.Aliases)}");
        else
            console.Log("Command not found");
    }
}

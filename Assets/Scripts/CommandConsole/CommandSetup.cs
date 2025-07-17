using System.Collections.Generic;
using UnityEngine;

public class ConsoleSetup : MonoBehaviour
{
    [SerializeField] private CommandConsole commandConsole;

    private void Awake()
    {
        var commands = new List<ICommand>
        {
            new HelpCommand(),
            new AliasCommand(),
            new AnimationCommand(),
        };
        commandConsole.Setup(commands);
    }
}


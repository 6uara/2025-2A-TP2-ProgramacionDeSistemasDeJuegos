using System.Collections.Generic;
using UnityEngine;

public interface ICommand
{
    string Name { get; }
    
    IEnumerable<string> Aliases { get; }
    
    string Description { get; }
    
    void Execute(string[] args, CommandConsole console);
}


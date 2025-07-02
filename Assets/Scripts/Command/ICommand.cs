using UnityEngine;

public interface ICommand
{
    string Name { get; }
    string[] Aliases { get; }
    string Description { get; }
    void Execute(string[] args);

}


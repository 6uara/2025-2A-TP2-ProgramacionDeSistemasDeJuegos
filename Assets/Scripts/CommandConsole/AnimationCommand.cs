using System.Collections.Generic;
using UnityEngine;

public class AnimationCommand : ICommand
{
    public string Name => "playanimation";
    public IEnumerable<string> Aliases => new[] { "anim", "playanim" };
    public string Description => "Plays the specified animation on all characters. Usage: playanimation <animationName>";

    public void Execute(string[] args, CommandConsole console)
    {
        if (args.Length == 0)
        {
            console.AppendOutput("Please specify an animation name. Usage: playanimation <animationName>");
            return;
        }

        string animationName = args[0];
        var characters = Object.FindObjectsOfType<Character>();
        int found = 0;

        foreach (var character in characters)
        {
            var animator = character.GetComponentInChildren<Animator>();
            if (animator == null)
                continue;

            var clips = animator.runtimeAnimatorController.animationClips;
            bool exists = false;
            foreach (var clip in clips)
            {
                if (clip.name == animationName)
                {
                    exists = true;
                    break;
                }
            }

            if (exists)
            {
                animator.Play(animationName);
                found++;
            }
        }

        if (found == 0)
            console.AppendOutput($"Animation '{animationName}' not found on any character.");
        else
            console.AppendOutput($"Played animation '{animationName}' on {found} characters.");
    }
}
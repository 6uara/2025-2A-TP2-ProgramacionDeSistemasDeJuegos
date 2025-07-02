using UnityEngine;

public class PlayAnimationCommand : ICommand
{
    public string Name => "playanimation";
    public string[] Aliases => new[] { "anim" };
    public string Description => "Execute animation in all characters";

    public void Execute(string[] args)
    {
        if (args.Length == 0)
        {
            Debug.Log("Use: playanimation [AnimationName]");
            return;
        }

        string animName = args[0];
        int hash = Animator.StringToHash(animName);

        var characters = Object.FindObjectsByType<CharacterAnimator>(FindObjectsSortMode.None);
        if( characters == null) { Debug.Log("No characters found"); }

        foreach (var charAnim in characters)
        {
            Debug.Log("Animacion intento trigger");
            var animator = charAnim.GetComponentInChildren<Animator>();
            if (animator != null) { Debug.Log("Encontro el animator"); } else { Debug.Log("No lo encontro"); }
            if (animator.HasState(0, hash))
            {
                animator.Play(hash);
                Debug.Log("Animacion triggereada");
            }
            else
            {
                Debug.Log($"Animación '{animName}' no existe en {animator.gameObject.name}.");
            }

        }
    }
}

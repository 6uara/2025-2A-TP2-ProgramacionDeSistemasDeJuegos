using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public void Spawn(CharacterSO player)
    {
        var result = Instantiate(player.prefab, transform.position, transform.rotation);
        if (!result.TryGetComponent(out Character character))
            character = result.gameObject.AddComponent<Character>();
        character.Setup(player.characterModel);

        if (!result.TryGetComponent(out PlayerController controller))
            controller = result.gameObject.AddComponent<PlayerController>();
        controller.Setup(player.playerController);

        var animator = result.GetComponentInChildren<Animator>();
        if (!animator)
            animator = result.gameObject.AddComponent<Animator>();
        if (player.animController != null){animator.runtimeAnimatorController = player.animController;}
        
        Debug.Log("Character Spawned");
    }
}

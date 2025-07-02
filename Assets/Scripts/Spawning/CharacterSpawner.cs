using UnityEngine;

public class CharacterSpawner : MonoBehaviour, IConfigure
{
    [SerializeField] public SpawnSO spawnconfig;


    public void Configure(SpawnSO config)
    {
        this.spawnconfig = config;
    }
    public void Spawn()
    {
        var result = Instantiate(spawnconfig.digitalprefab, transform.position, transform.rotation);

        if (!result.TryGetComponent(out Character character))
            character = result.gameObject.AddComponent<Character>();
        character.Setup(spawnconfig.digitalcharacterModel);

        if (!result.TryGetComponent(out PlayerController controller))
            controller = result.gameObject.AddComponent<PlayerController>();
        controller.Setup(spawnconfig.digitalcontrollerModel);

        var animator = result.GetComponentInChildren<Animator>();
        if (!animator)
            animator = result.gameObject.AddComponent<Animator>();
        animator.runtimeAnimatorController = spawnconfig.digitalanimatorController;
    }
}

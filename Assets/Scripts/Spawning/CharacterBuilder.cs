using UnityEngine;

public interface ICharacterBuilder
{
    ICharacterBuilder SetPosition(Vector3 position);
    ICharacterBuilder SetRotation(Quaternion rotation);
    ICharacterBuilder InstantiatePrefab(GameObject prefab);
    ICharacterBuilder SetupCharacter(CharacterModel model);
    ICharacterBuilder SetupController(IPlayerControllerModel model);
    ICharacterBuilder SetupAnimator(RuntimeAnimatorController animController);
    GameObject Build();
}

public class CharacterBuilder : ICharacterBuilder
{
    private GameObject _character;

    public ICharacterBuilder SetPosition(Vector3 position)
    {
        if (_character != null)
            _character.transform.position = position;
        return this;
    }

    public ICharacterBuilder SetRotation(Quaternion rotation)
    {
        if (_character != null)
            _character.transform.rotation = rotation;
        return this;
    }

    public ICharacterBuilder InstantiatePrefab(GameObject prefab)
    {
        _character = Object.Instantiate(prefab);
        return this;
    }

    public ICharacterBuilder SetupCharacter(CharacterModel model)
    {
        if (_character.TryGetComponent(out ISetup<CharacterModel> character))
        {
            character.Setup(model);
        }
        else
        {
            var newCharacter = _character.AddComponent<Character>();
            newCharacter.Setup(model);
        }
        return this;
    }

    public ICharacterBuilder SetupController(IPlayerControllerModel model)
    {
        if (_character.TryGetComponent(out ISetup<IPlayerControllerModel> controller))
        {
            controller.Setup(model);
        }
        else
        {
            var newController = _character.AddComponent<PlayerController>();
            newController.Setup(model);
        }
        return this;
    }

    public ICharacterBuilder SetupAnimator(RuntimeAnimatorController animController)
    {
        var animator = _character.GetComponentInChildren<Animator>();
        if (animator == null)
            animator = _character.AddComponent<Animator>();
        if (animController != null)
            animator.runtimeAnimatorController = animController;
        return this;
    }

    public GameObject Build()
    {
        return _character;
    }
}
using UnityEngine;

public interface ICharacterFactory
{
    GameObject CreateCharacter(CharacterSO characterSO, Vector3 position, Quaternion rotation);
}

public class CharacterFactory : ICharacterFactory
{
    public GameObject CreateCharacter(CharacterSO characterSO, Vector3 position, Quaternion rotation)
    {
        ICharacterBuilder builder = new CharacterBuilder();
        return builder
            .InstantiatePrefab(characterSO.prefab)
            .SetPosition(position)
            .SetRotation(rotation)
            .SetupCharacter(characterSO.characterModel)
            .SetupController(characterSO.playerController)
            .SetupAnimator(characterSO.animController)
            .Build();
    }
}
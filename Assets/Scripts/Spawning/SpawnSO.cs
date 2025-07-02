using UnityEngine;

[CreateAssetMenu(fileName = "SpawnSO", menuName = "Scriptable Objects/SpawnSO")]
public class SpawnSO : ScriptableObject
{
    public Character prefab;
    public CharacterModel characterModel;
    public PlayerControllerModel controllerModel;
    public RuntimeAnimatorController animatorController;
}

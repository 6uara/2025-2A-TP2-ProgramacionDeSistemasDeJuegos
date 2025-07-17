using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSO", menuName = "Scriptable Objects/CharacterSO")]
public class CharacterSO : ScriptableObject
{
    [Header("Identification")] 
    public string title;
    [Header("Prefab")]
    public GameObject prefab;
    [Header("Model")] 
    public CharacterModel characterModel;
    [Header("Controller")]
    public PlayerControllerModel playerController;
    [Header("Animator")]
    public AnimatorOverrideController animController;
}

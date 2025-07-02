using UnityEngine;

[CreateAssetMenu(fileName = "SpawnSO", menuName = "Scriptable Objects/SpawnSO")]
public class SpawnSO : ScriptableObject
{
    [Header("Digital Guy")]
    public Character digitalprefab;
    public CharacterModel digitalcharacterModel;
    public PlayerControllerModel digitalcontrollerModel;
    public RuntimeAnimatorController digitalanimatorController;

    [Header("Pink Man")]
    public Character pinkprefab;
    public CharacterModel pinkcharacterModel;
    public PlayerControllerModel pinkcontrollerModel;
    public RuntimeAnimatorController pinkanimatorController;

    [Header("Ninja Frog")]
    public Character frogprefab;
    public CharacterModel frogcharacterModel;
    public PlayerControllerModel frogcontrollerModel;
    public RuntimeAnimatorController froganimatorController;

    [Header("Masked Dude")] 
    public Character maskedprefab;
    public CharacterModel maskedcharacterModel;
    public PlayerControllerModel maskedcontrollerModel;
    public RuntimeAnimatorController maskedanimatorController;
}

using UnityEngine;

[CreateAssetMenu(fileName = "ButtonConfigSO", menuName = "Scriptable Objects/ButtonConfigSO")]
public class ButtonConfigSO : ScriptableObject
{
    public string title;
    public SpawnSO config;
}

using UnityEngine;

[CreateAssetMenu(fileName = "CatalogSO", menuName = "Scriptable Objects/CatalogSO")]
public class CatalogSO : ScriptableObject
{
    public CharacterSO[] entries;
}

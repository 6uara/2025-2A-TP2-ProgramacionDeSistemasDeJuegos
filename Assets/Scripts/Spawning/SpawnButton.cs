using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CharacterMenuButton : MonoBehaviour
{
    [SerializeField] private Transform buttonContainer;
    [SerializeField] private Button button;
    [SerializeField] private CharacterSpawner spawner;       
    [SerializeField] private CatalogSO config;       

    
    void Start()
    {
        foreach(var entry in config.entries)
        {
            var btn = Instantiate(button, buttonContainer);
            btn.GetComponentInChildren<TextMeshProUGUI>().text = entry.title;
            btn.onClick.AddListener(() => 
                spawner.Spawn(entry)
            );
        }
    }
    private void Reset()
    {
        button = GetComponent<Button>();
    }
}
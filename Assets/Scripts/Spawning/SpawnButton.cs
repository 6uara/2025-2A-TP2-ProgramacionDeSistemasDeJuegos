using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SpawnButton : MonoBehaviour
{
    [SerializeField] private ButtonConfigSO[] buttonConfigs;
    [SerializeField] private Transform container;
    [SerializeField] private Button buttonPrefab;

    private readonly List<(Button button, UnityAction action)> registeredButtons = new();

    private void OnEnable()
    {
        foreach (var cfg in buttonConfigs)
        {
            if(buttonPrefab != null)
            {
                var btn = Instantiate(buttonPrefab, container);
                btn.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = cfg.title;

                UnityAction action = () =>
                {
                    var spawner = FindFirstObjectByType<CharacterSpawner>();
                    spawner.Configure(cfg.config);
                    spawner.Spawn();
                };

                btn.onClick.AddListener(action);
                registeredButtons.Add((btn, action));
            }
            
        }
    }

    private void OnDisable()
    {
        foreach (var (button, action) in registeredButtons)
        {
            if (button != null)
                button.onClick.RemoveListener(action);
        }
        registeredButtons.Clear();
    }
}
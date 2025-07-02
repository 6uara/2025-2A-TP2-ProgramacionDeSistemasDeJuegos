using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CommandConsole : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text outputText;
    [SerializeField] private Button toggleButton;

    private Dictionary<string, ICommand> commandMap = new();

    void Awake()
    {
        RegisterCommand(new HelpCommand(this));
        RegisterCommand(new AliassesCommand(this));
        RegisterCommand(new PlayAnimationCommand());

        toggleButton.onClick.AddListener(ToggleConsole);
        panel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
            ToggleConsole();
    }

    void ToggleConsole() => panel.SetActive(!panel.activeSelf);

    public void OnInputSubmit()
    {
        string input = inputField.text.Trim();
        inputField.text = "";
        if (string.IsNullOrEmpty(input)) return;

        var parts = input.Split(' ');
        string name = parts[0].ToLower();

        string[] args = new string[parts.Length - 1];
        for (int i = 1; i < parts.Length; i++) { args[i - 1] = parts[i];  }
            
        if (commandMap.TryGetValue(name, out var cmd))
            cmd.Execute(args);
        else
            Log($"Comando '{name}' no encontrado.");
    }

    void RegisterCommand(ICommand cmd)
    {
        commandMap[cmd.Name] = cmd;
        foreach (var alias in cmd.Aliases)
            commandMap[alias] = cmd;
    }

    public void Log(string msg) => outputText.text += "\n" + msg;
    public IEnumerable<ICommand> GetAllCommands()
    {
        var seen = new HashSet<ICommand>();
        var list = new List<ICommand>();

        foreach (var cmd in commandMap.Values)
        {
            if (!seen.Contains(cmd))
            {
                seen.Add(cmd);
                list.Add(cmd);
            }
        }

        return list;
    }

}

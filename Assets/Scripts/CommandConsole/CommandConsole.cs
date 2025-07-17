using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class CommandConsole : MonoBehaviour, ILogHandler
{
    [Header("UI")]
    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TextMeshProUGUI outputText;
    [SerializeField] private UnityEngine.UI.ScrollRect scrollRect;
    
    [Header("Input")] 
    [SerializeField] private InputActionReference toggleConsoleAction;
    
    private Dictionary<string, ICommand> _commands = new Dictionary<string, ICommand>();
    private ILogHandler _unityLogHandler;
    

    private void Awake()
    {
        _unityLogHandler = Debug.unityLogger.logHandler;
        Debug.unityLogger.logHandler = this;
    }

    private void OnDestroy() { Debug.unityLogger.logHandler = _unityLogHandler; }

    public void Setup(IEnumerable<ICommand> commands)
    {
        _commands.Clear();
        foreach (var cmd in commands)
        {
            _commands[cmd.Name.ToLower()] = cmd;
            foreach (var alias in cmd.Aliases)
                _commands[alias.ToLower()] = cmd;
        }
    }

    private void OnInput()
    {
        string input = inputField.text;
        inputField.text = "";

        var (cmdName, args) = ParseInput(input);
        var command = GetCommand(cmdName);
        if (command != null)
            command.Execute(args, this);
        else
            AppendOutput($"Command not recognized: {cmdName}");
    }


    private (string commandName, string[] args) ParseInput(string text)
    {
        text = text.Trim();
        if (string.IsNullOrEmpty(text))
            return (null, null);
        
        AppendOutput($"> {text}");
        var split = text.Split(' ');
        string cmdName = split[0].ToLower();
        string[] args = split.Length > 1 ? text.Substring(cmdName.Length).Trim().Split(' ') : new string[0];
        return (cmdName, args);
    }
    
    public ICommand GetCommand(string commandName)
    {
        if (string.IsNullOrEmpty(commandName))
            return null;
        commandName = commandName.ToLower();
        if (_commands.TryGetValue(commandName, out var cmd))
            return cmd;
        return null;
    }


    public void AppendOutput(string message) { outputText.text += message + "\n"; }
    

    //ILogHandler implementación 

    public void LogFormat(LogType logType, Object context, string format, params object[] args)
    {
        string msg = string.Format(format, args);
        AppendOutput($"[{logType}] {msg}");
        _unityLogHandler.LogFormat(logType, context, format, args);
    }

    public void LogException(System.Exception exception, Object context)
    {
        AppendOutput($"[Exception] {exception}");
        _unityLogHandler.LogException(exception, context);
    }
    
    private void OnEnable() { inputField.onSubmit.AddListener(OnInputFieldSubmit); }
    private void OnDisable() { inputField.onSubmit.RemoveListener(OnInputFieldSubmit); }
    private void OnInputFieldSubmit(string input) { OnInput(); }
}

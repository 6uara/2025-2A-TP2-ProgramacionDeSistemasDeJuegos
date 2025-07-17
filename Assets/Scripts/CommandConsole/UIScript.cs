using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ConsoleUIController : MonoBehaviour
{
    [SerializeField] private GameObject consolePanel;         
    [SerializeField] private Button toggleButton;             
    [SerializeField] private InputActionReference toggleAction; 

    private bool isConsoleActive => consolePanel.activeSelf;

    private void OnEnable()
    {
        if (toggleButton != null)
            toggleButton.onClick.AddListener(ToggleConsole);

        if (toggleAction != null)
        {
            toggleAction.action.performed += OnToggleInput;
            toggleAction.action.Enable();
        }
    }

    private void OnDisable()
    {
        if (toggleButton != null)
            toggleButton.onClick.RemoveListener(ToggleConsole);

        if (toggleAction != null)
        {
            toggleAction.action.performed -= OnToggleInput;
            toggleAction.action.Disable();
        }
    }

    private void OnToggleInput(InputAction.CallbackContext ctx)
    {
        ToggleConsole();
    }

    public void ToggleConsole()
    {
        consolePanel.SetActive(!isConsoleActive);
        if (isConsoleActive)
        {
            var input = consolePanel.GetComponentInChildren<TMPro.TMP_InputField>();
            if (input != null)
                input.ActivateInputField();
        }
    }
    
    public void ShowConsole()
    {
        consolePanel.SetActive(true);
    }
    public void HideConsole()
    {
        consolePanel.SetActive(false);
    }
}
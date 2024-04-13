using UnityEngine;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    private UIDocument _uiDocument;

    private Button _startButton;
    private Button _instructionsButton;
    private Button _exitButton;

    private void Awake()
    {
        _uiDocument = GetComponent<UIDocument>();

        _startButton = _uiDocument.rootVisualElement.Q("Start") as Button;
        _instructionsButton = _uiDocument.rootVisualElement.Q("Instructions") as Button;
        _exitButton = _uiDocument.rootVisualElement.Q("Exit") as Button;

        _startButton.RegisterCallback<ClickEvent>(onStartClick);
        _instructionsButton.RegisterCallback<ClickEvent>(onInstructionsClick);
        _exitButton.RegisterCallback<ClickEvent>(onExitClick);
    }

    private void onStartClick(ClickEvent clickEvent)
    {
        Debug.Log("Redirecting to play screen...");
    }

    private void onInstructionsClick(ClickEvent clickEvent)
    {
        Debug.Log("Redirecting to how to play screen...");
    }

    private void onExitClick(ClickEvent clickEvent)
    {
        Debug.Log("Exiting game...");
    }

    private void OnDisable()
    {
        _startButton.UnregisterCallback<ClickEvent>(onStartClick);
        _instructionsButton.UnregisterCallback<ClickEvent>(onInstructionsClick);
        _exitButton.UnregisterCallback<ClickEvent>(onExitClick);
    }
}

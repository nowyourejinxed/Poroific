using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOver : MonoBehaviour
{

    private Button _replayButton;
    private Button _menuButton;
    private UIDocument _uiDocument;

    private void Awake()
    {
        _uiDocument = GetComponent<UIDocument>();
    }

    private void OnEnable()
    {
        _replayButton = _uiDocument.rootVisualElement.Q("Replay") as Button;
        _menuButton = _uiDocument.rootVisualElement.Q("Menu") as Button;

        _replayButton.RegisterCallback<ClickEvent>(onReplayClick);
        _menuButton.RegisterCallback<ClickEvent>(onMenuClick);
    }

    private void onReplayClick(ClickEvent clickEvent)
    {
        Debug.Log("IMPLEMENT THIS... IDK HOW ¯\\_(ツ)_/¯");
    }

    private void onMenuClick(ClickEvent clickEvent)
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void OnDisable()
    {
        _replayButton.UnregisterCallback<ClickEvent>(onReplayClick);
        _menuButton.UnregisterCallback<ClickEvent>(onMenuClick);
    }
}

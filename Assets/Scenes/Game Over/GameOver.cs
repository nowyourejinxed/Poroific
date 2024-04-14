using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOver : MonoBehaviour
{
    private AudioManager _audioManager;
    private Button _replayButton;
    private Button _menuButton;
    private UIDocument _uiDocument;

    private void Awake()
    {
        _audioManager = FindObjectOfType<AudioManager>();
        _uiDocument = GetComponent<UIDocument>();

        if (_audioManager != null)
        {
            _audioManager.PlaySound("Womp Womp");
        }
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
        if (_audioManager != null)
        {    
            _audioManager.PlaySound("Button Click");
        }

        Debug.Log("IMPLEMENT THIS... IDK HOW ¯\\_(ツ)_/¯");
    }

    private void onMenuClick(ClickEvent clickEvent)
    {
        if (_audioManager != null)
        {    
            _audioManager.PlaySound("Button Click");
        }
        
        SceneManager.LoadScene("MainMenu");
    }

    private void OnDisable()
    {
        _replayButton.UnregisterCallback<ClickEvent>(onReplayClick);
        _menuButton.UnregisterCallback<ClickEvent>(onMenuClick);
    }
}

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{
    private AudioManager _audioManager;
    private Button _resumeButton;
    private Button _restartButton;
    private Button _quitButton;
    private UIDocument _uiDocument;

    [SerializeField]
    public UnityEvent _resumeGameCallback;

    private void Awake()
    {
        _audioManager = FindObjectOfType<AudioManager>();
        _uiDocument = GetComponent<UIDocument>();
    }

    private void OnEnable()
    {
        _resumeButton = _uiDocument.rootVisualElement.Q("Resume") as Button;
        _restartButton = _uiDocument.rootVisualElement.Q("Restart") as Button;
        _quitButton = _uiDocument.rootVisualElement.Q("Quit") as Button;

        _resumeButton.RegisterCallback<ClickEvent>(onResumeClick);
        _restartButton.RegisterCallback<ClickEvent>(onRestartClick);
        _quitButton.RegisterCallback<ClickEvent>(onQuitClick);
    }

    private void onResumeClick(ClickEvent clickEvent)
    {
        Debug.Log("Resuming game...");
        
        if (_audioManager != null)
        {
            _audioManager.PlaySound("Button Click");
        }

        _resumeGameCallback.Invoke();
        this.gameObject.SetActive(false);
    }

    private void onRestartClick(ClickEvent clickEvent)
    {
        Debug.Log("Restarting game...");

        if (_audioManager != null)
        {
            _audioManager.PlaySound("Button Click");
        }
    }

    private void onQuitClick(ClickEvent clickEvent)
    {
        if (_audioManager != null)
        {
            _audioManager.PlaySound("Button Click");
        }

        SceneManager.LoadScene("MainMenu");
    }

    private void OnDisable()
    {
        _resumeButton.UnregisterCallback<ClickEvent>(onResumeClick);
        _restartButton.UnregisterCallback<ClickEvent>(onRestartClick);
        _quitButton.UnregisterCallback<ClickEvent>(onQuitClick);
    }
}

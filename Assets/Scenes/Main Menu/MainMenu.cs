using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    private AudioManager _audioManager;
    private Button _startButton;
    private Button _instructionsButton;
    private Button _creditsButton;
    private Button _exitButton;

    [SerializeField]
    private UIDocument _UIDocument;
    
    [SerializeField]
    private GameObject _instructions;
    
    [SerializeField]
    private GameObject _credits;
    

    private void Awake()
    {
        _audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnEnable()
    {
        _startButton = _UIDocument.rootVisualElement.Q("Start") as Button;
        _instructionsButton = _UIDocument.rootVisualElement.Q("Instructions") as Button;
        _creditsButton = _UIDocument.rootVisualElement.Q("Credits") as Button;
        _exitButton = _UIDocument.rootVisualElement.Q("Exit") as Button;

        _startButton.RegisterCallback<ClickEvent>(onStartClick);
        _instructionsButton.RegisterCallback<ClickEvent>(onInstructionsClick);
        _creditsButton.RegisterCallback<ClickEvent>(onCreditsClick);
        _exitButton.RegisterCallback<ClickEvent>(onExitClick);
    }

    private void onStartClick(ClickEvent clickEvent)
    {
        _audioManager.PlaySound("Button Click");
        SceneManager.LoadScene("Environment");
    }

    private void onInstructionsClick(ClickEvent clickEvent)
    {
        _audioManager.PlaySound("Button Click");

        _instructions.SetActive(true);
        this.gameObject.SetActive(false);
    }

    private void onCreditsClick(ClickEvent clickEvent)
    {
        _audioManager.PlaySound("Button Click");

        _credits.SetActive(true);
        this.gameObject.SetActive(false);
    }

    private void onExitClick(ClickEvent clickEvent)
    {
        Debug.Log("Exiting game...");

        _audioManager.PlaySound("Button Click");
        Application.Quit();
    }

    private void OnDisable()
    {
        _startButton.UnregisterCallback<ClickEvent>(onStartClick);
        _instructionsButton.UnregisterCallback<ClickEvent>(onInstructionsClick);
        _exitButton.UnregisterCallback<ClickEvent>(onExitClick);
    }
}

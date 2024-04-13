using UnityEngine;
using UnityEngine.UIElements;

public class Instructions : MonoBehaviour
{
    private Button _closeButton;

    [SerializeField]
    private GameObject _mainMenu;
    private UIDocument _uiDocument;

    private void Awake()
    {
        _uiDocument = GetComponent<UIDocument>();

    }

    private void OnEnable()
    {
        _closeButton = _uiDocument.rootVisualElement.Q("Close") as Button;
        _closeButton.RegisterCallback<ClickEvent>(onCloseClick);
    }

    private void onCloseClick(ClickEvent clickEvent)
    {
        _mainMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        _closeButton.UnregisterCallback<ClickEvent>(onCloseClick);
    }
}

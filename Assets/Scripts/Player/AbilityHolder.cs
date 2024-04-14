using UnityEngine;
using UnityEngine.UIElements;

// Referenced from https://www.youtube.com/watch?v=ry4I6QyPw4E
enum AbilityState
{
    Ready,
    Active,
    Cooldown
}

public class AbilityHolder : MonoBehaviour
{
    [SerializeField]
    private Ability ability;
    
    [SerializeField]
    private KeyCode keyCode;

    [SerializeField]
    private string _UIElement;

    private UIDocument _uiDocument;
    private Label _countdownTimer;

    private float _cooldownTime;
    private float _durationTime;
    private AbilityState _abilityState = AbilityState.Ready;
    
    private void Awake()
    {
        _uiDocument = GameObject.Find("Game UI").GetComponent<UIDocument>();
    }

    private void OnEnable()
    {
        _countdownTimer = _uiDocument.rootVisualElement.Q(_UIElement) as Label;
    }

    private void Update()
    {
        switch (_abilityState)
        {
            case AbilityState.Ready:
                if (Input.GetKeyDown(keyCode))
                {
                    ability.Activate(gameObject);
                    _abilityState = AbilityState.Active;
                    _durationTime = ability.durationTime;
                }
                
                break;

            case AbilityState.Active:
                if (_durationTime > 0)
                {
                    _durationTime -= Time.deltaTime;
                }
                else
                {
                    ability.Deactivate(gameObject);
                    _abilityState = AbilityState.Cooldown;
                    _cooldownTime = ability.cooldownTime;
                }

                break;

            case AbilityState.Cooldown:
                if (_cooldownTime > 0)
                {
                    _cooldownTime -= Time.deltaTime;

                    int seconds = Mathf.FloorToInt(_cooldownTime % 60);
                    int tenths = Mathf.FloorToInt((_cooldownTime * 10) % 10);
                    _countdownTimer.text = string.Format("{0}.{1}s", seconds, tenths);
                }
                else
                {
                    _countdownTimer.text = "";
                    _abilityState = AbilityState.Ready;
                }

                break;
        }
    }
}

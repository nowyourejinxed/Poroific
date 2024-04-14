using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    
    private float cooldownTime;
    private float durationTime;
    private AbilityState abilityState = AbilityState.Ready;
    
    private void Update()
    {
        Debug.Log("I'm updating the ability...");

        switch (abilityState)
        {
            case AbilityState.Ready:
                if (Input.GetKeyDown(keyCode))
                {
                    ability.Activate(gameObject);
                    abilityState = AbilityState.Active;
                    durationTime = ability.durationTime;
                }
                
                break;

            case AbilityState.Active:
                if (durationTime > 0)
                {
                    durationTime -= Time.deltaTime;
                }
                else
                {
                    ability.Deactivate(gameObject);
                    abilityState = AbilityState.Cooldown;
                    cooldownTime = ability.cooldownTime;
                }

                break;

            case AbilityState.Cooldown:
                if (cooldownTime > 0)
                {
                    cooldownTime -= Time.deltaTime;
                }
                else
                {
                    abilityState = AbilityState.Ready;
                }

                break;
        }
    }
}

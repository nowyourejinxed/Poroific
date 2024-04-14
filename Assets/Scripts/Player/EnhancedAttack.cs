using UnityEngine;

[CreateAssetMenu]
public class EnhancedAttack : Ability
{
    public override void Activate(GameObject parentObject)
    {
        parentObject.transform.Find("Enhanced Attack").gameObject.SetActive(true);
    }

    public override void Deactivate(GameObject parentObject)
    {
        parentObject.transform.Find("Enhanced Attack").gameObject.SetActive(false);
    }
}

using UnityEngine;

[CreateAssetMenu]
public class BasicAttack : Ability
{
    public override void Activate(GameObject parentObject)
    {
        parentObject.transform.Find("Basic Attack").gameObject.SetActive(true);
    }

    public override void Deactivate(GameObject parentObject)
    {
        parentObject.transform.Find("Basic Attack").gameObject.SetActive(false);
    }
}

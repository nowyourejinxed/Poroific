using UnityEngine;

// Referenced from https://www.youtube.com/watch?v=ry4I6QyPw4E
public class Ability : ScriptableObject
{
    public new string name;
    public float cooldownTime;
    public float durationTime;

    public virtual void Activate(GameObject parentObject) {}
    public virtual void Deactivate(GameObject parentObject) {}
}

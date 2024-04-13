using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu]
[System.Serializable]
public class Sound : ScriptableObject
{
    public string soundName;
    public AudioClip audioClip;
    
    [Range(0f, 1f)]
    public float volume;
    public bool loop;

    [HideInInspector]
    public AudioSource audioSource;
}

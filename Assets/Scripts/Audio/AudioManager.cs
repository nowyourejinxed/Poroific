using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private Sound[] _sounds;
    private static AudioManager instance;

    private void Awake()
    {
        // Ensure only one instance of an AudioManager ever exists across scenes.
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);

            foreach (Sound sound in _sounds)
            {
                sound.audioSource = gameObject.AddComponent<AudioSource>();

                sound.audioSource.clip = sound.audioClip;
                sound.audioSource.volume = sound.volume;
                sound.audioSource.loop = sound.loop;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlaySound("Theme");
    }

    public void PlaySound(string soundName)
    {
        Sound selectedSound = Array.Find(_sounds, currSound => currSound.soundName == soundName);

        if (selectedSound == null) {
            Debug.LogWarning("Sound '" + soundName + "' is undefined.");
            return;
        }

        selectedSound.audioSource.Play();
    }

    public void StopSound(string soundName)
    {
        Sound selectedSound = Array.Find(_sounds, currSound => currSound.soundName == soundName);

        if (selectedSound == null) {
            Debug.LogWarning("Sound '" + soundName + "' is undefined.");
            return;
        }

        selectedSound.audioSource.Stop();
    }
}

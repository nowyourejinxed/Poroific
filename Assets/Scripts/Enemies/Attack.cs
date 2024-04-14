using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Attack : MonoBehaviour
{
    private AudioManager _audioManager;
    [SerializeField] private GameManager _manager;


    private void Awake()
    {
        _audioManager = FindObjectOfType<AudioManager>();
        _manager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            if (_audioManager != null)
            {
                _audioManager.PlaySound("Enemy Death");
            }

            _manager.IncreaseScore();
            Destroy(collider.gameObject);
            
        }
    }
}

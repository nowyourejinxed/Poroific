using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _characterController;
    
    [SerializeField]
    private float _movementSpeed = 0;

    void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 moveCharacter = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        _characterController.Move(moveCharacter * Time.deltaTime * _movementSpeed);
    }
}

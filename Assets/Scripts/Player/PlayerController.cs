using UnityEngine;

// Aiming referenced from https://www.youtube.com/watch?v=AOVCKEJE6A8&t=64s
public class PlayerController : MonoBehaviour
{
    
    [SerializeField]
    private LayerMask _groundMask;
    [SerializeField]
    private float _movementSpeed = 0f;

    private CharacterController _characterController;
    private Camera _mainCamera;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        Aim();
        MoveCharacter();
    }

    private void Aim()
    {
        var (success, position) = GetMousePosition();

        if (success)
        {
            var mouseDirection = position - transform.position;

            transform.forward = new Vector3(mouseDirection.x, 0, mouseDirection.z);
        }
    }

    private (bool success, Vector3 position) GetMousePosition()
    {
        var rayCast = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(rayCast, out var hitInfo, Mathf.Infinity, _groundMask))
        {
            return (success: true, position: hitInfo.point);
        }
        else
        {
            return (success: false, position: Vector3.zero);
        }
    }
    
    private void MoveCharacter()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        Vector3 moveCharacter = new Vector3(horizontalInput, 0, verticalInput);

        _characterController.Move(moveCharacter * Time.deltaTime * _movementSpeed);
    }
}

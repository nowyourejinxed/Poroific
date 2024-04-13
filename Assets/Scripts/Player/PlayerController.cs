using UnityEngine;
using System.Collections;

// Aiming referenced from https://www.youtube.com/watch?v=AOVCKEJE6A8&t=64s
public class PlayerController : MonoBehaviour
{
    
    [SerializeField]
    private LayerMask _groundMask;
    [SerializeField]
    private float _movementSpeed = 0f;
    [SerializeField]
    private GameObject _basicAttack;
    [SerializeField]
    private GameObject _enhancedAttack;

    private bool _isBasicAvailable = true;
    private bool _isEnhancedAvailable = true;
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

        BasicAttack();
        EnhancedAttack();
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

    private void BasicAttack()
    {
        // Check to see if the player left clicked.
        // If so, perform the basic attack.
        if (_isBasicAvailable && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(BasicAttackCooldown());;
            StartCoroutine(BasicAttackDuration());;
        }
        else
        {
            Debug.Log("Basic Attack is still on cooldown!");
        }
    }

    private IEnumerator BasicAttackCooldown()
    {
        _isBasicAvailable = false;

        yield return new WaitForSeconds(2.5f);

        _isBasicAvailable = true;
    }

    private IEnumerator BasicAttackDuration()
    {
        _basicAttack.SetActive(true);

        yield return new WaitForSeconds(1f);
        
        _basicAttack.SetActive(false);
    }

    private void EnhancedAttack()
    {
        // Check to see if the player right clicked.
        // If so, perform the enhanced attack.
        if (_isEnhancedAvailable && Input.GetMouseButtonDown(1))
        {
            StartCoroutine(EnhancedAttackCooldown());;
            StartCoroutine(EnhancedAttackDuration());;
        }
        else
        {
            Debug.Log("Enhanced Attack is still on cooldown!");
        }
    }

    private IEnumerator EnhancedAttackCooldown()
    {
        _isEnhancedAvailable = false;

        yield return new WaitForSeconds(6.5f);

        _isEnhancedAvailable = true;
    }

    private IEnumerator EnhancedAttackDuration()
    {
        _enhancedAttack.SetActive(true);

        yield return new WaitForSeconds(1.5f);
        
        _enhancedAttack.SetActive(false);
    }
}

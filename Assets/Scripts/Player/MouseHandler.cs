using UnityEngine;

// Referenced from https://www.youtube.com/watch?v=AOVCKEJE6A8&t=64s
public class MouseHandler : MonoBehaviour
{
    [SerializeField]
    private LayerMask _groundMask;

    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;

        Debug.Log(_mainCamera);
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

    // private void Aim()
    // {
    //     var (success, position) = GetMousePosition();

    //     if (success)
    //     {
    //         var mouseDirection = position - transform.position;

    //         transform.forward = new Vector3(mouseDirection.x, 0, mouseDirection.z);
    //     }
    // }

    private void Update()
    {
        var (success, position) = GetMousePosition();

        if (success)
        {
            var mouseDirection = position - transform.position;

            transform.forward = new Vector3(mouseDirection.x, 0, mouseDirection.z);
        }
    }
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class CameraAngleSwitchEvent : UnityEvent<float>
{
    public CameraAngleSwitchEvent() : base() { }

}

public class InputReader : MonoBehaviour
{
    private PlayerControls playerControls;

    [SerializeField] private float speed;
    [field: SerializeField] public GameObject CurrentVirtualCamera { get; private set; }
    [field: SerializeField] public CameraAngleSwitchEvent SwitchingAngle { get; private set; } = new();
    [field: SerializeField] private List<GameObject> VirtualCameras = new();

    private void Awake()
    {
        playerControls = new PlayerControls();
        SetMainCameraAngle(VirtualCameras[0]);
    }

    private void SwitchCameraAngle()
    {
        int indexOfCurrentVirtualCamera = VirtualCameras.IndexOf(CurrentVirtualCamera);
        if (CurrentVirtualCamera != VirtualCameras[^1])
        {
            SetMainCameraAngle(VirtualCameras[indexOfCurrentVirtualCamera + 1]);
        }
        else if (CurrentVirtualCamera == VirtualCameras[^1])
        {
            SetMainCameraAngle(VirtualCameras[0]);
        }
    }

    private void SetMainCameraAngle(GameObject virtualCamera)
    {
        CurrentVirtualCamera.SetActive(false);
        CurrentVirtualCamera = virtualCamera;
        CurrentVirtualCamera.SetActive(true);
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Update()
    {
        if (playerControls.Player.Camera.triggered)
        {
            SwitchCameraAngle();
        }
    }

    private void FixedUpdate()
    {

        Vector2 move = playerControls.Player.Move.ReadValue<Vector2>();
        GetComponent<Rigidbody>().AddForce(IsometricMovementConverter(new Vector3(move.x * speed * Time.deltaTime, 0, move.y * speed * Time.deltaTime)));
    }

    private Vector3 IsometricMovementConverter(Vector3 inputVector3)
    {
        Quaternion rotation = Quaternion.Euler(0, CurrentVirtualCamera.transform.eulerAngles.y, 0);
        Matrix4x4 isometricMatrix = Matrix4x4.Rotate(rotation);

        return isometricMatrix.MultiplyPoint3x4(inputVector3);
    }
}
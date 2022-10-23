using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class CameraRotationEvent : UnityEvent<float>
{
    public CameraRotationEvent() : base() { }

}

public class InputReader : MonoBehaviour
{
    private PlayerControls playerControls;

    [SerializeField] private float speed;
    [field: SerializeField] public float CameraRotationDegree { get; private set; }
    [field: SerializeField] public CameraRotationEvent CameraRotated { get; private set; } = new();
    [field: SerializeField] private List<float> CameraAngles = new();

    private void Awake()
    {
        playerControls = new PlayerControls();
        SetCameraRotationDegree(CameraAngles[0]);
    }

    private void SwitchCameraAngle()
    {
        int indexOfCurrentRotation = CameraAngles.IndexOf(CameraRotationDegree);
        if (CameraRotationDegree != CameraAngles[^1])
        {
            SetCameraRotationDegree(CameraAngles[indexOfCurrentRotation + 1]);
        }
        else if (CameraRotationDegree == CameraAngles[^1])
        {
            SetCameraRotationDegree(CameraAngles[0]);
        }
    }

    private void SetCameraRotationDegree(float yValue)
    {
        CameraRotationDegree = yValue;
        CameraRotated.Invoke(CameraRotationDegree);
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
        Quaternion rotation = Quaternion.Euler(0, CameraRotationDegree, 0);
        Matrix4x4 isometricMatrix = Matrix4x4.Rotate(rotation);

        return isometricMatrix.MultiplyPoint3x4(inputVector3);
    }
}
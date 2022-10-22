using UnityEngine;

public class InputReader : MonoBehaviour
{
    private PlayerControls playerControls;

    [SerializeField] private float speed;
    [field: SerializeField] private GameObject VirtualCamera { get; set; }
    [field: SerializeField] public float CameraRotationDegree { get; private set; }

    private void Awake()
    {
        playerControls = new PlayerControls();
        SetCameraRotationDegree(VirtualCamera);
    }

    private void SetCameraRotationDegree(GameObject camera)
    {
        CameraRotationDegree = camera.GetComponent<Transform>().eulerAngles.y;
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void FixedUpdate()
    {
        SetCameraRotationDegree(VirtualCamera);
        Vector2 move = playerControls.Player.Move.ReadValue<Vector2>();
        GetComponent<Rigidbody>().AddForce(IsometricConverter(new Vector3(move.x * speed * Time.deltaTime, 0, move.y * speed * Time.deltaTime)));
    }

    private Vector3 IsometricConverter(Vector3 inputVector3)
    {
        Quaternion rotation = Quaternion.Euler(0, CameraRotationDegree, 0);
        Matrix4x4 isometricMatrix = Matrix4x4.Rotate(rotation);

        return isometricMatrix.MultiplyPoint3x4(inputVector3);
    }
}
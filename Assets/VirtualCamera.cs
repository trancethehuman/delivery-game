using UnityEngine;

public class Camera : MonoBehaviour
{
    [field: SerializeField] private GameObject Player { get; set; }
    [field: SerializeField] private CameraRotationEvent CameraRotated { get; set; }

    private void Awake()
    {
        CameraRotated = Player?.GetComponent<InputReader>().CameraRotated;
        Debug.Log(CameraRotated);
        CameraRotated.AddListener(SetCameraRotation);
    }

    private void Update()
    {

    }

    private void SetCameraRotation(float yValue)
    {
        float x = transform.eulerAngles.x;
        float z = transform.eulerAngles.z;
        transform.localRotation = Quaternion.Euler(x, yValue, z);
        // transform.rotation = new Vector3(32, 135, 0);
    }
}
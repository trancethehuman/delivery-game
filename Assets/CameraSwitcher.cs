using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [field: SerializeField] private GameObject Player { get; set; }
    [field: SerializeField] private CameraAngleSwitchEvent SwitchingAngle { get; set; }
    [field: SerializeField] private List<GameObject> VirtualCameras { get; set; }

    [field: SerializeField] private Hashtable Angles { get; set; }

    private void Awake()
    {
        InitializeAnglesTable(VirtualCameras, Angles);

        SwitchingAngle = Player?.GetComponent<InputReader>().SwitchingAngle;
        SwitchingAngle.AddListener(SetMainCameraAngle);
    }


    private void Update()
    {

    }

    private void SetMainCameraAngle(float eulerAngleValue)
    {
        // Debug.Log(Angles[eulerAngleValue]);
        Debug.Log(eulerAngleValue);
    }

    private Hashtable InitializeAnglesTable(List<GameObject> virtualCameras, Hashtable anglesTable)
    {
        Hashtable result = new();

        foreach (GameObject camera in virtualCameras)
        {
            result.Add(camera.transform.eulerAngles.y, camera);
        }

        return result;
    }
}

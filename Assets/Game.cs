using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [field: SerializeField] private GameObject Player { get; set; }
    [field: SerializeField] private GameObject Package { get; set; }
    [field: SerializeField] private Vector3 minVectorArea { get; set; }
    [field: SerializeField] private Vector3 maxVectorArea { get; set; }

    [Header("Delivery Monitoring")]
    [field: SerializeField] private Job[] jobs;
    [field: SerializeField] private bool isPackagePickedUp;
    [field: SerializeField] private float timeLimit;
    [field: SerializeField] private float elapsedTime;
    [field: SerializeField] private float eta;

    void Start()
    {
        Delivery delivery = new Delivery();
        Job newJob = delivery.GenerateAJob(minVectorArea, maxVectorArea);
        Debug.Log(newJob.PickupLocation);
        Debug.Log(newJob.DropoffLocation);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

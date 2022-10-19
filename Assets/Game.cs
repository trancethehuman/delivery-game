using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [field: SerializeField] private GameObject Player { get; set; }
    // [field: SerializeField] private GameObject Package { get; set; }
    [field: SerializeField] private Vector3 minVectorArea { get; set; }
    [field: SerializeField] private Vector3 maxVectorArea { get; set; }
    [field: SerializeField] private GameObject PickupZoneObject { get; set; }
    [field: SerializeField] private GameObject DropoffZoneObject { get; set; }

    [Header("Delivery Monitoring")]
    [field: SerializeField] private List<Job> jobs;
    [field: SerializeField] private bool isPackagePickedUp;
    [field: SerializeField] private float timeLimit;
    [field: SerializeField] private float elapsedTime;
    [field: SerializeField] private float eta;
    [field: SerializeField] private Vector3 pickupAt;
    [field: SerializeField] private Vector3 dropoffAt;
    [field: SerializeField] private float dropoffTimeLimit;

    private Delivery delivery;

    void Start()
    {
        delivery = new Delivery();
        Job newJob = delivery.GenerateAJob(minVectorArea, maxVectorArea);

        pickupAt = (Vector3)(newJob?.PickupLocation);
        dropoffAt = (Vector3)(newJob?.DropoffLocation);
        dropoffTimeLimit = (float)(newJob?.TimeLimit);

        Instantiate(PickupZoneObject, pickupAt, Quaternion.Euler(0, 0, 0)).SetActive(true);
        Instantiate(DropoffZoneObject, dropoffAt, Quaternion.Euler(0, 0, 0)).SetActive(true);

        jobs.Add(newJob);
    }

    void Update()
    {

    }
}

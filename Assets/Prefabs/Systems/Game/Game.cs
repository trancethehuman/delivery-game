using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [field: SerializeField] private GameObject Player { get; set; }
    [field: SerializeField] private GameObject PickupZonePrefab { get; set; }
    [field: SerializeField] private GameObject DropoffZonePrefab { get; set; }
    [field: SerializeField] private Delivery Delivery { get; set; }
    [field: SerializeField] private List<Job> jobs = new List<Job>();
    [field: SerializeField] public Job CurrentJob { get; private set; }
    [field: SerializeField] public GameObject[] PickupBuildings { get; private set; }
    [field: SerializeField] public GameObject[] DropoffBuildings { get; private set; }

    [Header("Delivery Monitoring")]
    [field: SerializeField] private float elapsedTime;
    [field: SerializeField] private float eta;
    [field: SerializeField] private Vector3 pickupAt;
    [field: SerializeField] private Vector3 dropoffAt;
    [field: SerializeField] private float dropoffTimeLimit;

    private void Awake()
    {

    }

    void Start()
    {
        PickupBuildings = GameObject.FindGameObjectsWithTag("PickupBuilding");
        DropoffBuildings = GameObject.FindGameObjectsWithTag("DropoffBuilding");
        DemoGameplay(PickupBuildings, DropoffBuildings);
    }

    void Update()
    {
        if (CurrentJob?.InProgress == false)
        {
            CurrentJob = null;
        }

        if (CurrentJob == null)
        {
            DemoGameplay(PickupBuildings, DropoffBuildings);
        }

    }

    private void DemoGameplay(GameObject[] pickupBuildings, GameObject[] dropoffBuildings)
    {
        // Test job
        string jobLabel = "A delivery for the bois.";
        string jobMessage = "You have to deliver this for me!";
        GameObject pickupBuilding = Delivery.GetRandomBuilding(pickupBuildings);
        GameObject dropoffBuilding = Delivery.GetRandomBuilding(dropoffBuildings);

        Job newJob = Delivery.CreateJob(
            pickupBuilding,
            dropoffBuilding,
            PickupZonePrefab,
            DropoffZonePrefab,
            jobLabel,
            jobMessage
            );

        jobs.Add(newJob);

        // Add info to inspector
        pickupAt = (Vector3)(newJob?.PickupLocation);
        dropoffAt = (Vector3)(newJob?.DropoffLocation);
        dropoffTimeLimit = (float)(newJob?.TimeLimit);

        // Start new job
        Delivery.StartJob(newJob);
        CurrentJob = newJob;
    }
}

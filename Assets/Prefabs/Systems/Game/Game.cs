using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [field: SerializeField] private GameObject Player { get; set; }
    [field: SerializeField] private Delivery Delivery { get; set; }
    [field: SerializeField] private List<Job> Jobs = new();
    [field: SerializeField] public Job CurrentJob { get; private set; }
    [field: SerializeField] public GameObject[] PickupDoors { get; private set; }
    [field: SerializeField] public GameObject[] DropoffDoors { get; private set; }

    [Header("Delivery Monitoring")]
    [field: SerializeField] private float elapsedTime;
    [field: SerializeField] private float eta;
    [field: SerializeField] private Vector3 pickupAt;
    [field: SerializeField] private Vector3 dropoffAt;
    [field: SerializeField] private float dropoffTimeLimit;

    private void Awake()
    {
        // Delivery.DeliveryPickedUp.AddListener(CurrentJob.JobStartStatusChange);
        // Delivery.DeliveryDroppedoff.AddListener(CurrentJob.JobFinished);

        // Delivery.DeliveryPickedUp.AddListener(Stuff);
        // Delivery.DeliveryDroppedoff.AddListener(Stuff);
    }

    void Start()
    {
        PickupDoors = GameObject.FindGameObjectsWithTag("Pickup");
        DropoffDoors = GameObject.FindGameObjectsWithTag("Dropoff");
        DemoGameplay(PickupDoors, DropoffDoors);
    }

    void Update()
    {
        if (CurrentJob?.InProgress == false)
        {
            CurrentJob = null;
        }

        if (CurrentJob == null)
        {
            DemoGameplay(PickupDoors, DropoffDoors);
        }

    }

    private void DemoGameplay(GameObject[] PickupDoors, GameObject[] DropoffDoors)
    {
        // Test job
        string jobLabel = "A delivery for the bois.";
        string jobMessage = "You have to deliver this for me!";
        GameObject pickupDoor = Delivery.GetRandomDoor(PickupDoors);
        GameObject dropoffDoor = Delivery.GetRandomDoor(DropoffDoors);

        Job newJob = Delivery.CreateJob(
            pickupDoor,
            dropoffDoor,
            jobLabel,
            jobMessage
            );

        Jobs.Add(newJob);

        dropoffTimeLimit = (float)(newJob?.TimeLimit);

        // Start new job
        Delivery.StartJob(newJob);
        CurrentJob = newJob;
    }

    private void Stuff()
    {

    }
}

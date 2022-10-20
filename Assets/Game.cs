using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [field: SerializeField] private GameObject Player { get; set; }
    // [field: SerializeField] private GameObject Package { get; set; }
    [field: SerializeField] private Vector3 minVectorArea { get; set; }
    [field: SerializeField] private Vector3 maxVectorArea { get; set; }
    [field: SerializeField] private GameObject PickupZonePrefab { get; set; }
    [field: SerializeField] private GameObject DropoffZonePrefab { get; set; }
    [field: SerializeField] private Delivery Delivery { get; set; }
    [field: SerializeField] private List<Job> jobs = new List<Job>();
    [field: SerializeField] public Job CurrentJob { get; private set; }

    [Header("Delivery Monitoring")]
    [field: SerializeField] private float elapsedTime;
    [field: SerializeField] private float eta;
    [field: SerializeField] private Vector3 pickupAt;
    [field: SerializeField] private Vector3 dropoffAt;
    [field: SerializeField] private float dropoffTimeLimit;

    void Start()
    {
        DemoGameplay();
    }

    void Update()
    {
        if (CurrentJob?.InProgress == false)
        {
            CurrentJob = null;
        }

        if (CurrentJob == null)
        {
            DemoGameplay();
        }

    }

    private void DemoGameplay()
    {
        // Test job
        string jobLabel = "A delivery for the bois.";
        string jobMessage = "You have to deliver this for me!";
        Job newJob = Delivery.GenerateAJob(
            minVectorArea,
            maxVectorArea,
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

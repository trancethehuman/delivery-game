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
    [field: SerializeField] private Hashtable jobs = new Hashtable();

    [Header("Delivery Monitoring")]
    [field: SerializeField] private float elapsedTime;
    [field: SerializeField] private float eta;
    [field: SerializeField] private Vector3 pickupAt;
    [field: SerializeField] private Vector3 dropoffAt;
    [field: SerializeField] private float dropoffTimeLimit;
    [field: SerializeField] private string currentJob;


    void Start()
    {
        DemoGameplay();
    }

    void Update()
    {

    }

    private void DemoGameplay()
    {
        string jobLabel = "You have to deliver this for me!";
        Job newJob = Delivery.GenerateAJob(minVectorArea, maxVectorArea, PickupZonePrefab, DropoffZonePrefab, jobLabel);

        jobs.Add(newJob.Id, newJob);
        Debug.Log(newJob.Id);

        pickupAt = (Vector3)(newJob?.PickupLocation);
        dropoffAt = (Vector3)(newJob?.DropoffLocation);
        dropoffTimeLimit = (float)(newJob?.TimeLimit);

        currentJob = newJob?.Label;
        Delivery.PickAJob(newJob);
    }
}

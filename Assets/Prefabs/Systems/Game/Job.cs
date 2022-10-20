using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Job
{
    public string Id { get; private set; }
    public Vector3 PickupLocation { get; private set; }
    public Vector3 DropoffLocation { get; private set; }
    public float TimeLimit { get; private set; }
    public GameObject PickupZone { get; private set; }
    public GameObject DropoffZone { get; private set; }
    public string Label { get; private set; }

    public Job(Vector3 pickupLocation, Vector3 dropoffLocation, float timeLimit, GameObject pickupZone, GameObject dropoffZone, string label)
    {
        PickupLocation = pickupLocation;
        DropoffLocation = dropoffLocation;
        TimeLimit = timeLimit;
        PickupZone = pickupZone;
        DropoffZone = dropoffZone;
        Label = label;
        Id = GenerateId();
    }

    private string GenerateId()
    {
        return Guid.NewGuid().ToString();
    }
}

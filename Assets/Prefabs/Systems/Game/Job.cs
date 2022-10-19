using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Job
{
    public Vector3 PickupLocation { get; private set; }
    public Vector3 DropoffLocation { get; private set; }
    public float TimeLimit { get; private set; }

    public Job(Vector3 pickupLocation, Vector3 dropoffLocation, float timeLimit)
    {
        PickupLocation = pickupLocation;
        DropoffLocation = dropoffLocation;
        TimeLimit = timeLimit;
    }
}

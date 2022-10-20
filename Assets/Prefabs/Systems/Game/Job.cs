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
    public string Message { get; private set; }
    public bool IsCompleted { get; private set; }
    public bool InProgress { get; private set; }

    public Job(Vector3 pickupLocation, Vector3 dropoffLocation, float timeLimit, GameObject pickupZone, GameObject dropoffZone)
    {
        PickupLocation = pickupLocation;
        DropoffLocation = dropoffLocation;
        TimeLimit = timeLimit;
        PickupZone = pickupZone;
        DropoffZone = dropoffZone;
        Id = GenerateId();
        IsCompleted = false;
        InProgress = false;
    }

    private string GenerateId()
    {
        return Guid.NewGuid().ToString();
    }

    public void JobFinished()
    {
        if (InProgress == true)
        {
            IsCompleted = true;
            JobStopStatusChange();
        }
    }

    public void JobStartStatusChange()
    {
        InProgress = true;
    }

    public void JobStopStatusChange()
    {
        InProgress = false;
    }

    public void AddMessage(string message)
    {
        Message = message;
    }

    public void AddLabel(string label)
    {
        Label = label;
    }
}

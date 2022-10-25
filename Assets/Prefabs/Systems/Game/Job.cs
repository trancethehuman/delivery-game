using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Job
{
    public string Id { get; private set; }
    public float TimeLimit { get; private set; }
    public GameObject PickupDoor { get; private set; }
    public GameObject DropoffDoor { get; private set; }
    public string Label { get; private set; }
    public string Message { get; private set; }
    public bool IsCompleted { get; private set; }
    public bool InProgress { get; private set; }

    public Job(float timeLimit, GameObject pickupDoor, GameObject dropoffDoor)
    {
        TimeLimit = timeLimit;
        PickupDoor = pickupDoor;
        DropoffDoor = dropoffDoor;
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

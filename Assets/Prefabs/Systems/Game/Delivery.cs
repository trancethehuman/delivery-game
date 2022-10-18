using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery
{
    public Delivery()
    {

    }

    public Job GenerateAJob(Vector3 minimumVector, Vector3 maximumVector)
    {
        Vector3 pickupLocation = new Vector3(UnityEngine.Random.Range(minimumVector.x, maximumVector.x), 0, UnityEngine.Random.Range(minimumVector.z, maximumVector.z));
        Vector3 dropoffLocation = new Vector3(UnityEngine.Random.Range(minimumVector.x, maximumVector.x), 0, UnityEngine.Random.Range(minimumVector.z, maximumVector.z));
        return new Job(pickupLocation, dropoffLocation);
    }

    public void assignJob()
    {

    }

    public void jobComplete()
    {

    }

    public void packagePickup()
    {

    }

    public void packageDropOff()
    {

    }

}

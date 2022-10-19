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
        float timeLimit = UnityEngine.Random.Range(1, 5); // To-do: Make time limit into a separate method that takes into account the delivery distance as well.
        return new Job(pickupLocation, dropoffLocation, timeLimit);
    }

    public void assignJob()
    {

    }

    public void jobComplete()
    {

    }

    public bool PickupDropoff(GameObject zone, bool hasPackage)
    {
        if (zone.tag == "pickupZone" && hasPackage == false) return true;
        else if (zone.tag == "dropoffZone" && hasPackage) return false;
        else return hasPackage;
    }
}

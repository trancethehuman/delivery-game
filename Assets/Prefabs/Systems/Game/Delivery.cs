using System;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    public Job GenerateAJob(Vector3 minimumVector, Vector3 maximumVector, GameObject pickUpZonePrefab, GameObject dropoffZonePrefab, string label)
    {
        Vector3 pickupLocation = new Vector3(UnityEngine.Random.Range(minimumVector.x, maximumVector.x), 0, UnityEngine.Random.Range(minimumVector.z, maximumVector.z));
        Vector3 dropoffLocation = new Vector3(UnityEngine.Random.Range(minimumVector.x, maximumVector.x), 0, UnityEngine.Random.Range(minimumVector.z, maximumVector.z));
        GameObject pickupZone = GenerateZone(pickUpZonePrefab, pickupLocation);
        GameObject dropoffZone = GenerateZone(dropoffZonePrefab, dropoffLocation);

        float timeLimit = UnityEngine.Random.Range(1, 5); // To-do: Make time limit into a separate method that takes into account the delivery distance as well.

        return new Job(pickupLocation, dropoffLocation, timeLimit, pickupZone, dropoffZone, label);
    }

    public GameObject GenerateZone(GameObject zonePrefab, Vector3 location)
    {
        Quaternion defaultAngle = Quaternion.Euler(0, 0, 0);
        return Instantiate(zonePrefab, location, defaultAngle);
    }

    public void PickAJob(Job job)
    {
        job.PickupZone.SetActive(true);
        job.DropoffZone.SetActive(true);
    }

    // Returns a bool when player enters a zone
    public bool PickedUpDropppedOff(GameObject zone, bool hasPackage)
    {
        if (zone.tag == "pickupZone" && hasPackage == false)
        {
            Destroy(zone);
            return true;
        }
        else if (zone.tag == "dropoffZone" && hasPackage)
        {
            Destroy(zone);
            return false;
        }
        else return hasPackage;
    }
}

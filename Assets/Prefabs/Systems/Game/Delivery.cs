using System;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    public Job GenerateAJob(Vector3 minimumVector, Vector3 maximumVector, GameObject pickUpZonePrefab, GameObject dropoffZonePrefab, string label, string message)
    {
        Vector3 pickupLocation = new Vector3(UnityEngine.Random.Range(minimumVector.x, maximumVector.x), 0, UnityEngine.Random.Range(minimumVector.z, maximumVector.z));
        Vector3 dropoffLocation = new Vector3(UnityEngine.Random.Range(minimumVector.x, maximumVector.x), 0, UnityEngine.Random.Range(minimumVector.z, maximumVector.z));
        GameObject pickupZone = GenerateZone(pickUpZonePrefab, pickupLocation);
        GameObject dropoffZone = GenerateZone(dropoffZonePrefab, dropoffLocation);

        float timeLimit = UnityEngine.Random.Range(1, 5); // To-do: Make time limit into a separate method that takes into account the delivery distance as well.

        Job newJob = new Job(pickupLocation, dropoffLocation, timeLimit, pickupZone, dropoffZone);
        newJob.AddMessage(message);
        newJob.AddLabel(label);

        return newJob;
    }

    public GameObject GenerateZone(GameObject zonePrefab, Vector3 location)
    {
        Quaternion defaultAngle = Quaternion.Euler(0, 0, 0);
        return Instantiate(zonePrefab, location, defaultAngle);
    }

    public void StartJob(Job job)
    {
        job.JobStartStatusChange();
        job.PickupZone.SetActive(true);
        job.DropoffZone.SetActive(true);
    }

    public void OnPickupOrDropoff(GameObject zone, Player agent, bool agentHasPackage, Job job)
    {
        if (zone.tag == "pickupZone" && agentHasPackage == false)
        {
            agent.ChangeHasPackage(true);
            Destroy(zone);
        }
        else if (zone.tag == "dropoffZone" && agentHasPackage)
        {
            job.JobFinished();
            Destroy(zone);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    public Job CreateJob(GameObject pickupBuilding, GameObject dropoffBuilding, GameObject pickUpZonePrefab, GameObject dropoffZonePrefab, string label, string message)
    {
        Vector3 pickupDoor = GetBuildingDoorPosition(pickupBuilding);
        Vector3 dropoffDoor = GetBuildingDoorPosition(dropoffBuilding);

        GameObject pickupZone = GenerateZone(pickUpZonePrefab, pickupDoor);
        GameObject dropoffZone = GenerateZone(dropoffZonePrefab, dropoffDoor);

        float timeLimit = UnityEngine.Random.Range(1, 5); // To-do: Make time limit into a separate method that takes into account the delivery distance as well.

        Job newJob = new(pickupDoor, dropoffDoor, timeLimit, pickupZone, dropoffZone);
        newJob.AddMessage(message);
        newJob.AddLabel(label);

        return newJob;
    }

    public Vector3 GetBuildingDoorPosition(GameObject building)
    {
        return building.transform.GetChild(0).position;
    }

    public GameObject GetRandomBuilding(GameObject[] buildings)
    {
        return buildings[UnityEngine.Random.Range(0, buildings.Length - 1)];
    }

    public GameObject GenerateZone(GameObject zonePrefab, Vector3 doorPosition)
    {
        Quaternion defaultAngle = Quaternion.Euler(0, 0, 0);
        Vector3 zonePosition = new(doorPosition.x, 0, doorPosition.z);
        return Instantiate(zonePrefab, zonePosition, defaultAngle);
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
            agent.ChangeHasPackage(false);
            job.JobFinished();
            Destroy(zone);
        }
    }
}

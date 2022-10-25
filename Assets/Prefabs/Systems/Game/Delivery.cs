using UnityEngine;
using UnityEngine.Events;

public class Delivery : MonoBehaviour
{
    public UnityEvent DeliveryPickedUp { get; private set; }
    public UnityEvent DeliveryDroppedoff { get; private set; }

    public Job CreateJob(GameObject pickupDoor, GameObject dropoffDoor, string label, string message)
    {

        float timeLimit = UnityEngine.Random.Range(1, 5); // To-do: Make time limit into a separate method that takes into account the delivery distance as well.

        Job newJob = new(timeLimit, pickupDoor, dropoffDoor);
        newJob.AddMessage(message);
        newJob.AddLabel(label);

        return newJob;
    }

    public GameObject GetRandomDoor(GameObject[] doors)
    {
        return doors[UnityEngine.Random.Range(0, doors.Length - 1)];
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
        job.PickupDoor.GetComponent<Renderer>().material.color = Color.green;
        job.DropoffDoor.GetComponent<Renderer>().material.color = Color.red;
    }

    public void OnPickupOrDropoff(GameObject door, Player player)
    {
        if (door.tag == "Pickup" && player.HasPackage == false)
        {
            player.ChangeHasPackage(true);
            door.GetComponent<Renderer>().material.color = Color.white;
            // DeliveryPickedUp.Invoke();
        }
        else if (door.tag == "Dropoff" && player.HasPackage)
        {
            player.ChangeHasPackage(false);
            door.GetComponent<Renderer>().material.color = Color.white;
            // DeliveryDroppedoff.Invoke();
        }
    }
}

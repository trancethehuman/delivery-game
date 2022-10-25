using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    [field: SerializeField] private Delivery Delivery { get; set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Delivery.OnPickupOrDropoff(gameObject, other.gameObject.GetComponent<Player>());
        }
    }
}
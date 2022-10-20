using UnityEngine;

public class Zone : MonoBehaviour
{
    [field: SerializeField] private Delivery Delivery { get; set; }
    [field: SerializeField] private Game Game { get; set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.gameObject.GetComponent<Player>();
            Delivery.OnPickupOrDropoff(gameObject, player, player.HasPackage, Game?.CurrentJob);
        }
    }
}
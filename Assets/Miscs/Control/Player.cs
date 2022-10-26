using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [field: SerializeField] public bool HasPackage { get; private set; }
    [field: SerializeField] private float GasLimit { get; set; }
    [field: SerializeField] private float HealthLimit { get; set; }
    [field: SerializeField] public float Gas { get; private set; }
    [field: SerializeField] public float Health { get; private set; }

    public UnityEvent DeliveryPickedUp { get; private set; } = new();
    public UnityEvent DeliveryDroppedoff { get; private set; } = new();

    public void ChangeHasPackage(bool newStatus)
    {
        HasPackage = newStatus;
    }

    public void ChangeHealth(float amount)
    {
        Health += amount;
    }

    public void ChangeGas(float amount)
    {
        Health += amount;
    }

    public void OnPickupOrDropoff(GameObject door)
    {
        if (door.tag == "Pickup" && HasPackage == false)
        {
            ChangeHasPackage(true);
            door.GetComponent<Renderer>().material.color = Color.white;
            DeliveryPickedUp.Invoke();
        }
        else if (door.tag == "Dropoff" && HasPackage)
        {
            ChangeHasPackage(false);
            door.GetComponent<Renderer>().material.color = Color.white;
            DeliveryDroppedoff.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup" || other.tag == "Dropoff")
        {
            OnPickupOrDropoff(other.gameObject);
        }
    }
}

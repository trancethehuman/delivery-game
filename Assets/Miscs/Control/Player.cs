using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [field: SerializeField] public bool hasPackage { get; private set; }
    private Delivery delivery;

    private void Awake()
    {
        delivery = new Delivery();
    }

    private void OnTriggerEnter(Collider other)
    {
        hasPackage = delivery.PickupDropoff(other.gameObject, hasPackage);
    }
}

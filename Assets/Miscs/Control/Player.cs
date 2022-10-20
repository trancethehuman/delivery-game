using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [field: SerializeField] public bool HasPackage { get; private set; }

    // private void OnTriggerEnter(Collider other)
    // {
    //     HasPackage = Delivery.PickedUpDropppedOff(other.gameObject, HasPackage);
    // }

    public void ChangeHasPackage(bool newStatus)
    {
        HasPackage = newStatus;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [field: SerializeField] public bool HasPackage { get; private set; }
    [field: SerializeField] private float GasLimit { get; set; }
    [field: SerializeField] private float HealthLimit { get; set; }
    [field: SerializeField] public float Gas { get; private set; }
    [field: SerializeField] public float Health { get; private set; }

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
}

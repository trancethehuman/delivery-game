using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerControls playerControls;
    private InputAction playerActionMap;

    private void Awake()
    {
        playerActionMap = playerControls.Player.Move;
    }
}

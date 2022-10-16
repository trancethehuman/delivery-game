using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    private PlayerControls playerControls;
    [SerializeField] private float speed;
    [SerializeField] private Vector3 velocity;

    private void Awake()
    {
        playerControls = new PlayerControls();
        velocity = GetComponent<Rigidbody>().velocity;
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void FixedUpdate()
    {
        Vector2 move = playerControls.Player.Move.ReadValue<Vector2>();
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(move.x * speed * Time.deltaTime, 0, move.y * speed * Time.deltaTime));
        }
    }
}
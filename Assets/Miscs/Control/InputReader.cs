using UnityEngine;

public class InputReader : MonoBehaviour
{
    private PlayerControls playerControls;
    [SerializeField] private float speed;

    private void Awake()
    {
        playerControls = new PlayerControls();
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
        GetComponent<Rigidbody>().AddForce(new Vector3(move.x * speed * Time.deltaTime, 0, move.y * speed * Time.deltaTime));
    }
}
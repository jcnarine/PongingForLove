using System.Timers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float paddleSpeed = 1f;

    [SerializeField] private MatchManager matchManager;
    [SerializeField] private Rigidbody rb;

    private Vector2 moveInput;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        paddleSpeed = matchManager.players[0].characterData.speed;
        rb = GetComponent<Rigidbody>(); 
    }

    public void OnMove(InputAction.CallbackContext context) 
    {
        moveInput = context.ReadValue<Vector2>(); 
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        movePaddle();
    }
    void movePaddle() 
    {
        // Use joystick strength for speed scaling
        Vector3 movement = new Vector3(moveInput.x * paddleSpeed, 0f, 0f);

        rb.velocity = movement;
    }
}

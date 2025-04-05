using System.Timers;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    private float speed = 1f;
    public Player paddle;
    private Rigidbody rb;
    private Vector3 movement;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = paddle.fSpeed;
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal"),0f,0f);
        //if want drag, movement = new Vector3(Input.GetAxis("Horizontal") * fSpeed * Time.deltaTime, 0f, 0f);
    }

    private void FixedUpdate()
    {
        movePaddle(movement);
    }

    void movePaddle(Vector3 direction) 
    {
        rb.velocity = direction * speed;
    }
}

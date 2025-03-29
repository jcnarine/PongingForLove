using UnityEngine;
using System.Collections;


public class Ball : MonoBehaviour
{
    public float fSpeed = 5f;
    public Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float sx = Random.Range(0, 2) == 0 ? -1 : 1;
        float sy = Random.Range(0, 2) == 0 ? -1 : 1;

        rb.linearVelocity = new Vector3(fSpeed * sx, 0, fSpeed * sy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

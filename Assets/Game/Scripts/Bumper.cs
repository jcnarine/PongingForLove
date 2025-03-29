using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float fSpeed = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody>().freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().linearVelocity = new Vector3( Input.GetAxis("Horizontal") * fSpeed, 0f, 0f);
    }
}

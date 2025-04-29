using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public float minSpeed = 0.5f;
    public float maxSpeed = 1.5f;
    public float speedIncrement = 0.05f;

    //public GameObject ballPrefab;
    public float currentSpeed;
    private Rigidbody rb;
    private Vector3 startPosition;
    //public static int ballCount = 1;
    public float minAngle = 30f,maxAngle = 60f;
    public HeartUI rejectionUI, affectionUI;
    //public static int ballIndex = 0;
    public bool isPlayerScoring=false, isResetting=false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
        currentSpeed = minSpeed;

        // Dynamically assign HeartUI components if not already set
        if (rejectionUI == null)
        {
            rejectionUI = GameObject.Find("RejectionUI")?.GetComponent<HeartUI>();
        }
        if (affectionUI == null)
        {
            affectionUI = GameObject.Find("AffectionUI")?.GetComponent<HeartUI>();
        }

        moveBall();
    }

    void FixedUpdate()
    {
        if (rb.velocity.magnitude < currentSpeed && !isResetting)
        {
            rb.velocity = rb.velocity.normalized * currentSpeed;
        }
    }

    void moveBall() {
        float angle = Random.Range(minAngle, maxAngle) * Mathf.Deg2Rad;
        Vector3 baseDirection = isPlayerScoring ? Vector3.forward : Vector3.back;
        Vector3 direction = Quaternion.Euler(0, Random.Range(-maxAngle, maxAngle), 0) * baseDirection;
        rb.AddForce(direction * currentSpeed, ForceMode.Impulse);
    }

    IEnumerator ResetBallCoroutine()
    {
        isResetting = true;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = startPosition;

        yield return new WaitForSeconds(2f);

        currentSpeed = minSpeed;

        moveBall();
        isResetting = false;
    }

    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(ResetBallCoroutine());

        if (other.CompareTag("EnemyGoal"))
        {
            affectionUI.GainLevel();

        }
        else if (other.CompareTag("PlayerGoal"))
        {
            rejectionUI.GainLevel();
        }

        isResetting = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentSpeed += speedIncrement;
        currentSpeed = Mathf.Clamp(currentSpeed, minSpeed, maxSpeed);
    }
}

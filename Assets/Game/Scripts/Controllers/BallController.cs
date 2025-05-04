using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallController : MonoBehaviour, IResettable
{
    [Header("Speed Settings")]
    public float minSpeed = 0.5f;
    public float maxSpeed = 1.5f;
    public float speedIncrement = 0.05f;
   
    private float currentSpeed;

    [Header("Angle Settings")]
    public float minLaunchAngle = 30f;
    public float maxLaunchAngle = 60f;

    [Header("References")]
    public MatchManager matchController;

    public Rigidbody rb;
    private Vector3 startPosition;

    private bool isResetting = false;
    private bool launchTowardPlayer = false;

    public void Awake()
    { 
        startPosition = transform.position;
        currentSpeed = minSpeed;
    }

    public void FixedUpdate()
    {
        if (!isResetting && rb.velocity.magnitude < currentSpeed)
        {
            rb.velocity = rb.velocity.normalized * currentSpeed;
        }
    }

    public void Launch()
    {
        Vector3 baseDirection = launchTowardPlayer ? Vector3.forward : Vector3.back;
        Vector3 randomizedDirection = Quaternion.Euler(0, Random.Range(-maxLaunchAngle, maxLaunchAngle), 0) * baseDirection;
        rb.AddForce(randomizedDirection * currentSpeed, ForceMode.Impulse);
    }

    private IEnumerator ResetBallRoutine()
    {
        yield return new WaitForSeconds(matchController.WaitTime);

        currentSpeed = minSpeed;

        Launch();

        isResetting = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        ResetState();

        if (other.CompareTag("EnemyGoal"))
        {
            matchController.HandlePointScored(true);
            launchTowardPlayer = false;
        }
        else if (other.CompareTag("PlayerGoal"))
        {
            matchController.HandlePointScored(false);
            launchTowardPlayer = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentSpeed += speedIncrement;
        currentSpeed = Mathf.Clamp(currentSpeed, minSpeed, maxSpeed);
    }

    public void ResetState()
    {
        isResetting = true;

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = startPosition;

        StartCoroutine(ResetBallRoutine());
    }
}

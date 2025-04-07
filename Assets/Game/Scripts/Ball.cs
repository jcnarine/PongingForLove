using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    //public GameObject ballPrefab;
    public float speed;
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

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResetBall() 
    {
        transform.position = startPosition;
        rb.velocity = Vector3.zero;
        moveBall();
        Invoke(nameof(AllowReset), 0.5f);

    }

    void moveBall() {
        float angle = Random.Range(minAngle, maxAngle) * Mathf.Deg2Rad;
        Vector3 baseDirection = isPlayerScoring ? Vector3.forward : Vector3.back;
        Vector3 direction = Quaternion.Euler(0, Random.Range(-maxAngle, maxAngle), 0) * baseDirection;
        rb.AddForce(direction * speed, ForceMode.Impulse);
    }

    void AllowReset()
    {
        isResetting = true;
    }


    void OnTriggerEnter(Collider other)
    {
        ResetBall();

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

    //public static void SpawnExtraBall(GameObject ballPrefab, Vector3 spawnPosition)
    //{
    //    Instantiate(ballPrefab, spawnPosition, Quaternion.identity);
    //    ballCount++;
    //}
}
//if (ballCount > 1)
//{
//    GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
//    foreach (GameObject ball in balls)
//    {
//        if (ball != gameObject)
//            Destroy(ball);
//    }
//    ballCount = 1;
//}
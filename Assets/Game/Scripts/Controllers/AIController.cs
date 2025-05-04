using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.Universal;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [Header("AI Settings")]

    [SerializeField] private MatchManager matchManager;

    public Transform ballTransform;
    public float predictionTime = 0.5f;
    public float smoothTime = 0.1f; // Smaller = more responsive
    private float difficultySpeedModifier;

    public Vector2 clampedXLimits= new Vector2(-0.445f, 0.3045f);

    private Vector3 targetPosition;
    private Vector3 velocityRef = Vector3.zero;
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        difficultySpeedModifier = GetSpeedModifierFromDifficulty();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement() 
    {
        // Check if ball is moving toward AI (positive z direction)
        Vector3 ballVelocity = ballTransform.GetComponent<Rigidbody>().velocity;

        // Check if the ball is heading towards the AI (positive z direction)
        if (ballVelocity.z > 0)
        {
            Vector3 predictedPosition = ballTransform.position + ballVelocity * predictionTime;
            targetPosition = new Vector3(predictedPosition.x, transform.position.y, transform.position.z);

            SmoothMoveToTarget();
        }
    }

    private void SmoothMoveToTarget()
    {
        Vector3 currentPosition = transform.position;

        // Smoothly interpolate position on X axis only
        Vector3 newPosition = Vector3.SmoothDamp(
            currentPosition,
            targetPosition,
            ref velocityRef,
            smoothTime,
            matchManager.players[1].characterData.speed * difficultySpeedModifier,
            Time.fixedDeltaTime
        );

        float clampedX = Mathf.Clamp(newPosition.x, clampedXLimits.x, clampedXLimits.y);

        rb.MovePosition(new Vector3(clampedX, currentPosition.y, currentPosition.z));

        rb.MovePosition(new Vector3(newPosition.x, currentPosition.y, currentPosition.z));
    }

    private float GetSpeedModifierFromDifficulty()
    {
        // Higher difficulty = higher speed
        switch (matchManager.players[1].difficulty)
        {
            case Character.DifficultyLevel.Easy: return 0.75f; 
            case Character.DifficultyLevel.Medium: return 1.0f; 
            case Character.DifficultyLevel.Hard: return 1.25f; 
            case Character.DifficultyLevel.Insane: return 1.5f; 
            default: return 1.0f;
        }
    }
}

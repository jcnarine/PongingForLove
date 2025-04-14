using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    [Header("AI Settings")]

    public AI date;
    public Transform ball;
    public Rigidbody rb;
    public float predictionTime = 0.5f;
    public float smoothTime = 0.1f; // Smaller = more responsive
    private float difficultySpeedModifier;
    public Vector2 clampedXLimits= new Vector2(-0.445f, 0.3045f);

    private Vector3 targetPosition;
    private Vector3 velocityRef = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        difficultySpeedModifier = GetSpeedModifierFromDifficulty();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement() 
    {
        // Check if ball is moving toward AI (positive z direction)
        Vector3 ballVelocity = ball.GetComponent<Rigidbody>().velocity;

        // Check if the ball is heading towards the AI (positive z direction)
        if (ballVelocity.z > 0)
        {
            Vector3 predictedPosition = ball.position + ballVelocity * predictionTime;
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
            date.fSpeed * difficultySpeedModifier,
            Time.fixedDeltaTime
        );

        float clampedX = Mathf.Clamp(newPosition.x, clampedXLimits.x, clampedXLimits.y);

        rb.MovePosition(new Vector3(clampedX, currentPosition.y, currentPosition.z));

        rb.MovePosition(new Vector3(newPosition.x, currentPosition.y, currentPosition.z));
    }

    private float GetSpeedModifierFromDifficulty()
    {
        // Higher difficulty = higher speed
        switch (date.difficulty)
        {
            case AI.DifficultyLevel.Easy: return 0.75f; 
            case AI.DifficultyLevel.Medium: return 1.0f; 
            case AI.DifficultyLevel.Hard: return 1.25f; 
            case AI.DifficultyLevel.Insane: return 1.5f; 
            default: return 1.0f;
        }
    }
}

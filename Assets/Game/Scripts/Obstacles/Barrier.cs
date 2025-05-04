using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Barrier : MonoBehaviour
{
    [SerializeField] private GameObject gameBoard;

    private bool isUsed = false;

    private bool isInitialized = false;

    private float duration;

    public void Initialize(float duration)
    {
        this.duration = duration;
        transform.SetParent(gameBoard.transform);
        isInitialized = true;
    }

    void Update()
    {
        if (!isInitialized) return;

        duration -= Time.deltaTime;
        if (duration <= 0f)
        {
            ForceDestroy();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isUsed) return;

        if (collision.collider.CompareTag("Ball"))
        {
            isUsed = true;
            Destroy(gameObject);
        }
    }

    public void ForceDestroy()
    {
        if (!isUsed)
        {
            Destroy(gameObject);
        }
    }
}

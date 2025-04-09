using System.Collections.Generic;
using UnityEngine;

public class HeartPool : MonoBehaviour
{
    [SerializeField] private GameObject heartUIPrefab;  // Reference to the heart prefab
    private Stack<GameObject> heartPool = new Stack<GameObject>();  // Stack to pool heart objects

    // Get an object from the pool
    public GameObject GetHeart()
    {
        if (heartPool.Count > 0)
        {
            GameObject heart = heartPool.Pop();  // Pop a heart object from the stack
            heart.SetActive(true);  // Make sure the heart is active
            return heart;
        }
        // If no objects are available in the pool, instantiate a new one
        GameObject newHeart = Instantiate(heartUIPrefab);
        return newHeart;  // Return the newly instantiated heart
    }

    // Return an object to the pool
    public void ReturnHeart(GameObject heart)
    {
        heart.SetActive(false);  // Deactivate the heart before returning it to the pool
        heartPool.Push(heart);   // Push the heart back onto the stack
    }
}
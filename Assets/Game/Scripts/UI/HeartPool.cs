using System.Collections.Generic;
using UnityEngine;

public class HeartPool : MonoBehaviour
{
    [SerializeField] private GameObject heartUIPrefab;
    private Stack<GameObject> heartPool = new Stack<GameObject>();

    public GameObject GetHeart()
    {
        if (heartPool.Count > 0)
        {
            GameObject heart = heartPool.Pop();
            heart.SetActive(true);
            return heart;
        }
        GameObject newHeart = Instantiate(heartUIPrefab);
        return newHeart;
    }

    public void ReturnHeart(GameObject heart)
    {
        heart.SetActive(false);
        heartPool.Push(heart);
    }
}
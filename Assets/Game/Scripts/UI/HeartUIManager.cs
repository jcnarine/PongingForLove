using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartUIManager : MonoBehaviour, IResettable
{
    [SerializeField] private Heart heart;
    private List<GameObject> hearts = new List<GameObject>();
    [SerializeField] private HeartPool heartObjectPool;  // Reference to the heart object pool

    public int heartTotal { get; set; }

    public void SpawnHeartUI()
    {
        for (int i = 0; i < heartTotal; i++)
        {
            GameObject heartObj = heartObjectPool.GetHeart();  // Get heart object from pool
            heartObj.transform.SetParent(transform, false);
            hearts.Add(heartObj);
            heartObj.SetActive(true);  // Ensure the heart is active
            Image heartImage = heartObj.GetComponent<Image>();
            heartImage.sprite = heart.heartEmpty;
        }
    }

    public void FillHeartAt(int index)
    {
        if (index < hearts.Count)
        {
            GameObject heartObj = hearts[index];
            Image heartImage = heartObj.GetComponent<Image>();
            heartImage.sprite = heart.heartFull;
            LayoutRebuilder.ForceRebuildLayoutImmediate(heartImage.rectTransform);
        }
    }

    public void DespawnAllHearts()
    {
        foreach (GameObject heart in hearts)
        {
            heartObjectPool.ReturnHeart(heart);  // Return heart to the pool
        }

        hearts.Clear();
    }

    public void ResetState()
    {
        DespawnAllHearts();
        SpawnHeartUI();
    }
}
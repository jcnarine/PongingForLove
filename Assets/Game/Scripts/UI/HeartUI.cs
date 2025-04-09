using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartUI : MonoBehaviour
{
    [SerializeField] private Heart heart;
    private List<GameObject> hearts = new List<GameObject>();
    [SerializeField] private Player player;
    [SerializeField] private HeartPool heartObjectPool;  // Reference to the heart object pool
    private int TotalLevel, currentRejectionLevel = 0, currentAffectionLevel = 0;
    private bool needUI;

    // Start is called before the first frame update
    void Start()
    {
        TotalLevel = player.livesTotal;
        needUI = player.isMainPlayer;
        initalizeHearts();
    }

    void initalizeHearts()
    {
        for (int i = 0; i < TotalLevel; i++)
        {
            GameObject heartObj = heartObjectPool.GetHeart();  // Get heart object from pool
            heartObj.transform.SetParent(transform, false);
            hearts.Add(heartObj);
            heartObj.SetActive(true);  // Ensure the heart is active
            Image heartImage = heartObj.GetComponent<Image>();
            heartImage.sprite = heart.heartEmpty;
        }
    }

    public void GainLevel()
    {
        if (needUI)
        {
            if (currentRejectionLevel < TotalLevel)
            {
                UpdateHeartSprite(currentRejectionLevel);
                currentRejectionLevel++;
            }

            if (currentRejectionLevel >= TotalLevel)
            {
                TriggerGameOver();
            }
        }
        else
        {
            if (currentAffectionLevel < TotalLevel)
            {
                UpdateHeartSprite(currentAffectionLevel);
                currentAffectionLevel++;
            }

            if (currentAffectionLevel >= TotalLevel)
            {
                TriggerNextPhase();
            }
        }
    }

    private void UpdateHeartSprite(int index)
    {
        if (index < hearts.Count)
        {
            GameObject heartObj = hearts[index];
            Image heartImage = heartObj.GetComponent<Image>();
            heartImage.sprite = heart.heartFull;
            LayoutRebuilder.ForceRebuildLayoutImmediate(heartImage.rectTransform);
        }
    }

    public void ClearHeartUI()
    {
        foreach (GameObject heart in hearts)
        {
            heartObjectPool.ReturnHeart(heart);  // Return heart to the pool
        }

        hearts.Clear();
    }

    private void TriggerGameOver()
    {
        Debug.Log("Game Over!");
        // Implement game state transition here
    }

    private void TriggerNextPhase()
    {
        Debug.Log("You won them over");
        currentRejectionLevel = 0;
        currentAffectionLevel = 0;
        ClearHeartUI();
        initalizeHearts();
        // Implement game state transition here
    }
}

    //[SerializeField] private Heart heart;
    //private List<GameObject> hearts = new List<GameObject>();
    //[SerializeField] private Player player;
    //[SerializeField] private GameObject heartUIPrefab;
    //private int TotalLevel, currentRejectionLevel=0, currentAffectionLevel=0;
    //private bool needUI;


    //// Start is called before the first frame update
    //void Start()
    //{
    //    TotalLevel = player.livesTotal;
    //    needUI = player.isMainPlayer;
    //    initalizeHearts();
    //}

    //void initalizeHearts()
    //{
    //    for (int i = 0; i < TotalLevel; i++)
    //    {
    //        GameObject heartObj = Instantiate(heartUIPrefab, transform);
    //        heartObj.transform.SetParent(transform, false);
    //        hearts.Add(heartObj);
    //        Image heartImage = hearts[i].GetComponent<Image>();
    //        heartImage.sprite = heart.heartEmpty;
    //    }
    //}

    //public void GainLevel()
    //{
    //    if (needUI)
    //    {
    //        if (currentRejectionLevel < TotalLevel)
    //        {
    //            UpdateHeartSprite(currentRejectionLevel);
    //            currentRejectionLevel++;
    //            //Debug.Log("Rejection Level Increased: " + currentRejectionLevel);

    //        }

    //        if (currentRejectionLevel >= TotalLevel)
    //        {
    //            TriggerGameOver();
    //        }
    //    }
    //    else 
    //    {
    //        if (currentAffectionLevel < TotalLevel)
    //        {
    //            UpdateHeartSprite(currentAffectionLevel);
    //            currentAffectionLevel++;
    //            //Debug.Log("Affection Level Increased: " + currentAffectionLevel);
    //        }

    //        if (currentAffectionLevel >= TotalLevel)
    //        {
    //            TriggerNextPhase();
    //        }
    //    }

    //}
    //private void UpdateHeartSprite(int index)
    //{
    //    if (index < hearts.Count)
    //    {
    //        Image heartImage = hearts[index].GetComponent<Image>();
    //        heartImage.sprite = heart.heartFull;
    //        //Debug.Log("Heart Icon Changed at:" + hearts[index]);
    //        LayoutRebuilder.ForceRebuildLayoutImmediate(heartImage.rectTransform);
    //    }
    //}
    //public void ClearHeartUI()
    //{
    //    foreach (GameObject heart in hearts)
    //    {
    //        Destroy(heart);
    //    }
    //    hearts.Clear();
    //}
    //private void TriggerGameOver()
    //{
    //    Debug.Log("Game Over!");
    //    // Implement game state transition here
    //}

    //private void TriggerNextPhase()
    //{
    //    Debug.Log("You won them over");
    //    currentRejectionLevel = 0;
    //    currentAffectionLevel = 0;
    //    ClearHeartUI();
    //    initalizeHearts();
    //    // Implement game state transition here
    //}
//}

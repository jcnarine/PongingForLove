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
    [SerializeField] private GameObject heartUIPrefab;
    private int TotalLevel, currentRejectionLevel=0, currentAffectionLevel=0;
    private bool needUI;


    // Start is called before the first frame update
    void Start()
    {
        TotalLevel = player.livesTotal;
        needUI = player.isMainPlayer;
        initalizeHearts();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void initalizeHearts()
    {
        for (int i = 0; i < TotalLevel; i++)
        {
            GameObject heartObj = Instantiate(heartUIPrefab, transform);
            heartObj.transform.SetParent(transform, false);
            hearts.Add(heartObj);
            Image heartImage = hearts[i].GetComponent<Image>();
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
                //Debug.Log("Rejection Level Increased: " + currentRejectionLevel);

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
                //Debug.Log("Affection Level Increased: " + currentAffectionLevel);
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
            Image heartImage = hearts[index].GetComponent<Image>();
            heartImage.sprite = heart.heartFull;
            //Debug.Log("Heart Icon Changed at:" + hearts[index]);

            Canvas.ForceUpdateCanvases();
        }
    }
    public void ClearHeartUI()
    {
        foreach (GameObject heart in hearts)
        {
            Destroy(heart);
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

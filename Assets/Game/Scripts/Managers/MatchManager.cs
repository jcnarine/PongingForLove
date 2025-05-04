using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchManager : MonoBehaviour
{
    public UIManager uiManager;
    public GameManager gameManager;
    public BallController ballController;


    public Character[] players;
    
    //public CharacterData[] characterDatas;

    public int totalPlayersCount;

    public int rejectionLevel = 0;
    public int affectionLevel = 0;

    public int maxPassionLevel = 5;
    public int minPassionLevel = 0;

    public float WaitTime = 4f;


    public void Start()
    {
        uiManager.InitializeUI();
        ballController.Launch();
    }

    public void ResetRound()
    {
        ballController.ResetState();
    }

    public void HandlePointScored(bool isMainPlayerScoring)
    {
        if (isMainPlayerScoring)
        {
            TryIncreaseAffection();
        }
        else
        {
            TryIncreaseRejection();
        }
    }

    private void TryIncreaseAffection()
    {
        if (affectionLevel < players[1].characterData.maxLives)
        {
            uiManager.heartUIManagers[0].FillHeartAt(affectionLevel);
            affectionLevel++;
        }
        else
        {
            gameManager.TriggerNextPhase();
        }
    }

    private void TryIncreaseRejection()
    {
        if (rejectionLevel < players[0].characterData.maxLives)
        {
            uiManager.heartUIManagers[1].FillHeartAt(rejectionLevel);
            rejectionLevel++;
        }
        else
        {
            gameManager.TriggerGameOver();
        }
    }
}

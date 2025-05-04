using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private MatchManager matchController;

    public HeartUIManager[] heartUIManagers;
    public PassionUIManager passionUIManager;
    public PowerupUIManager powerupUIManager;

    public void InitializeUI()
    {
        SetHeartTotalValues();
        SetPassionUI();
    }

    public void SetPowerupUI() 
    {
        powerupUIManager.InventoryTotal = matchController.players[0].powerups.Length;
        powerupUIManager.initializePowerupUI(matchController.players[0]);
    }

    public void SetPassionUI()
    {
        passionUIManager.maxPassion = matchController.maxPassionLevel;
        passionUIManager.currentPassionLevel = matchController.players[0].currentPassion;
        passionUIManager.UpdatePassionMeter();
    }

    private void SetHeartTotalValues()
    {
        for (int i = 0; i < heartUIManagers.Length; i++)
        {
            heartUIManagers[i].heartTotal = matchController.players[i].characterData.maxLives;
            heartUIManagers[i].SpawnHeartUI();
        }
    }
}

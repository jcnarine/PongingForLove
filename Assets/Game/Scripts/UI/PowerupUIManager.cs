using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PowerupUIManager : MonoBehaviour
{
    //References
    public List<PowerupUI> powerupIcons = new List<PowerupUI>();
    [SerializeField] private Player player;
    [SerializeField] private GameObject powerupPrefab;

    //Player Info
    private int InventoryTotal;


    // Start is called before the first frame update
    public void Start()
    {
        InventoryTotal = player.powerups.Length;
        initalizePowerupUI();
    }

    public void initalizePowerupUI()
    {

        for (int i = 0; i < InventoryTotal; i++)
        {
            GameObject powerupObj = Instantiate(powerupPrefab, transform);
            PowerupUI currentPowerUpUI = powerupObj.GetComponent<PowerupUI>();

            currentPowerUpUI.assignedPowerup = player.powerups[i];

            currentPowerUpUI.Initalize();
            currentPowerUpUI.InitalizeIcons(i);
            powerupIcons.Add(currentPowerUpUI);
        }
    }

    public void activatingUI(int Index) 
    {
        powerupIcons[Index].activateUIEffect();
        powerupIcons[Index].TriggerCooldown();
    }

    public void deactivatingUI(int Index) 
    {
        powerupIcons[Index].showNoActivation();
    }
    public void clearPowerups()
    {
        powerupIcons.Clear();
    }
}

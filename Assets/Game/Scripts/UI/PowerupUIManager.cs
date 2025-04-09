using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PowerupUIManager : MonoBehaviour
{
    private List<GameObject> powerupIcons = new List<GameObject>();
    [SerializeField] private Player player;
    [SerializeField] private GameObject powerupPrefab;
    int InventoryTotal;

    bool activatingPowerup=false;
    bool disabledPowerup=false;
    int activatedIndex=0;

    [Header("Input Mapping")]
    private string[] dpadButtons = { "/XInputControllerWindows/dpad/up", "/XInputControllerWindows/dpad/right", "/XInputControllerWindows/dpad/down", "/XInputControllerWindows/dpad/left" };

    // Start is called before the first frame update
    public void Start()
    {
        InventoryTotal = player.powerups.Length;
        initalizePowerupUI();
    }

    // Update is called once per frame
    public void Update()
    {

    }

    public void PressPowerUp(InputAction.CallbackContext context)
    {
        for (int i = 0; i < InventoryTotal; i++)
        {
            PowerupUI currentPowerUpUI = powerupIcons[i].GetComponent<PowerupUI>();

            if ((context.control.path == currentPowerUpUI.dpadCommand))
            {
                if (player.currentPassionLevel == currentPowerUpUI.passionNeeded)
                {
                    activatingPowerup = true;
                }
                else 
                { 
                    disabledPowerup = true;
                }

                activatedIndex = i;
                break;
            }
        }
    }

    public void initalizePowerupUI()
    {
        for (int i = 0; i < InventoryTotal; i++)
        {
            GameObject powerupObj = Instantiate(powerupPrefab, transform);
            PowerupUI currentPowerUpUI = powerupObj.GetComponent<PowerupUI>();

            currentPowerUpUI.assignedPowerup = player.powerups[i];
            currentPowerUpUI.dpadCommand = dpadButtons[i];

            currentPowerUpUI.Initalize();
            powerupIcons.Add(powerupObj);
        }
    }

    public void FixedUpdate()
    {
        if (activatingPowerup) 
        {
            PowerupUI currentPowerUpUI = powerupIcons[activatedIndex].GetComponent<PowerupUI>();
            currentPowerUpUI.activateUIEffect();
            activatingPowerup = false;
        }
        if (disabledPowerup) 
        {
            PowerupUI currentPowerUpUI = powerupIcons[activatedIndex].GetComponent<PowerupUI>();
            currentPowerUpUI.showNoActivation();
            disabledPowerup = false;
        }
    }
    public void clearPowerups()
    {
        powerupIcons.Clear();
    }
}

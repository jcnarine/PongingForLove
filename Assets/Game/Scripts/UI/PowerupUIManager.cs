using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PowerupUIManager : MonoBehaviour
{
    //References
    private List<GameObject> powerupIcons = new List<GameObject>();
    [SerializeField] private Player player;
    [SerializeField] private GameObject powerupPrefab;

    //Player Info
    private int InventoryTotal;

    //Powerup State Flags
    private bool buttonPressed = false;
    private bool activatingPowerup = false;
    private bool disabledPowerup = false;
    private int activatedIndex = 0;

    //Dpad Button Mapping
    private string[] dpadButtons = { "/XInputControllerWindows/dpad/up", "/XInputControllerWindows/dpad/right", "/XInputControllerWindows/dpad/down", "/XInputControllerWindows/dpad/left" };
    private string currentContext;


    // Start is called before the first frame update
    public void Start()
    {
        InventoryTotal = player.powerups.Length;
        initalizePowerupUI();
    }

    // Update is called once per frame
    public void Update()
    {
        if (buttonPressed)
        {
            CheckPowerups();    
        }
    }



    public void CheckPowerups() 
    {
        //Debug.Log($"Powerups: {player.powerups.Length}, DPad slots: {dpadButtons.Length}, InventoryTotal: {InventoryTotal}");

        for (int i = 0; i < InventoryTotal; i++)
        {
            PowerupUI currentPowerUpUI = powerupIcons[i].GetComponent<PowerupUI>();

            if ((currentContext == currentPowerUpUI.dpadCommand))
            {
                if (player.currentPassionLevel == currentPowerUpUI.passionNeeded && !currentPowerUpUI.isOnCooldown)
                {
                    activatingPowerup = true;
                }
                else
                {
                    disabledPowerup = true;
                }

                activatedIndex = i;
                buttonPressed = false;
                currentContext = null;
                break;
            }
        }
    }
    public void PressPowerUp(InputAction.CallbackContext context)
    {
        buttonPressed = true;
        currentContext = context.control.path;   
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
            currentPowerUpUI.TriggerCooldown();
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

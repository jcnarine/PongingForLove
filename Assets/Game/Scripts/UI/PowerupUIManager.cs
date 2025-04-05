using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupUIManager : MonoBehaviour
{
    private List<GameObject> powerupIcons = new List<GameObject>();
    [SerializeField] private Player player;
    [SerializeField] private GameObject powerupPrefab;
    int InventoryTotal;

    [Header("Input Mapping")]
    public KeyCode[] keyboardKeys = { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4 };
    public string[] dpadButtons = { "DPadUp", "DPadRight", "DPadDown", "DPadLeft" };

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

    public void initalizePowerupUI()
    {
        for (int i = 0; i < InventoryTotal; i++)
        {
            GameObject powerupObj = Instantiate(powerupPrefab, transform);
            PowerupUI currentPowerUpUI = powerupObj.GetComponent<PowerupUI>();

            currentPowerUpUI.assignedPowerup = player.powerups[i];
            currentPowerUpUI.dpadCommand = dpadButtons[i];
            currentPowerUpUI.keyboardCommand = keyboardKeys[i];

            currentPowerUpUI.Initalize();
            powerupIcons.Add(powerupObj);
        }
    }
    public void clearPowerups()
    {
        powerupIcons.Clear();
    }
}

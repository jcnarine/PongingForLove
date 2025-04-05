using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerupUI : MonoBehaviour
{
    public Button powerupButton;
    public Button controlButton;
    public Image passionBorder;
    public Image powerupBorder;
    public Image controlBorder;
    public TextMeshProUGUI passionText;
    public Powerup assignedPowerup;

    public Sprite[] spriteSheetDPAD;

    public string dpadCommand;
    public KeyCode keyboardCommand;

    public void Initalize()
    {
        powerupButton.image = assignedPowerup.IconThumbnail;
        passionBorder = assignedPowerup.PassionBorder;
        powerupBorder = assignedPowerup.PowerupBorder;
        controlBorder = assignedPowerup.ControlBorder;
        passionText.text = assignedPowerup.PassionNeeded.ToString();
    }


    public void InitalizeDPadIcon() 
    {
        switch
                (dpadCommand) {

            case ("DPadUp"):
                controlButton.image.sprite = spriteSheetDPAD[1];
                break;

            case ("DPadRight"):
                controlButton.image.sprite = spriteSheetDPAD[2];
                break;

            case ("DPadDown"):
                controlButton.image.sprite = spriteSheetDPAD[3];
                break;

            case ("DPadLeft"):
                controlButton.image.sprite = spriteSheetDPAD[4];
                break;


}
    
    
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

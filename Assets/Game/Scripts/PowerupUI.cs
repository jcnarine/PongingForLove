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

    public int passionNeeded;

    public string dpadCommand;
    public KeyCode keyboardCommand;

    public void Initalize()
    {
        powerupButton.image.sprite = assignedPowerup.IconThumbnail;
        passionBorder.sprite = assignedPowerup.PassionBorder;
        powerupBorder.sprite = assignedPowerup.PowerupBorder;
        controlBorder.sprite = assignedPowerup.ControlBorder;


        passionNeeded = assignedPowerup.PassionNeeded;
        passionText.text = passionNeeded.ToString();
        InitalizeDPadIcon();
    }


    private void InitalizeDPadIcon() 
    {
        switch
                (dpadCommand) {

            case ("DPadUp"):
                controlButton.image.sprite = spriteSheetDPAD[0];
                break;

            case ("DPadRight"):
                controlButton.image.sprite = spriteSheetDPAD[1];
                break;

            case ("DPadDown"):
                controlButton.image.sprite = spriteSheetDPAD[2];
                break;

            case ("DPadLeft"):
                controlButton.image.sprite = spriteSheetDPAD[3];
                break;


}
    
    
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetButtonDown(dpadCommand))
    //    {
    //        Debug.Log("Power Activated");
    //    }
    //}
}

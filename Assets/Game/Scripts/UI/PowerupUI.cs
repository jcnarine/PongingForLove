using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PowerupUI : MonoBehaviour
{
    [SerializeField] private Button powerupButton;
    [SerializeField] private Button controlButton;
    [SerializeField] private Image passionBorder;
    [SerializeField] private Image powerupBorder;
    [SerializeField] private Image controlBorder;
    [SerializeField] private TextMeshProUGUI passionText;

    public Powerup assignedPowerup;


    [SerializeField] private Sprite[] spriteSheetDPAD;

    public int passionNeeded;
    public string dpadCommand;

    private float UIEffectTimer=0.1f;


    [SerializeField] private string currentContext;

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
        switch (dpadCommand)
        {

            case ("/XInputControllerWindows/dpad/up"):
                controlButton.image.sprite = spriteSheetDPAD[0];
                break;

            case ("/XInputControllerWindows/dpad/right"):
                controlButton.image.sprite = spriteSheetDPAD[1];
                break;

            case ("/XInputControllerWindows/dpad/down"):
                controlButton.image.sprite = spriteSheetDPAD[2];
                break;

            case ("/XInputControllerWindows/dpad/left"):
                controlButton.image.sprite = spriteSheetDPAD[3];
                break;


        }


    }
    public void activateUIEffect()
    {
        powerupButton.image.color = powerupButton.colors.pressedColor;
        LayoutRebuilder.ForceRebuildLayoutImmediate(powerupButton.GetComponent<RectTransform>());
        StartCoroutine(disableUIEffect());
    }
    
    public void showNoActivation()
    {
        powerupButton.image.color = powerupButton.colors.disabledColor;
        LayoutRebuilder.ForceRebuildLayoutImmediate(powerupButton.GetComponent<RectTransform>());
        StartCoroutine(disableUIEffect());
    }

    IEnumerator disableUIEffect()
    {
        yield return new WaitForSeconds(UIEffectTimer);

        powerupButton.image.color = powerupButton.colors.normalColor;
        LayoutRebuilder.ForceRebuildLayoutImmediate(powerupButton.GetComponent<RectTransform>());
    }
}

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
    [Header("UI References")]

    [SerializeField] private Button powerupButton;
    [SerializeField] private Button controlButton;
    [SerializeField] private Image passionBorder;
    [SerializeField] private Image powerupBorder;
    [SerializeField] private Image controlBorder;
    [SerializeField] private TextMeshProUGUI passionText;

    [Header("Cooldown UI")]

    [SerializeField] private Image cooldownOverlay;
    [SerializeField] private TextMeshProUGUI cooldownText;

    [Header("Cooldown Settings")]

    [SerializeField] private float startAlpha = 0.5f;
    [SerializeField] private float endAlpha = 0f;


    [Header("Local Variables Settings")]

    public Powerup assignedPowerup;
    [SerializeField] private Sprite[] spriteSheetDPAD;
    private float UIEffectTimer=0.1f;
    public string dpadCommand;
    public int passionNeeded;


    public bool isOnCooldown = false;
    private float cooldownTimer;

    public void Initalize()
    {
        powerupButton.image.sprite = assignedPowerup.IconThumbnail;
        passionBorder.sprite = assignedPowerup.PassionBorder;
        powerupBorder.sprite = assignedPowerup.PowerupBorder;
        controlBorder.sprite = assignedPowerup.ControlBorder;


        passionNeeded = assignedPowerup.PassionNeeded;
        passionText.text = passionNeeded.ToString();
        cooldownText.gameObject.SetActive(false);
        cooldownOverlay.gameObject.SetActive(false);
        InitalizeDPadIcon();
    }

    public void Update()
    {
        if (isOnCooldown) 
        { 
            updateCooldownEffect();
        }
    }

    public void updateCooldownEffect() 
    {
        cooldownTimer -= Time.deltaTime;
        float t = Mathf.Clamp01(cooldownTimer / assignedPowerup.Duration);

        cooldownOverlay.fillAmount = t;
        float alpha = Mathf.Lerp(endAlpha, startAlpha, t);
        cooldownOverlay.color = new Color(cooldownOverlay.color.r, cooldownOverlay.color.g, cooldownOverlay.color.b, alpha);

        cooldownText.text = Mathf.CeilToInt(cooldownTimer).ToString();

        if (cooldownTimer <= 0f)
        {
            isOnCooldown = false;
            cooldownOverlay.fillAmount = 0f;
            cooldownOverlay.color = new Color(cooldownOverlay.color.r, cooldownOverlay.color.g, cooldownOverlay.color.b, 0);
            cooldownText.gameObject.SetActive(false);
        }
    }

    public void TriggerCooldown()
    {
        cooldownTimer = assignedPowerup.Duration;
        isOnCooldown = true;

        cooldownOverlay.fillAmount = 1f;
        cooldownOverlay.color = new Color(cooldownOverlay.color.r, cooldownOverlay.color.g, cooldownOverlay.color.b, startAlpha);

        cooldownText.gameObject.SetActive(true);
        cooldownOverlay.gameObject.SetActive(true);
        cooldownText.text = Mathf.CeilToInt(cooldownTimer).ToString();
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

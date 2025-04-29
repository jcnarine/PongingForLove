using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor.Build.Pipeline.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

public class PowerupManager : MonoBehaviour
{

    public Player[] players;

    public PowerupUIManager powerupUIManager;
    public List<GameObject> PowerupUIManagerList;

    private bool buttonPressed = false;

    private int activatedIndex;

    public void PressPowerUp1(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            activatedIndex = 0;
            buttonPressed = true;
        }
    }

    public void PressPowerUp2(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            activatedIndex = 1;
            buttonPressed = true;
        }
    }

    public void PressPowerUp3(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            activatedIndex = 2;
            buttonPressed = true;
        }
    }

    public void PressPowerUp4(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            activatedIndex = 3;
            buttonPressed = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonPressed)
        {
            CheckPowerups();
            buttonPressed = false;
        }
    }

    public void CheckPowerups()
    {
        Player currentPlayer = players[0]; // Assuming single-player for now

        if (activatedIndex < 0 || activatedIndex >= currentPlayer.powerups.Length)
            return;

        var powerup = currentPlayer.powerups[activatedIndex];

        if (currentPlayer.currentPassionLevel >= powerup.PassionNeeded && !powerup.onCooldown && (powerup.isInfiniteUses || powerup.Uses>0))
        {
            players[0].powerups[activatedIndex].onCooldown = true;
            powerupUIManager.activatingUI(activatedIndex);
            if (!powerup.isInfiniteUses) 
            {
                powerup.Uses--;
            }


        }
        else
        {
            powerupUIManager.deactivatingUI(activatedIndex);
        }
    }

}

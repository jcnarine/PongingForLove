using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor.Build.Pipeline.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

public class PowerupManager : MonoBehaviour
{

    private Character[] players;

    public MatchManager matchController;

    [NonSerialized] public bool buttonPressed = false;

    [NonSerialized] public int activatedIndex;


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
        Character currentPlayer = players[0]; // Assuming single-player for now

        if (activatedIndex < 0 || activatedIndex >= currentPlayer.powerups.Length)
            return;

        var powerup = currentPlayer.powerups[activatedIndex];

        if (currentPlayer.currentPassion >= powerup.powerData.PassionNeeded && !powerup.powerData.onCooldown && (powerup.powerData.isInfiniteUses || powerup.uses > 0))
        {

            currentPlayer.powerups[activatedIndex].powerData.onCooldown = true;

            //players[0].powerups[activatedIndex].statusEffects.apply();
            //players[0].powerups[activatedIndex].Activate(Player, AI, Ball);

            //powerupUIManager.activatingUI(activatedIndex);

            if (!powerup.powerData.isInfiniteUses) 
            {
                powerup.uses--;
            }


        }
        else
        {
            //powerupUIManager.deactivatingUI(activatedIndex);
        }
    }

}

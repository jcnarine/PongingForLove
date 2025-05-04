using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public PlayerInput playerInput;

    public PowerupManager powerupManager;
    public PauseManager pauseManager;

    private void PressPowerUp(InputAction.CallbackContext context, int index)
    {
        if (context.performed)
        {
            powerupManager.activatedIndex = index;
            powerupManager.buttonPressed = true;
        }
    }

    public void PressPowerUp1(InputAction.CallbackContext context) => PressPowerUp(context, 0);
    public void PressPowerUp2(InputAction.CallbackContext context) => PressPowerUp(context, 1);
    public void PressPowerUp3(InputAction.CallbackContext context) => PressPowerUp(context, 2);
    public void PressPowerUp4(InputAction.CallbackContext context) => PressPowerUp(context, 3);

    public void PressMenu(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            pauseManager.triggerChange = true;
            playerInput.SwitchCurrentActionMap("UI");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public PlayerInput playerInput;
    public Volume blurVolume; // For post-processing blur

    void Start()
    {
        pauseMenuUI.SetActive(false);
        if (blurVolume != null)
            blurVolume.weight = 0f;
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            PauseGame();
        }
    }

    public void OnResume(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ResumeGame();   
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
        if (blurVolume != null)
            blurVolume.weight = 1f;

        playerInput.SwitchCurrentActionMap("UI");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        if (blurVolume != null)
            blurVolume.weight = 0f;

        playerInput.SwitchCurrentActionMap("Player");
    }
}

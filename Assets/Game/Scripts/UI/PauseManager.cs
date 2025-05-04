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

    public bool isPaused = false, triggerChange = false;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
        if (blurVolume != null)
            blurVolume.weight = 0f;
    }

    private void Update()
    {
        if (triggerChange) 
        {
            SetPauseState(!isPaused);
            triggerChange = false;
        }
    }

    private void SetPauseState(bool pause)
    {
        isPaused = pause;
        Time.timeScale = pause ? 0f : 1f;
        pauseMenuUI.SetActive(pause);

        if (blurVolume != null)
            blurVolume.weight = pause ? 1f : 0f;
    }
}

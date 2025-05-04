using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool nextScene, isGameOver;

    public void TriggerGameOver()
    {
        Debug.Log("Game Over!");
        // Implement game state transition here
    }

    public void TriggerNextPhase()
    {
        Debug.Log("You won them over");
        ResetAll();
    // Implement game state transition here
    }
    public void ResetAll()
    {
        //foreach (var resettable in FindObjectsOfType<MonoBehaviour>(true).OfType<IResettable>())
        //    resettable.ResetState();
    }
}

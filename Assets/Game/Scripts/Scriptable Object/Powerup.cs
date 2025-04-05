using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PowerupType
{
    Slowdown,
    BigPaddle,
    SpawnBlocker,
}

[CreateAssetMenu(fileName = "Powerup", menuName = "Scriptable Objects/Powerup")]

public class Powerup : ScriptableObject
{
    public Image IconThumbnail, ControlImage;
    public Image PassionBorder, PowerupBorder, ControlBorder;
    public PowerupType powerupType;
    public int PassionNeeded, Duration;
    public string PowerDescription;
}


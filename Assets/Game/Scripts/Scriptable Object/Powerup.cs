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
    public Sprite IconThumbnail;
    public Sprite PassionBorder, PowerupBorder, ControlBorder;
    public PowerupType powerupType;
    public int PassionNeeded, Duration, Uses;
    public string PowerDescription;
    public bool onCooldown, isInfiniteUses;
}


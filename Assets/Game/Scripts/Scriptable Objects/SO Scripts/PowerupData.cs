using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Powerup", menuName = "Scriptable Objects/Powerup")]

public class PowerupData : ScriptableObject
{
    public StatusEffectData[] statusEffects;
    public int PassionNeeded;
    public bool onCooldown, isInfiniteUses;

}


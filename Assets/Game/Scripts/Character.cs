using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterData characterData;
    public StatusEffectManager statusEffectManager;
    public Powerup[] powerups;

    public int currentPassion=0;

    private void Awake()
    {
        statusEffectManager = GetComponent<StatusEffectManager>();
    }

    public enum DifficultyLevel { Null, Easy, Medium, Hard, Insane }
    public DifficultyLevel difficulty;
}

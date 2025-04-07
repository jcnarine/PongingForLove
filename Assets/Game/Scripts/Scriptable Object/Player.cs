using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Paddle", menuName = "Scriptable Objects/Paddle")]

public class Player : ScriptableObject
{
    public float fSpeed;
    public string Name;
    public int livesTotal;
    public bool isMainPlayer;
    public Powerup[] powerups;
}

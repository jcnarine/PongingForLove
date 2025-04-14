using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AI", menuName = "Scriptable Objects/AI")]
public class AI : Player
{
    public enum DifficultyLevel { Easy, Medium, Hard, Insane }
    public DifficultyLevel difficulty;

    [Header("AI Visuals")]
    public Sprite defaultBodySprite;
    public Sprite[] bodyVariants;

    public Sprite defaultFaceSprite;
    public Sprite[] faceVariants;

    public Sprite defaultEyesSprite;
    public Sprite[] eyeVariants;
}
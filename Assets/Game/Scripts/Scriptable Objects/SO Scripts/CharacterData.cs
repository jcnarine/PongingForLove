using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Scriptable Objects/Character/CharacterData")]

public class CharacterData : ScriptableObject
{
    public string characterName, characterBio;
    public int maxLives, maxPassion;
    public float speed;

    public CharacterGraphics characterGraphics;
}

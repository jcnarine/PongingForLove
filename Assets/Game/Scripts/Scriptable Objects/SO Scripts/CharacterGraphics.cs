using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterGraphics", menuName = "Scriptable Objects/Character/CharacterGraphics")]
public class CharacterGraphics : ScriptableObject
{
    public Sprite defaultBodySprite;
    public Sprite[] bodyVariants;

    public Sprite defaultFaceSprite;
    public Sprite[] faceVariants;

    public Sprite defaultEyesSprite;
    public Sprite[] eyeVariants;
}

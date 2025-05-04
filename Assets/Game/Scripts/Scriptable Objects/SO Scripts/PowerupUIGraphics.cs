using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerupUIGraphics", menuName = "Scriptable Objects/Powerup")]

public class PowerupUIGraphics : ScriptableObject
{
    public Sprite IconThumbnail;
    public Sprite PassionBorder;
    public Sprite PowerupBorder;
    public Sprite ControlBorder;
    public string PowerDescription;
}

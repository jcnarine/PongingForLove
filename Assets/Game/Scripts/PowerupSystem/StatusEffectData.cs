using UnityEngine;

public abstract class StatusEffectData : ScriptableObject
{
    public string effectName => name; // Uses ScriptableObject asset name
    public string effectDescription;

    public float lifetime;
    public float currentEffectTime;

    //public GameObject effectParticles;

    public abstract void Apply();
    public abstract void Remove();
}

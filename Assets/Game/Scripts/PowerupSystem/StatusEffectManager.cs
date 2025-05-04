using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectManager : MonoBehaviour, IEffectable
{
    private List<StatusEffectData> activeEffects;

    private void Update()
    {
        
    }

    public void HandleEffect() 
    {
        //foreach (var effect in activeEffects) 
        //{ 
        
        
        //}
        //for (int i = activeEffects.Count - 1; i >= 0; i--)
        //{
        //    activeEffects[i].Timer -= Time.deltaTime;
        //    if (activeEffects[i].Timer <= 0f)
        //    {
        //        activeEffects[i].Data.Remove();
        //        activeEffects.RemoveAt(i);
        //    }
        //}
    }

    public void ApplyEffect(StatusEffectData data)
    {
        data.Apply();
    }

    public void RemoveEffect()
    {
        
    }
}

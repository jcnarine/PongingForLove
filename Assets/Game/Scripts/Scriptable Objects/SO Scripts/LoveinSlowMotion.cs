using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LoveInSlowMotion", menuName = "Scriptable Objects/Powerup/Love In Slow Motion")]
public class LoveinSlowMotion : PowerupData
{
    //public override void Activate(GameObject User, GameObject Enemy, GameObject Ball)
    //{
    //    SlowTimeExceptPlayer(User);
    //}

    //private IEnumerator SlowTimeExceptPlayer(GameObject User)
    //{
    //    User.GetComponent<PlayerMovement>().paddleSpeed *= 2;
    //    Time.timeScale = 0.5f;
    //    yield return new WaitForSecondsRealtime(EffectDuration);
    //    User.GetComponent<PlayerMovement>().paddleSpeed /= 2;
    //    Time.timeScale = 1f;
    //}
}

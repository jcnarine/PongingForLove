using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class TimerUI : MonoBehaviour
{
    public TextMeshProUGUI TextPro;
    private float time;

    // Update is called once per frame
    void Update()
    {
        time += 1 * Time.deltaTime;
        TextPro.text = Mathf.RoundToInt(time).ToString();
    }
}

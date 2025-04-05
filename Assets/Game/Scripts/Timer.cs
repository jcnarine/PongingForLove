using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI TextPro;
    private float fTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fTime += 1 * Time.deltaTime;
        TextPro.text = Mathf.RoundToInt(fTime).ToString();
    }
}

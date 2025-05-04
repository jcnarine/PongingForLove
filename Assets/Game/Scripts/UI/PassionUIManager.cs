using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PassionUIManager : MonoBehaviour
{
    [SerializeField] private Slider passionSlider;
    [SerializeField] private Image fillImage;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private TextMeshProUGUI text;
    
    public int maxPassion { get; set; }
    public int currentPassionLevel { get; set; }

    [SerializeField] private Color passionColor = new Color(1f, 0.5f, 0.8f);

    public void UpdatePassionMeter()
    {
        // Update the fill color to reflect the passion level
        int fillAmount = currentPassionLevel / maxPassion;

        if (fillAmount > 0)
        {
            // Update fill color to pink based on passion level
            fillImage.color = Color.Lerp(Color.white, passionColor, fillAmount);
        }

        // Update the slider's value
        passionSlider.value = currentPassionLevel;
    }
}

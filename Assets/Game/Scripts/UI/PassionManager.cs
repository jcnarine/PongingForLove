using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PassionManager : MonoBehaviour
{
    [SerializeField] private Slider passionSlider;  // Reference to the Slider component (Passion Meter UI)
    [SerializeField] private Image fillImage;  // Image of the fill area to change the color
    [SerializeField] private Image backgroundImage; // Background image (for notches and meter style)
    [SerializeField] private TextMeshProUGUI text; // Background image (for notches and meter style)

    [SerializeField] private int maxPassion = 5;  // Max Passion level (can be customized per player)

    [SerializeField] private Color passionColor = new Color(1f, 0.5f, 0.8f);  // Pink color for passion

    [SerializeField] private Player player;

    private Material fillMaterial;  // Material of the fill image to apply shaders

    private void Start()
    {
        if (passionSlider != null)
        {
            maxPassion = player.PassionMax;
            passionSlider.maxValue = maxPassion;  // Set max passion for the slider
            text.text = player.currentPassionLevel.ToString();
            passionSlider.value = player.currentPassionLevel;
            fillMaterial = fillImage.material;
            UpdatePassionMeter();
        }
    }

    private void UpdatePassionMeter()
    {
        // Update the fill color to reflect the passion level
        int fillAmount = player.currentPassionLevel / maxPassion;

        if (fillMaterial != null && fillAmount > 0)
        {
            // Update fill color to pink based on passion level
            fillImage.color = Color.Lerp(Color.white, passionColor, fillAmount);
        }

        // Update the slider's value
        passionSlider.value = player.currentPassionLevel;

        // Update notches (this can be done by updating the background texture or adding icons for the notches)
        UpdateNotches();
    }

    private void UpdateNotches()
    {
        // The background image can have a texture or lines representing the notches
        // Update the notch visual on the background (e.g., by tiling a pattern or using a texture with notches)
        float notchWidth = backgroundImage.rectTransform.rect.width / maxPassion;

        // You can use the `notchWidth` to position or scale a texture that shows the notches.
        // This step can be customized based on your art and meter design.
    }
}

using Core;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSliderValue : MonoBehaviour
{
    public bool isMusicSlider = false;


    // Components
    private Slider slider;


    private void Awake()
    {
        // Components
        slider = GetComponent<Slider>();
    }


    private void LateUpdate()
    {
        UpdateValue();
    }


    public void UpdateValue()
    {
        // Update Value
        if (isMusicSlider) { slider.value = Save.Get(SaveConstants.Music, 1f); }
        else if (!isMusicSlider) { slider.value = Save.Get(SaveConstants.Sfx, 1f); }
    }
    public void SaveSliderValue() // Called on slider value change
    {
        // Update Value
        if (isMusicSlider) { Save.Set(SaveConstants.Music, slider.value); }
        else if (!isMusicSlider) { Save.Set(SaveConstants.Sfx, slider.value); }


        GameObject.FindObjectOfType<AudioManager>().UpdateVolumes();
    }
}

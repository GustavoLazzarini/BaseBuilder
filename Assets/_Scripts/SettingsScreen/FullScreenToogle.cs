using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Core;

public class FullScreenToogle : MonoBehaviour
{
    public bool canToggleFullscreen = false;


    // Components
    private Toggle toggle;


    // Scripts
    private AudioCue _AudioCue;


    private void Awake()
    {
        // Scripts
        _AudioCue = GetComponent<AudioCue>();


        // Components
        toggle = GetComponent<Toggle>();
    }


    // Called on settings open
    public void CheckFullscreenState()
    {
        if (Save.Get(SaveConstants.FullscreenState, 0) == 1) { toggle.isOn = true; canToggleFullscreen = true; }
        else if (Save.Get(SaveConstants.FullscreenState, 0) == 0) { toggle.isOn = false; canToggleFullscreen = true; }

        //Debug.Log("Fullscreen: " + SaveManager.LoadFullscreenState());
    }
    // Called on Toggle
    public void ToogleFullScreen()
    {
        if(canToggleFullscreen)
        {
            _AudioCue.PlayAudioCue();


            if (Save.Get(SaveConstants.FullscreenState, 0) == 1)
            {
                Screen.fullScreen = false;
                Save.Set(SaveConstants.FullscreenState, 0);
            }
            else
            {
                Screen.fullScreen = true;
                Save.Set(SaveConstants.FullscreenState, 1);
            }

            canToggleFullscreen = false;
        }
    }
}

using Core;
using UnityEngine;

public class FullscreenChecker : MonoBehaviour
{
    private void Start()
    {
        CheckFullscreen();
    }


    public void CheckFullscreen()
    {
        if(Save.Get(SaveConstants.FullscreenState, 0) == 1) { Screen.fullScreen = true; }
        else { Screen.fullScreen = false; }

        //Debug.Log("Fullscreen: " + SaveManager.LoadFullscreenState());
    }
}

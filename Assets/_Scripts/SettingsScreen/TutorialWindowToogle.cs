using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialWindowToogle : MonoBehaviour
{
    [SerializeField] GameObject tutorialWindow;
    [SerializeField] bool tutorialWindowOpen;

    public void ToogleTutorialWindow()
    {
        if (!tutorialWindowOpen)
        {
            tutorialWindow.SetActive(true);
        }
        else
        {
            tutorialWindow.SetActive(false);
        }
        tutorialWindowOpen = !tutorialWindowOpen;
    }
}

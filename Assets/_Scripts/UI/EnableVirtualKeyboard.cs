using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class EnableVirtualKeyboard : MonoBehaviour
{
    [SerializeField] GameObject virtualKeyboard;
    [SerializeField] GameObject firstButton;
    [SerializeField] GameObject buttonToReturn;

    [Space(30)]
    [SerializeField] Button[] buttonsToToogle;




    public void CheckIfCanEnable() // On input field select
    {
        Invoke("EnableVK", 0.1f);
    }
    public void EnableVK()
    {
        if (GetControllerType.instance.controllerType == CurrentController.Playstation || GetControllerType.instance.controllerType == CurrentController.Xbox)
        {
            virtualKeyboard.SetActive(true);


            for (int i = 0; i < buttonsToToogle.Length; i++)
            {
                buttonsToToogle[i].enabled = false;
            }


            // Set selected button
            Invoke("ChangeSelectedButtonn", 0.1f);
        }
    }
    void ChangeSelectedButtonn()
    {
        if (GameObject.FindObjectOfType<CursorManager>()) { GameObject.FindObjectOfType<CursorManager>().ChangeSelectedButton(firstButton); }
    }
    public void DisableVK()
    {
        virtualKeyboard.SetActive(false);


        for (int i = 0; i < buttonsToToogle.Length; i++)
        {
            buttonsToToogle[i].enabled = true;
        }

        // Set selected button
        if (GameObject.FindObjectOfType<CursorManager>()) { GameObject.FindObjectOfType<CursorManager>().ChangeSelectedButton(buttonToReturn); }
    }
}

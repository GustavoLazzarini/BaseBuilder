using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToogleGameObjects : MonoBehaviour
{
    #region Inspector
    [SerializeField] GameObject[] objectsToToogle;
    [SerializeField] GameObject[] objectsToDisable;
    public GameObject selectedButton;


    [Space(30)]
    [SerializeField] bool resizeToNormalSize;
    [SerializeField] GameObject[] objectsToResize;


    [Space(30)]
    [SerializeField] EnableVirtualKeyboard _EnableVirtualKeyboard;
    #endregion

    #region Components
    GameInput _GameInput;
    #endregion

    #region MonoBehaviours
    private void OnEnable()
    {
        _GameInput.Enable();
    }
    private void OnDisable()
    {
        _GameInput.Disable();
    }


    private void Awake()
    {
        _GameInput = new GameInput();
    }


    private void Update()
    {
        if (_GameInput.UI.Cancel.triggered) 
        {
            if(_EnableVirtualKeyboard != null) { _EnableVirtualKeyboard.DisableVK(); }


            Toogle();
            DisableObjects();


            if (GetComponent<AudioCue>()) { GetComponent<AudioCue>().PlayAudioCue(); }
        }
    }
    #endregion

    #region My Functions
    public void Toogle()
    {
        for (int i = 0; i < objectsToToogle.Length; i++)
        {
            objectsToToogle[i].SetActive(!objectsToToogle[i].activeSelf);
        }
        if(selectedButton != null) { GameObject.FindObjectOfType<CursorManager>().ChangeSelectedButton(selectedButton); }


        if (resizeToNormalSize) { SetNormalSize(); }
        else { SetZeroSize(); }
    }
    public void DisableObjects()
    {
        for (int i = 0; i < objectsToDisable.Length; i++)
        {
            objectsToDisable[i].SetActive(false);
        }
    }




    public void SetNormalSize()
    {
        for (int i = 0; i < objectsToResize.Length; i++)
        {
            objectsToResize[i].transform.localScale = new Vector3(1, 1, 1);
        }
    }
    public void SetZeroSize()
    {
        for (int i = 0; i < objectsToResize.Length; i++)
        { 
            objectsToResize[i].transform.localScale = new Vector3(0, 0, 0);
        }
    }
    #endregion
}

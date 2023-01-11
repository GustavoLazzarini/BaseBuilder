using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using Core;

public class CursorManager : MonoBehaviour
{
    #region Inspector
    public GameObject currentFirstButton;
    [SerializeField] BoolEventChannelSO pauseVoidEventChannelSO;

    bool isGameScene;
    bool isGamePaused;
    #endregion

    #region Components
    // Scripts
    private GameInput _GameInput;
    #endregion

    #region Monobehaviours
    private void Awake()
    {
        // Scripts
        _GameInput = new GameInput();
    }
    private void Start()
    {
        Cursor.visible = false;

        Save.Set(SaveConstants.MouseState, 0);        
        ChangeSelectedButton(currentFirstButton);


        if (GameObject.FindGameObjectWithTag("Player") == null) { isGameScene = false; }
        else { isGameScene = true; }
    }


    private void OnEnable()
    {
        _GameInput.Enable();


        if (pauseVoidEventChannelSO != null) { pauseVoidEventChannelSO.OnEventRaised += PauseEvent; }
    }
    private void OnDisable()
    {
        _GameInput.Disable();


        if (pauseVoidEventChannelSO != null) { pauseVoidEventChannelSO.OnEventRaised -= PauseEvent; }
    }


    private void Update()
    {
        if (!isGameScene) { CursorStateSwitch(); }
        else if (isGamePaused) { CursorStateSwitch(); }


        if (EventSystem.current.currentSelectedGameObject == null && Save.Get(SaveConstants.MouseState, 1) == 0)
        {
            if (currentFirstButton != null) { EventSystem.current.SetSelectedGameObject(currentFirstButton); }
        }
    }
    #endregion

    #region My Functions
    private void PauseEvent(bool state)
    {
        isGamePaused = state;

        if (isGamePaused)
        {
            if (Save.Get(SaveConstants.MouseState, 1) == 0) { Cursor.visible = false; }
            else { Cursor.visible = true; }
        }
        else if (!isGamePaused && isGameScene) { Cursor.visible = false; }
    }


    private void CursorStateSwitch()
    {
        // Controller
        if (_GameInput.UI.Navigate.triggered && EventSystem.current.currentSelectedGameObject == null)
        {
            Cursor.visible = false;

            Save.Set(SaveConstants.MouseState, 0);
            ChangeSelectedButton(currentFirstButton);
        }

        // Mouse
        if (_GameInput.UI.LeftClick.triggered)
        {
            Cursor.visible = true;

            Save.Set(SaveConstants.MouseState, 1);
            EventSystem.current.SetSelectedGameObject(null);
        }
    }
    public void ChangeSelectedButton(GameObject button) // Called when need to change selected button
    {
        currentFirstButton = button;
        EventSystem.current.SetSelectedGameObject(null);
        if (Save.Get(SaveConstants.MouseState, 1) == 0) { EventSystem.current.SetSelectedGameObject(button); }
    }
    #endregion
}

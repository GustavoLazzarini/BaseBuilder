using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PausePanel : MonoBehaviour
{
    #region Inspector
    public bool isGamePaused;
    public bool canPause = true;
    public GameObject pausePanel;
    public GameObject firstButton;

    private float pauseTime;

    [Space(30)]
    public GameObject[] objectsToEnableOnPause;
    public GameObject[] objectsToDisableOnPause;

    [Space(10)]
    public GameObject[] objectsToEnableOnUnpause;
    public GameObject[] objectsToDisableOnUnpause;



    [Space(30)]
    public BoolEventChannelSO PauseVoidEventChannelSO;
    public VoidEventChannelSO RestartEventChannelSO;
    #endregion

    #region Components
    private GameInput _GameInput;
    #endregion

    #region MonoBehaviours
    private void Awake()
    {
        _GameInput = new GameInput();
    }


    private void OnEnable()
    {
        _GameInput.Enable();


        RestartEventChannelSO.OnEventRaised += Restart;
    }
    private void OnDisable()
    {
        _GameInput.Disable();


        RestartEventChannelSO.OnEventRaised -= Restart;
    }


    private void Update()
    {
        PauseGameInput();
    }
    #endregion

    #region My Functions
    private void PauseGameInput()
    {
        if (_GameInput.Gameplay.Pause.triggered && canPause) { Pause(); }
        if (_GameInput.UI.Cancel.triggered && pausePanel.activeSelf) 
        { 
            Pause();
            if (GetComponent<AudioCue>()) { GetComponent<AudioCue>().PlayAudioCue(); }
        }
    }
    public void Pause() // Called by resume bt
    {
        if (Time.unscaledTime < pauseTime) return;
        pauseTime = Time.unscaledTime + 0.5f;

        // Unpause
        if (isGamePaused)
        {
            Time.timeScale = 1f;
            pausePanel.SetActive(false);



            for (int i = 0; i < objectsToEnableOnUnpause.Length; i++)
            {
                objectsToEnableOnUnpause[i].SetActive(true);
            }
            for (int i = 0; i < objectsToDisableOnUnpause.Length; i++)
            {
                objectsToDisableOnUnpause[i].SetActive(false);
            }
        }
        // Pause
        else
        {
            Time.timeScale = 0f;

            pausePanel.SetActive(true);
            GameObject.FindObjectOfType<CursorManager>().ChangeSelectedButton(firstButton);



            for (int i = 0; i < objectsToEnableOnPause.Length; i++)
            {
                objectsToEnableOnPause[i].SetActive(true);
            }
            for (int i = 0; i < objectsToDisableOnPause.Length; i++)
            {
                objectsToDisableOnPause[i].SetActive(false);
            }
        }


        isGamePaused = !isGamePaused;
        PauseVoidEventChannelSO.RaiseEvent(isGamePaused);
    }
    private void Restart()
    {
        if (isGamePaused) { Pause(); }
    }
    #endregion
}

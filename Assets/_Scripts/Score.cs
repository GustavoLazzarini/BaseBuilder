using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Core;

public class Score : MonoBehaviour
{
    [Header("Level")]
    [Space(20)]
    [SerializeField] TMP_Text levelTxt;


    [Header("Player Moves")]
    [Space(20)]
    public int playerMoves = 0;
    [SerializeField] TMP_Text movesTxt;
    [SerializeField] VoidEventChannelSO updatePlayerMovesCounter;


    [Header("Timer")]
    [Space(30)]
    [SerializeField] float timeSpeed = 60;
    public bool isTimerOn = true;

    private float elapsedTime = 0.0f;
    private float hour, minutes, seconds, milliseconds;
    [SerializeField] TMP_Text timerTxt;



    bool isPaused;
    [SerializeField] BoolEventChannelSO PauseVoidEventChannelSO;



    private void Awake()
    {
        // Components
        movesTxt = transform.Find("moves panel/moves_txt").GetComponent<TMP_Text>();
        timerTxt = transform.Find("elapsed time panel/timer_txt").GetComponent<TMP_Text>();
        levelTxt = transform.Find("currently level panel/level_txt").GetComponent<TMP_Text>();
    }
    private void Start()
    {
        //PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name, 0);
        //Debug.Log(SceneManager.GetActiveScene().name + " HighScore: " + PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name));


        // Set Currently Level text
        levelTxt.text = SceneManager.GetActiveScene().name;
    }


    private void OnEnable()
    {
        updatePlayerMovesCounter.OnEventRaised += UpdatePlayerMovesCouter;
        PauseVoidEventChannelSO.OnEventRaised += PauseEvent;
    }
    private void OnDisable()
    {
        updatePlayerMovesCounter.OnEventRaised -= UpdatePlayerMovesCouter;
        PauseVoidEventChannelSO.OnEventRaised -= PauseEvent;
    }


    private void Update()
    {
        Timer();
    }


    private void PauseEvent(bool state)
    {
        isPaused = state;
    }
    public void UpdatePlayerMovesCouter()
    {
        playerMoves++;
        movesTxt.text = "Moves: " + playerMoves;
    }
    public void ResetPlayerMovesCouter()
    {
        // Moves
        playerMoves = 0;
        movesTxt.text = "Moves: " + playerMoves;

        // Timer
        elapsedTime = 0;
        isTimerOn = true;
    }
    private void Timer()
    {
        if (!isPaused && isTimerOn)
        {
            elapsedTime += Time.deltaTime * timeSpeed;
            hour = (int)(elapsedTime / 3600f) % 24;
            minutes = (int)(elapsedTime / 60f) % 60;
            seconds = (int)(elapsedTime % 60f);
            milliseconds = (int)seconds * 1000;

            timerTxt.text = string.Format("Time: " + "{0:00}:{1:00}", hour, minutes);
        }
    }


    public void SaveHighscore()
    {
        isTimerOn = false;


        float finalScore = 100000000000 / (playerMoves * milliseconds); //print(finalScore);
        finalScore = Mathf.Round(finalScore * 100.0f) * 0.01f; //print(finalScore); // Convert to 2 digits after decimal point 


        if(finalScore < 0) { finalScore = 0; }


        //Debug.Log("Result: " + "100000000000 / " + "Moves: " + playerMoves + " * " + "Time: " + milliseconds + " = " + finalScore);


        //print("Level Reached: " + SaveManager.LoadLevel());
        Save.Set(SceneManager.GetActiveScene().name, finalScore);
    }
}

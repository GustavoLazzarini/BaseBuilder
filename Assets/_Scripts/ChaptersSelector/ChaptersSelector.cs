using UnityEngine;
using UnityEngine.UI;
using Core;

public class ChaptersSelector : MonoBehaviour
{
    [SerializeField] private Button[] levelButtons;
    [SerializeField] ButtonSceneLoader _ButtonSceneLoader;
    [SerializeField] Leaderboard _Leaderboard;


    [Space(30)]
    [SerializeField] AnimatorOverrideController unlockedAnimator;
    [SerializeField] AnimatorOverrideController lockedAnimator;


    // Scripts
    private GameInput _GameInput;
    private AudioCue _AudioCue;



    private void Awake()
    {
        // Scripts
        _GameInput = new GameInput();
        _AudioCue = GetComponent<AudioCue>();
    }
    private void Start()
    {
        //print("Level Reached: " + SaveManager.LoadLevel());
    }


    private void OnEnable()
    {
        _GameInput.Enable();
    }
    private void OnDisable()
    {
        _GameInput.Disable();
    }


    private void Update()
    {
        // Go back to Menu
        if (_Leaderboard != null)
        {
            if (_GameInput.UI.Return.triggered && _Leaderboard.isOpen == false)
            {
                _ButtonSceneLoader.OnButtonPress();
                _AudioCue.PlayAudioCue();
            }
        }



        // Update Levels Complete
        int levelReached = Save.Get(SaveConstants.Level, 1);


        // Enable Completed Levels Buttons
        for (int i = 0; i < levelButtons.Length; i++)
        {
            // Enable Buttons of levels completed
            if (i + 1 <= levelReached || i == 0)
            {
                levelButtons[i].interactable = true;
                levelButtons[i].gameObject.GetComponent<Animator>().runtimeAnimatorController = unlockedAnimator;
            }
            // Disable Buttons of levels not completed
            else
            {
                if (i != 0)
                {
                    levelButtons[i].enabled = false;
                    levelButtons[i].gameObject.GetComponent<Animator>().runtimeAnimatorController = lockedAnimator;

                }
            }
        }
    }
}

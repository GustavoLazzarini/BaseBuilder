using UnityEngine;

public class ReturnToMenu : MonoBehaviour
{
    [SerializeField] Leaderboard _Leaderboard;


    private bool canClose = true;


    // Scripts
    private ButtonSceneLoader _ButtonSceneLoader;
    private AudioCue _AudioCue;
    private GameInput _GameInput;


    private void Awake()
    {
        // Scripts
        _ButtonSceneLoader = GetComponent<ButtonSceneLoader>();
        _AudioCue = GetComponent<AudioCue>();
        _GameInput = new GameInput();
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
        Return();
    }


    private void Return()
    {
        if(_GameInput.UI.Return.triggered && canClose)
        {
            if(_Leaderboard != null && !_Leaderboard.isOpen)
            {
                canClose = false;

                _AudioCue.PlayAudioCue();
                _ButtonSceneLoader.OnButtonPress();
            }     
            else
            {
                canClose = false;

                _AudioCue.PlayAudioCue();
                _ButtonSceneLoader.OnButtonPress();
            }
        }
    }
}

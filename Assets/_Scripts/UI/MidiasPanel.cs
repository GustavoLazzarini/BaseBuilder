using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Core;

public class MidiasPanel : MonoBehaviour
{
    #region Inspector
    public bool isOpen = false;
    [SerializeField] GameObject midiasPanel;



    [Header("Buttons")]
    [Space(30)]
    public GameObject firstButton;
    [SerializeField] GameObject buttonToReturnTo;



    [Header("Sounds")]
    [Space(30)]
    [SerializeField] AudioSO openSound;
    [SerializeField] AudioSO closeSound;



    [Header("Objects to Disable")]
    [Space(30)]
    [SerializeField] GameObject[] objectsToDisable;
    #endregion

    #region Vars
    // Scripts
    private AudioCue _AudioCue;
    private GameInput _GameInput;
    #endregion

    #region Monobehaviours
    private void Awake()
    {
        // Scripts
        _AudioCue = GetComponent<AudioCue>();
        _GameInput = new GameInput();
    }
    private void Start()
    {
        // Close Midias Panel
        midiasPanel.SetActive(false);
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
        CloseMidiasPanel();
        SetSelectedButton();
    }
    #endregion

    #region My Functions
    private void SetSelectedButton()
    {
        if(EventSystem.current.currentSelectedGameObject == null && isOpen && Save.Get(SaveConstants.MouseState, 1) == 0) 
        { EventSystem.current.SetSelectedGameObject(firstButton); }
    }
    private void CloseMidiasPanel()
    {
        if (_GameInput.UI.Return.triggered && isOpen) { ToogleMidiasPanel(); }
    }
    public void ToogleMidiasPanel()
    {
        // Open
        if (!isOpen) 
        { 
            midiasPanel.SetActive(true);


            // Play Sound
            _AudioCue._audioCue = openSound;
            _AudioCue.PlayAudioCue();


            // Disable Objects
            for (int i = 0; i < objectsToDisable.Length; i++)
            {
                objectsToDisable[i].SetActive(false); ;
            }


            // Set Selected Button
            if (Save.Get(SaveConstants.MouseState, 1) == 0) { EventSystem.current.SetSelectedGameObject(firstButton); }
        }
        // Close
        else 
        { 
            midiasPanel.SetActive(false);
            

            // Play Sound
            _AudioCue._audioCue = closeSound;
            _AudioCue.PlayAudioCue();


            // Enable Objects
            for (int i = 0; i < objectsToDisable.Length; i++)
            {
                objectsToDisable[i].SetActive(true); ;
            }


            // Set selected Button
            if (buttonToReturnTo != null && Save.Get(SaveConstants.MouseState, 1) == 0) { EventSystem.current.SetSelectedGameObject(buttonToReturnTo); }
        }


        // Update Var
        isOpen = !isOpen;
    }
    #endregion
}

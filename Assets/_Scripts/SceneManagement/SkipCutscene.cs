using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkipCutscene : MonoBehaviour
{
    [SerializeField] GameObject ps4Text;
    [SerializeField] GameObject xboxText;
    [SerializeField] GameObject keyboardText;



    [Space(30)]
    [SerializeField] bool canSkip = false;
    [SerializeField] float fillSpeed = 0.003f;
    [SerializeField] float unfillSpeed = 0.01f;


    private bool canLoadScene = true;



    // Components
    private Image image;


    // Scripts
    [Space(30)]
    [SerializeField] TriggerSceneLoader _TriggerSceneLoader;
    private GameInput _GameInput;



    private void Awake()
    {
        // Scripts
        _GameInput = new GameInput();


        // Components
        image = GetComponent<Image>();
    }
    private void Start()
    {
        image.fillAmount = 0f;



        // Change button Text
        CurrentController controllerType = GameObject.FindObjectOfType<GetControllerType>().controllerType;

        if (controllerType == CurrentController.Playstation) { ps4Text.SetActive(true); }
        else if (controllerType == CurrentController.Xbox) { xboxText.SetActive(true); }
        else { keyboardText.SetActive(true); }
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
        Skip();
    }


    private void Skip()
    {
        if (_GameInput.UI.SkipCutscene.triggered) { canSkip = true; }
        else if (_GameInput.UI.SkipCutsceneCancel.triggered) { canSkip = false; }


        if (canSkip) 
        { 
            if(image.fillAmount < 1) { image.fillAmount += fillSpeed; }
        }
        else
        {
            if (image.fillAmount > 0) { image.fillAmount -= unfillSpeed; }
        }


        if(image.fillAmount >= 1 && canLoadScene) 
        {
            canLoadScene = false;
            _TriggerSceneLoader.OnButtonPress();        
        }
    }
}

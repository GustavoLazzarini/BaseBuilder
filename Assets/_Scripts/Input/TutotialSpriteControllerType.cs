using UnityEngine;

public class TutotialSpriteControllerType : MonoBehaviour
{
    [SerializeField] GameObject ps4Tutorial, xboxTutorial, keyboardTutorial;


    // Scripts
    private GetControllerType _GetControllerType;


    private void Awake()
    {

    }
    private void Start()
    {
        // Scripts
        _GetControllerType = GameObject.FindObjectOfType<GetControllerType>();
    }
    private void Update()
    {
        UpdateTutorialImage();
    }


    public void UpdateTutorialImage()
    {
        if(_GetControllerType != null)
        {
            if (_GetControllerType.controllerType == CurrentController.Playstation)
            {
                ps4Tutorial.SetActive(true);
                xboxTutorial.SetActive(false);
                keyboardTutorial.SetActive(false);
            }
            else if (_GetControllerType.controllerType == CurrentController.Xbox)
            {
                ps4Tutorial.SetActive(false);
                xboxTutorial.SetActive(true);
                keyboardTutorial.SetActive(false);
            }
            else
            {
                ps4Tutorial.SetActive(false);
                xboxTutorial.SetActive(false);
                keyboardTutorial.SetActive(true);
            }
        }       
    }
}

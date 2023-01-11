using UnityEngine;
using UnityEngine.UI;

public class UpdateUIControllerType : MonoBehaviour
{
    [SerializeField] CurrentController controllerType;


    [Header("Sprites")]
    [Space(20)]
    [SerializeField] AnimatorOverrideController ps4Animator;
    [SerializeField] AnimatorOverrideController xboxAnimator;
    [SerializeField] AnimatorOverrideController keyboardAnimator;



    // Components
    private Animator animator;



    private void Awake()
    {
        // Components
        animator = GetComponent<Animator>();
    }
    private void LateUpdate()
    {
        SetSprite();
    }



    public void SetSprite()
    {
        // Get Controller
        controllerType = GameObject.FindObjectOfType<GetControllerType>().controllerType;

        if (controllerType == CurrentController.Playstation) { animator.runtimeAnimatorController = ps4Animator; }
        else if (controllerType == CurrentController.Xbox) { animator.runtimeAnimatorController = xboxAnimator; }
        else { animator.runtimeAnimatorController = keyboardAnimator; }
    }
}

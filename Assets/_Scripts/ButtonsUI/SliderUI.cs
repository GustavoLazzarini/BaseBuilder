using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Slider))]
[RequireComponent(typeof(Animator))]
[ExecuteInEditMode()]
public class SliderUI : MonoBehaviour
{
    public SliderUIData data;
    private Slider slider;
    private Animator animator;


    [SerializeField] private Image backgroundImage;
    [SerializeField] private Image fillImage;
    [SerializeField] private Image handlerImage;
    [SerializeField] private TextMeshProUGUI text;


    private void OnSkinUI()
    {
        slider.transition = Selectable.Transition.Animation;
        animator.runtimeAnimatorController = data.animator;
        backgroundImage.sprite = data.spriteBackground;
        handlerImage.sprite = data.spriteHandler;
        text.font = data.font;
        text.color = data.textColor;
        backgroundImage.color = data.backgroundColor;
        fillImage.color = data.fillColor;
        handlerImage.color = data.handlerColor;
    }


    private void Awake()
    {
        slider = GetComponent<Slider>();
        animator = GetComponent<Animator>();
        OnSkinUI();
    }



    private void Update()
    {
        if (Application.isEditor)
        {
            OnSkinUI();
        }
    }
}

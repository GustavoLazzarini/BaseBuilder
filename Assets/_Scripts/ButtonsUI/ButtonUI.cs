using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Animator))]
[ExecuteInEditMode()]
public class ButtonUI : MonoBehaviour
{
    public ButtonUIData data;
    private Image image;
    private Button button;
    private Animator animator;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] VoidEventChannelSO pauseGameEvent;



    private void OnSkinUI()
    {
        button.transition = Selectable.Transition.Animation;
        animator.runtimeAnimatorController = data.animator;
        image.sprite = data.sprite;
        text.font = data.font;
        text.color = data.textColor;
    }


    private void Awake()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
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


    public void PauseGameEvent() { if(pauseGameEvent != null) pauseGameEvent.RaiseEvent(); }
}

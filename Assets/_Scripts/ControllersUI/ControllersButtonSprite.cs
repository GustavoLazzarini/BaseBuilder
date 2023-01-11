using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[ExecuteInEditMode()]
public class ControllersButtonSprite : MonoBehaviour
{
    public ControllersUIData data;
    public ControllerType controllertype;
    public ControllerButtonType buttontype;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    protected virtual void OnSkinUI()
    {
        switch(controllertype)
        {
            case ControllerType.XBox:
                switch (buttontype)
                {
                    case ControllerButtonType.A:
                        spriteRenderer.sprite = data.xBoxData.sprite_A;
                        animator.runtimeAnimatorController = data.xBoxData.animator_A;
                        break;
                    case ControllerButtonType.B:
                        spriteRenderer.sprite = data.xBoxData.sprite_B;
                        animator.runtimeAnimatorController = data.xBoxData.animator_B;
                        break;
                    case ControllerButtonType.Y:
                        spriteRenderer.sprite = data.xBoxData.sprite_Y;
                        animator.runtimeAnimatorController = data.xBoxData.animator_Y;
                        break;
                    case ControllerButtonType.X:
                        spriteRenderer.sprite = data.xBoxData.sprite_X;
                        animator.runtimeAnimatorController = data.xBoxData.animator_X;
                        break;
                    case ControllerButtonType.LB:
                        spriteRenderer.sprite = data.xBoxData.sprite_LB;
                        animator.runtimeAnimatorController = data.xBoxData.animator_LB;
                        break;
                    case ControllerButtonType.RB:
                        spriteRenderer.sprite = data.xBoxData.sprite_RB;
                        animator.runtimeAnimatorController = data.xBoxData.animator_RB;
                        break;
                    case ControllerButtonType.LT:
                        spriteRenderer.sprite = data.xBoxData.sprite_LT;
                        animator.runtimeAnimatorController = data.xBoxData.animator_LT;
                        break;
                    case ControllerButtonType.RT:
                        spriteRenderer.sprite = data.xBoxData.sprite_RT;
                        animator.runtimeAnimatorController = data.xBoxData.animator_RT;
                        break;
                    case ControllerButtonType.ANALOG_L:
                        spriteRenderer.sprite = data.xBoxData.sprite_ANALOG_L;
                        animator.runtimeAnimatorController = data.xBoxData.animator_ANALOG_L;
                        break;
                    case ControllerButtonType.ANALOG_R:
                        spriteRenderer.sprite = data.xBoxData.sprite_ANALOG_R;
                        animator.runtimeAnimatorController = data.xBoxData.animator_ANALOG_R;
                        break;
                    case ControllerButtonType.SELECT:
                        spriteRenderer.sprite = data.xBoxData.sprite_SELECT;
                        animator.runtimeAnimatorController = data.xBoxData.animator_SELECT;
                        break;
                    case ControllerButtonType.START:
                        spriteRenderer.sprite = data.xBoxData.sprite_START;
                        animator.runtimeAnimatorController = data.xBoxData.animator_START;
                        break;
                }
                break;
            case ControllerType.Playstation:
                switch (buttontype)
                {
                    case ControllerButtonType.A:
                        spriteRenderer.sprite = data.playstationData.sprite_A;
                        animator.runtimeAnimatorController = data.playstationData.animator_A;
                        break;
                    case ControllerButtonType.B:
                        spriteRenderer.sprite = data.playstationData.sprite_B;
                        animator.runtimeAnimatorController = data.playstationData.animator_B;
                        break;
                    case ControllerButtonType.Y:
                        spriteRenderer.sprite = data.playstationData.sprite_Y;
                        animator.runtimeAnimatorController = data.playstationData.animator_Y;
                        break;
                    case ControllerButtonType.X:
                        spriteRenderer.sprite = data.playstationData.sprite_X;
                        animator.runtimeAnimatorController = data.playstationData.animator_X;
                        break;
                    case ControllerButtonType.LB:
                        spriteRenderer.sprite = data.playstationData.sprite_LB;
                        animator.runtimeAnimatorController = data.playstationData.animator_LB;
                        break;
                    case ControllerButtonType.RB:
                        spriteRenderer.sprite = data.playstationData.sprite_RB;
                        animator.runtimeAnimatorController = data.playstationData.animator_RB;
                        break;
                    case ControllerButtonType.LT:
                        spriteRenderer.sprite = data.playstationData.sprite_LT;
                        animator.runtimeAnimatorController = data.playstationData.animator_LT;
                        break;
                    case ControllerButtonType.RT:
                        spriteRenderer.sprite = data.playstationData.sprite_RT;
                        animator.runtimeAnimatorController = data.playstationData.animator_RT;
                        break;
                    case ControllerButtonType.ANALOG_L:
                        spriteRenderer.sprite = data.playstationData.sprite_ANALOG_L;
                        animator.runtimeAnimatorController = data.playstationData.animator_ANALOG_L;
                        break;
                    case ControllerButtonType.ANALOG_R:
                        spriteRenderer.sprite = data.playstationData.sprite_ANALOG_R;
                        animator.runtimeAnimatorController = data.playstationData.animator_ANALOG_R;
                        break;
                    case ControllerButtonType.SELECT:
                        spriteRenderer.sprite = data.playstationData.sprite_SELECT;
                        animator.runtimeAnimatorController = data.playstationData.animator_SELECT;
                        break;
                    case ControllerButtonType.START:
                        spriteRenderer.sprite = data.playstationData.sprite_START;
                        animator.runtimeAnimatorController = data.playstationData.animator_START;
                        break;
                }
                break;
            case ControllerType.Nintendo:
                switch (buttontype)
                {
                    case ControllerButtonType.A:
                        spriteRenderer.sprite = data.nintendoData.sprite_A;
                        animator.runtimeAnimatorController = data.nintendoData.animator_A;
                        break;
                    case ControllerButtonType.B:
                        spriteRenderer.sprite = data.nintendoData.sprite_B;
                        animator.runtimeAnimatorController = data.nintendoData.animator_B;
                        break;
                    case ControllerButtonType.Y:
                        spriteRenderer.sprite = data.nintendoData.sprite_Y;
                        animator.runtimeAnimatorController = data.nintendoData.animator_Y;
                        break;
                    case ControllerButtonType.X:
                        spriteRenderer.sprite = data.nintendoData.sprite_X;
                        animator.runtimeAnimatorController = data.nintendoData.animator_X;
                        break;
                    case ControllerButtonType.LB:
                        spriteRenderer.sprite = data.nintendoData.sprite_LB;
                        animator.runtimeAnimatorController = data.nintendoData.animator_LB;
                        break;
                    case ControllerButtonType.RB:
                        spriteRenderer.sprite = data.nintendoData.sprite_RB;
                        animator.runtimeAnimatorController = data.nintendoData.animator_RB;
                        break;
                    case ControllerButtonType.LT:
                        spriteRenderer.sprite = data.nintendoData.sprite_LT;
                        animator.runtimeAnimatorController = data.nintendoData.animator_LT;
                        break;
                    case ControllerButtonType.RT:
                        spriteRenderer.sprite = data.nintendoData.sprite_RT;
                        animator.runtimeAnimatorController = data.nintendoData.animator_RT;
                        break;
                    case ControllerButtonType.ANALOG_L:
                        spriteRenderer.sprite = data.nintendoData.sprite_ANALOG_L;
                        animator.runtimeAnimatorController = data.nintendoData.animator_ANALOG_L;
                        break;
                    case ControllerButtonType.ANALOG_R:
                        spriteRenderer.sprite = data.nintendoData.sprite_ANALOG_R;
                        animator.runtimeAnimatorController = data.nintendoData.animator_ANALOG_R;
                        break;
                    case ControllerButtonType.SELECT:
                        spriteRenderer.sprite = data.nintendoData.sprite_SELECT;
                        animator.runtimeAnimatorController = data.nintendoData.animator_SELECT;
                        break;
                    case ControllerButtonType.START:
                        spriteRenderer.sprite = data.nintendoData.sprite_START;
                        animator.runtimeAnimatorController = data.nintendoData.animator_START;
                        break;
                }
                break;
            case ControllerType.KeyboardAndMouse:
                switch (buttontype)
                {
                    case ControllerButtonType.A:
                        spriteRenderer.sprite = data.keyboardAndMouseData.sprite_A;
                        animator.runtimeAnimatorController = data.keyboardAndMouseData.animator_A;
                        break;
                    case ControllerButtonType.B:
                        spriteRenderer.sprite = data.keyboardAndMouseData.sprite_B;
                        animator.runtimeAnimatorController = data.keyboardAndMouseData.animator_B;
                        break;
                    case ControllerButtonType.Y:
                        spriteRenderer.sprite = data.keyboardAndMouseData.sprite_Y;
                        animator.runtimeAnimatorController = data.keyboardAndMouseData.animator_Y;
                        break;
                    case ControllerButtonType.X:
                        spriteRenderer.sprite = data.keyboardAndMouseData.sprite_X;
                        animator.runtimeAnimatorController = data.keyboardAndMouseData.animator_X;
                        break;
                    case ControllerButtonType.LB:
                        spriteRenderer.sprite = data.keyboardAndMouseData.sprite_LB;
                        animator.runtimeAnimatorController = data.keyboardAndMouseData.animator_LB;
                        break;
                    case ControllerButtonType.RB:
                        spriteRenderer.sprite = data.keyboardAndMouseData.sprite_RB;
                        animator.runtimeAnimatorController = data.keyboardAndMouseData.animator_RB;
                        break;
                    case ControllerButtonType.LT:
                        spriteRenderer.sprite = data.keyboardAndMouseData.sprite_LT;
                        animator.runtimeAnimatorController = data.keyboardAndMouseData.animator_LT;
                        break;
                    case ControllerButtonType.RT:
                        spriteRenderer.sprite = data.keyboardAndMouseData.sprite_RT;
                        animator.runtimeAnimatorController = data.keyboardAndMouseData.animator_RT;
                        break;
                    case ControllerButtonType.ANALOG_L:
                        spriteRenderer.sprite = data.keyboardAndMouseData.sprite_ANALOG_L;
                        animator.runtimeAnimatorController = data.keyboardAndMouseData.animator_ANALOG_L;
                        break;
                    case ControllerButtonType.ANALOG_R:
                        spriteRenderer.sprite = data.keyboardAndMouseData.sprite_ANALOG_R;
                        animator.runtimeAnimatorController = data.keyboardAndMouseData.animator_ANALOG_R;
                        break;
                    case ControllerButtonType.SELECT:
                        spriteRenderer.sprite = data.keyboardAndMouseData.sprite_SELECT;
                        animator.runtimeAnimatorController = data.keyboardAndMouseData.animator_SELECT;
                        break;
                    case ControllerButtonType.START:
                        spriteRenderer.sprite = data.keyboardAndMouseData.sprite_START;
                        animator.runtimeAnimatorController = data.keyboardAndMouseData.animator_START;
                        break;
                }
                break;
        }
        
    }

    public virtual void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        OnSkinUI();
    }

    private void Update()
    {
        if(Application.isEditor)
        {
            OnSkinUI();
        }
    }
}

using UnityEngine;

[CreateAssetMenu(menuName = "Controllers UI/Controller Data")]
public class ControllerUIData : ScriptableObject
{
    [Header("Sprites")]
    public Sprite sprite_A;
    public Sprite sprite_B;
    public Sprite sprite_Y;
    public Sprite sprite_X;
    public Sprite sprite_LB;
    public Sprite sprite_RB;
    public Sprite sprite_LT;
    public Sprite sprite_RT;
    public Sprite sprite_ANALOG_L;
    public Sprite sprite_ANALOG_R;
    public Sprite sprite_SELECT;
    public Sprite sprite_START;

    [Header("Animators")]
    public AnimatorOverrideController animator_A;
    public AnimatorOverrideController animator_B;
    public AnimatorOverrideController animator_Y;
    public AnimatorOverrideController animator_X;
    public AnimatorOverrideController animator_LB;
    public AnimatorOverrideController animator_RB;
    public AnimatorOverrideController animator_LT;
    public AnimatorOverrideController animator_RT;
    public AnimatorOverrideController animator_ANALOG_L;
    public AnimatorOverrideController animator_ANALOG_R;
    public AnimatorOverrideController animator_SELECT;
    public AnimatorOverrideController animator_START;
}

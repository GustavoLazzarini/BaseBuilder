using UnityEngine;
using TMPro;

[CreateAssetMenu(menuName = "Buttons UI/Slider UI Data")]
public class SliderUIData : ScriptableObject
{
    [Header("Sprites")]
    public Sprite spriteBackground;
    public Sprite spriteHandler;

    [Header("Animator")]
    public AnimatorOverrideController animator;

    [Header("Colors")]
    public Color backgroundColor;
    public Color fillColor;
    public Color handlerColor;

    [Header("Text")]
    public TMP_FontAsset font;
    public Color textColor;
}

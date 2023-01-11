using UnityEngine;
using TMPro;

[CreateAssetMenu(menuName = "Buttons UI/Button UI Data")]
public class ButtonUIData : ScriptableObject
{
    [Header("Sprite")]
    public Sprite sprite;

    [Header("Animator")]
    public AnimatorOverrideController animator;

    [Header("Text")]
    public TMP_FontAsset font;
    public Color textColor;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDarkThemeToogle : MonoBehaviour
{
    [SerializeField] SpriteRenderer darkSpriteRenderer;
    [SerializeField] bool isLightTheme;

    public void ToogleTheme()
    {
        if(!isLightTheme)
        {
            darkSpriteRenderer.enabled = true;
        }
        else
        {
            darkSpriteRenderer.enabled = false;
        }
        isLightTheme = !isLightTheme;
    }
}

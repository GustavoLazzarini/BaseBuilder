using UnityEngine;
using UnityEngine.Localization.Settings;
using System.Collections;
using Core;

public class SelectedLanguageChecker : MonoBehaviour
{
    private void Start()
    {
        UpdateLanguage();
    }


    private void UpdateLanguage()
    {
        // Update dropdown value
        if (Save.Get(SaveConstants.SelectedLanguage, "English") == "English") 
        { LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0]; }
        else if (Save.Get(SaveConstants.SelectedLanguage, "English") == "Portuguese") 
        { LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1]; }

        //Debug.Log("Selected Language" + SaveManager.LoadSelectedLanguage());
    }
}

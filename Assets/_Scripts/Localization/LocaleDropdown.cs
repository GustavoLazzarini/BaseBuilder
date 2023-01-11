using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;
using TMPro;
using Core;

public class LocaleDropdown : MonoBehaviour
{
    // Components
    private Dropdown dropdown;


    private void Awake()
    {
        // Components
        dropdown = GetComponent<Dropdown>();
    }
    IEnumerator Start()
    {
        // Wait for the localization system to initialize, loading Locales, preloading etc.
        yield return LocalizationSettings.InitializationOperation;

        // Generate list of available Locales
        var options = new List<Dropdown.OptionData>();
        int selected = 0;
        for (int i = 0; i < LocalizationSettings.AvailableLocales.Locales.Count; ++i)
        {
            var locale = LocalizationSettings.AvailableLocales.Locales[i];
            if (LocalizationSettings.SelectedLocale == locale)
                selected = i;
            options.Add(new Dropdown.OptionData(locale.name));
        }
        dropdown.options = options;

        dropdown.value = selected;
        dropdown.onValueChanged.AddListener(LocaleSelected);


        UpdateDropdownValue();
    }


    // Called on settings panel open
    public void UpdateDropdownValue()
    {
        // Update Dropdown Text
        dropdown.options[0].text = "English";
        dropdown.options[1].text = "Portuguese";


        // Update dropdown value
        if (Save.Get(SaveConstants.SelectedLanguage, "English") == "English") 
        { 
            dropdown.value = 0;
            dropdown.captionText.text = "English";
            dropdown.options[dropdown.value].text = "English";
        }
        else if (Save.Get(SaveConstants.SelectedLanguage, "English") == "Portuguese") 
        {
            dropdown.value = 1;
            dropdown.captionText.text = "Portuguese";
            dropdown.options[dropdown.value].text = "Portuguese";
        }
    }


    // Called on dropdown value change
    public void UpdateLocalizationLanguage()
    {
        if(dropdown.value == 0) 
        { 
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
            Save.Set(SaveConstants.SelectedLanguage, "English");
            dropdown.options[dropdown.value].text = "English";
        }
        else 
        { 
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];
            Save.Set(SaveConstants.SelectedLanguage, "Portuguese");
            dropdown.options[dropdown.value].text = "Portuguese";
        }
    }


    public void LocaleSelected(int index)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
    }
}
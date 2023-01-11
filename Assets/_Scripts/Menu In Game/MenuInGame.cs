using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInGame : MonoBehaviour
{
    [SerializeField] GameObject menuClosed;
    [SerializeField] GameObject menuPieces;
    [SerializeField] GameObject menuAudio;
    [SerializeField] GameObject menuSettings;
    [SerializeField] bool menuPiecesOpen;
    [SerializeField] bool menuAudioOpen;
    [SerializeField] bool menuSettingsOpen;

    public void MenuPieces()
    {
        if(!menuPiecesOpen)
        {
            menuPieces.SetActive(true);
            menuClosed.SetActive(false);
            menuAudio.SetActive(false);
            menuSettings.SetActive(false);
        }
        else
        {
            menuClosed.SetActive(true);
            menuPieces.SetActive(false);
            menuAudio.SetActive(false);
            menuSettings.SetActive(false);
        }
        menuPiecesOpen = !menuPiecesOpen;
    }

    public void MenuAudio()
    {
        if (!menuAudioOpen)
        {
            menuAudio.SetActive(true);
            menuPieces.SetActive(false);
            menuClosed.SetActive(false);
            menuSettings.SetActive(false);
        }
        else
        {
            menuClosed.SetActive(true);
            menuPieces.SetActive(false);
            menuAudio.SetActive(false);
            menuSettings.SetActive(false);
        }
        menuAudioOpen = !menuAudioOpen;
    }

    public void MenuSettings()
    {
        if (!menuSettingsOpen)
        {
            menuSettings.SetActive(true);
            menuAudio.SetActive(false);
            menuPieces.SetActive(false);
            menuClosed.SetActive(false);
        }
        else
        {
            menuClosed.SetActive(true);
            menuPieces.SetActive(false);
            menuAudio.SetActive(false);
            menuSettings.SetActive(false);
        }
        menuSettingsOpen = !menuSettingsOpen;
    }
}

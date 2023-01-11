using UnityEngine;
using Core;

public class InGameAudio : MonoBehaviour
{
    private void Start()
    {
        float musicVolume = Save.Get(SaveConstants.Music, 1);
        SetMusicVolume(musicVolume);

        float sfxVolume = Save.Get(SaveConstants.Sfx, 1);
        SetSFXVolume(sfxVolume);
    }

    public void SetMusicVolume(float _musicVolume)
    {
        AudioManager a = FindObjectOfType<AudioManager>();
        a.SetGroupVolume("MusicVolume", _musicVolume);
        Save.Set(SaveConstants.Music, _musicVolume);
    }

    public void SetSFXVolume(float _sfxVolume)
    {
        AudioManager a = FindObjectOfType<AudioManager>();
        a.SetGroupVolume("SFXVolume", _sfxVolume);
        Save.Set(SaveConstants.Sfx, _sfxVolume);
    }
    
}

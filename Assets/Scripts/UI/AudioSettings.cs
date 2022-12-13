using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] Slider sfxVolumeSlider;

    void Start()
    {
        LoadSettings();
    }

    private void LoadSettings() //ladataan/asetetaan
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
            SetMusicVolume();
        }
        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume");
            SetSFXVolume();
        }
    }

    public void SetMusicVolume()
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(musicVolumeSlider.value) * 20); // muutetaan musiikin voimakkuutta logarytmisesti (ihmisen kuulo toimii logarytmisesti)
        PlayerPrefs.SetFloat("MusicVolume", musicVolumeSlider.value); //tallennus
    }

    public void SetSFXVolume()
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(sfxVolumeSlider.value) * 20);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolumeSlider.value); //tallennus
    }

    //private float GetLogVol(float linearVolume)
    //{
    //    return Mathf.Log10(linearVolume) * 20;
    //}
}

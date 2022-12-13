using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering; //haetaan Volume
using UnityEngine.Rendering.Universal; //haetaan Volumen ColorAdjustments
using UnityEngine.UI; //voidaan UI kirjoituksia
//using UnityEngine.UIElements;

public class SettingsMenu : MonoBehaviour
{
    Camera mainCam;
    Volume volume; //kameran Volume
    ColorAdjustments colorAdjustments; //kontrastin ja valon kirkkauden s��t�

    [SerializeField] Slider contrastSlider;
    [SerializeField] Slider postExposureSlider; //BrightnessSlider on t�m�
    [SerializeField] Dropdown qualityDropdown; //materiaalien laatu, grafiikka
    [SerializeField] Dropdown resolutionDropDown; //n�yt�n resuluutio
    [SerializeField] Dropdown screenModeDropdown;

    FullScreenMode fullScreenMode = FullScreenMode.FullScreenWindow;
    Resolution[] resolutions; //resuluutioiden taulukko

    void Start()
    {
        mainCam = Camera.main; // kameran kautta voidaan hakea Volume, jossa tapahtuu s��d�t (kontrasti ja valo)
        volume = mainCam.GetComponent<Volume>();
        VolumeProfile profile = volume.sharedProfile; // haetaan Volume prieli, joka sijaitsee setting menu-> scriptable object main camera profile
        if (profile.TryGet<ColorAdjustments>(out var tmp))
        {
            colorAdjustments = tmp;
        }
        GetAvailableResolutions();
        LoadSettings();
    }

    private void GetAvailableResolutions()
    {
        resolutionDropDown.ClearOptions(); //poistaa vanhat asetukset
        resolutions = Screen.resolutions; //palauttaa kaikki n�ytt��setukset/resuluutiot koneesta riippuen

        List<string> options = new List<string>(); //tehd��n apulista nimi options, ja alustetaan lista/tyhjennet��n

        int currenResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " " + resolutions[i].refreshRate + " Hz"; //n�in saadaan listasta p�tki�, hetaan widt ja height. loppu koodilla n�ht��n n�yt�n taajuus
            options.Add(option); // lis�t��n apulistaan tiedot
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) currenResolutionIndex = i;
            //resoluution asetuksiin tulee n�kyviin t�m�n hetkinen resoluutio asetus
        }
        resolutionDropDown.AddOptions(options); //haetaan kaikki resoluutiot valikkoon
        if (!PlayerPrefs.HasKey("ResolutionIndex")) resolutionDropDown.value = currenResolutionIndex; //resoluutio valikko n�ytt�� nyt t�m�n hetkist� resoa
    }

    public void ChangeResolutions()
    {
        Debug.Log(resolutionDropDown.value);
        Resolution resolution = resolutions[resolutionDropDown.value]; //haetaan resolutionDrop down
        Screen.SetResolution(resolution.width, resolution.height, fullScreenMode, resolution.refreshRate); //refreshRate valitsee resoluution
        PlayerPrefs.SetInt("ResolutionIndex", resolutionDropDown.value);
    }

    public void SetScreenMode()
    {
        if (screenModeDropdown.value == 0) //Full Screen
        {
            fullScreenMode = FullScreenMode.FullScreenWindow;
        }
        if (screenModeDropdown.value == 1) //Exclusive Full Screen
        {
            fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        }
        if (screenModeDropdown.value == 3)//Windowed
        {
            fullScreenMode = FullScreenMode.Windowed;
        }
        ChangeResolutions();
        PlayerPrefs.SetInt("ScreenMode", screenModeDropdown.value); //tallennus eli tallennetaan s��detty asetus
    }

    public void LoadSettings() //ladataan asetukset
    {
        if (PlayerPrefs.HasKey("Contrast"))
        {
            contrastSlider.value = PlayerPrefs.GetFloat("Contrast");
            SetContrast();
        }
        if (PlayerPrefs.HasKey("Brightness"))
        {
            postExposureSlider.value = PlayerPrefs.GetFloat("Brightness");
            SetBrightness();
        }
        if (PlayerPrefs.HasKey("Quality"))
        {
            qualityDropdown.value = PlayerPrefs.GetInt("Quality");
            SetQuality();
        }
        if (PlayerPrefs.HasKey("ResolutionIndex"))
        {
            int ResolutionIndex = PlayerPrefs.GetInt("ResolutionIndex");
            if (ResolutionIndex < resolutionDropDown.options.Count) //jos pelaat toisella koneella samaa peli�, resoluutio ei kaada konetta
            {
                resolutionDropDown.value = ResolutionIndex;
                ChangeResolutions();
            }
        }
        if (PlayerPrefs.HasKey("ScreenMode")) //lataus
        {
            screenModeDropdown.value = PlayerPrefs.GetInt("ScreenMode");
            SetScreenMode();
        }
    }

    public void SetContrast() //pystyt��n s��t�m��n kontrastia
    {
        colorAdjustments.contrast.value = contrastSlider.value; //asetus
        PlayerPrefs.SetFloat("Contrast", contrastSlider.value); //tallennus
    }

    public void SetBrightness() //pystyt��n s��t�m��n kirkautta
    {
        colorAdjustments.postExposure.value = postExposureSlider.value; //asetus
        PlayerPrefs.SetFloat("Brightness", postExposureSlider.value); //talennus
    }

    public void SetQuality() //n�yt�n laatu
    {
        QualitySettings.SetQualityLevel(qualityDropdown.value, true); //asetus
        PlayerPrefs.SetInt("Quality", qualityDropdown.value); //tallennus
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}

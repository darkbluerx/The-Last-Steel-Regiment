using UnityEngine;
using UnityEngine.UI;

public class ControlSettings : MonoBehaviour
{
    [SerializeField] Slider sensitivitySlider;
    [SerializeField] PlayerSettingsSO playerSettings;

    void Start()
    {
        LoadSettings();
    }

    public void SetSensitivity()
    {
        playerSettings.MouseSpeed = sensitivitySlider.value;
        PlayerPrefs.SetFloat("sensitivitySlider", sensitivitySlider.value);
    }

    private void LoadSettings() //ladataan/asetetaan
    {
        if (PlayerPrefs.HasKey("sensitivitySlider"))
        {
            sensitivitySlider.value = PlayerPrefs.GetFloat("sensitivitySlider");
            SetSensitivity();
        }
    }
}

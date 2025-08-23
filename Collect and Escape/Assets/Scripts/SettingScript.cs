using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject settingsPanel;
    public Slider volumeSlider;
    public TMP_Dropdown graphicsDropdown;

    private void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1f);
        ApplyVolume(volumeSlider.value);
        volumeSlider.onValueChanged.AddListener(ApplyVolume);

        graphicsDropdown.ClearOptions();
        graphicsDropdown.AddOptions(new System.Collections.Generic.List<string>(QualitySettings.names));

        int savedQuality = PlayerPrefs.GetInt("GraphicsQuality", QualitySettings.GetQualityLevel());
        graphicsDropdown.value = savedQuality;
        ApplyGraphics(savedQuality);

        graphicsDropdown.onValueChanged.AddListener(ApplyGraphics);
    }

    public void OpenSettings()
    {
        menuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    private void ApplyVolume(float value)
    {
        AudioListener.volume = value;
        PlayerPrefs.SetFloat("MasterVolume", value);
    }

    private void ApplyGraphics(int index)
    {
        QualitySettings.SetQualityLevel(index, true);
        PlayerPrefs.SetInt("GraphicsQuality", index);
    }
}

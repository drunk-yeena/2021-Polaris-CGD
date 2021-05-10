using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    //UI Elements (Serialised - Private in function but can be accessed in the Engine Editor)
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    public Dropdown qualityDropdown;
    public Dropdown textureDropdown;
    public Dropdown aaDropdown;
    public Slider volumeSlider;

    //Variables
    float currentVolume;
    Resolution[] userResolutions;

    // Start is called before the first frame update
    void Start()
    {
        resolutionDropdown.ClearOptions();
        List<string> resolutionOptions = new List<string>();
        userResolutions = Screen.resolutions;
        int currentResolutionIndex = 0;

        for (int i = 0; i < userResolutions.Length; i++)
        {
            string option = userResolutions[i].width + "x" + userResolutions[i].height;
            resolutionOptions.Add(option);
            if (userResolutions[i].width == Screen.currentResolution.width && userResolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }

        resolutionDropdown.AddOptions(resolutionOptions);
        resolutionDropdown.RefreshShownValue();
        LoadSettings(currentResolutionIndex);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Master", volume);
        currentVolume = volume;
    }

    //Resolution Methods
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = userResolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    //Graphical Settings
    public void SetTextureQuality(int textureIndex)
    {
        QualitySettings.masterTextureLimit = textureIndex;
        qualityDropdown.value = 6;
    }
    public void SetAntiAliasing(int aaIndex)
    {
        QualitySettings.antiAliasing = aaIndex;
        qualityDropdown.value = 6;
    }
    public void SetQuality(int qualityIndex)
    {
        if (qualityIndex != 6)
            QualitySettings.SetQualityLevel(qualityIndex);

        switch (qualityIndex)
        {
            //Quality Level - Very Low
            case 0:
                textureDropdown.value = 0;
                aaDropdown.value = 1;
                break;
            //Quality Level - Low
            case 1:
                textureDropdown.value = 1;
                aaDropdown.value = 1;
                break;
            //Quality Level - Medium
            case 2:
                textureDropdown.value = 1;
                aaDropdown.value = 0;
                break;
            //Quality Level - High
            case 3:
                textureDropdown.value = 1;
                aaDropdown.value = 0;
                break;
            //Quality Level - Very High
            case 4:
                textureDropdown.value = 1;
                aaDropdown.value = 0;
                break;
            //Quality Level - Ultra
            case 5:
                textureDropdown.value = 1;
                aaDropdown.value = 0;
                break;
        }

        qualityDropdown.value = qualityIndex;
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("QualitySettingPreference", qualityDropdown.value);
        PlayerPrefs.SetInt("ResolutionPreference", resolutionDropdown.value);
        PlayerPrefs.SetInt("TextureQualityPreference", textureDropdown.value);
        PlayerPrefs.SetInt("AntiAliasingPreference", aaDropdown.value);
        PlayerPrefs.SetInt("FullscreenPreference", Convert.ToInt32(Screen.fullScreen));
        PlayerPrefs.SetFloat("VolumePreference", currentVolume);
    }

    public void LoadSettings(int resolutionIndex)
    {
        if (PlayerPrefs.HasKey("QualitySettingPreference"))
            qualityDropdown.value = PlayerPrefs.GetInt("QualitySettingPreference");
        else
            qualityDropdown.value = 3;

        if (PlayerPrefs.HasKey("ResolutionPreference"))
            resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionPreference");
        else
            resolutionDropdown.value = resolutionIndex;

        if (PlayerPrefs.HasKey("TextureQualityPreference"))
            textureDropdown.value = PlayerPrefs.GetInt("TextureQualityPreference");
        else
            textureDropdown.value = 0;

        if (PlayerPrefs.HasKey("AntiAliasingPreference"))
            aaDropdown.value = PlayerPrefs.GetInt("AntiAliasingPreference");
        else
            aaDropdown.value = 1;

        if (PlayerPrefs.HasKey("FullscreenPreference"))
            Screen.fullScreen = Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));
        else
            Screen.fullScreen = true;

        if (PlayerPrefs.HasKey("VolumePreference"))
            volumeSlider.value = PlayerPrefs.GetFloat("VolumePreference");
        else
            volumeSlider.value = PlayerPrefs.GetFloat("VolumePreference");


    }
}

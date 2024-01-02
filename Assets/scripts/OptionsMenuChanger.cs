using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenuChanger : MonoBehaviour
{
    GameObject currerentBox;
    GameObject NewBox;
    string finder;

    public TMPro.TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;

    public AudioMixer audioMixer;

    void Start()
    {
        //intiliased current box 
        currerentBox = GameObject.Find("OPTIONS/General/Box");
        currerentBox.SetActive(true);

        //get the resolutions from the screens settings
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        //going through all possible screen resolutions and adding them to list
        int currentResolutionindex = 0;
        for(int i=0; i <resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width &&
               resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionindex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionindex;
        resolutionDropdown.RefreshShownValue();
    }

    public void OnClicked(Button button)
    {
        //identifiying the button which is pressed
        finder = button.name;
        NewBox = GameObject.Find("OPTIONS/"+finder+"/Box");
        //switches out the information
        currerentBox.SetActive(false);
        NewBox.SetActive(true);
        currerentBox = NewBox;
    }

    public void SetVolume(float volume)
    {
        //seting the ingame audio
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetQuality (int qualityIndex)
    {
        //changing quality
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void setFullscreen (bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height , Screen.fullScreen);
    }
}

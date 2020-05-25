using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;
    Resolution[] resolu;

    public Dropdown ResoluDrop;


    void Start()
    {


        resolu = Screen.resolutions;

        ResoluDrop.ClearOptions();

        List<string> options = new List<string>();
        int currentReluIndex = 0;
        for (int i = 0; i < resolu.Length; i++)
        {
            string optionX = resolu[i].width + "x" + resolu[i].height;
            options.Add(optionX);

            if(resolu[i].width == Screen.currentResolution.width && resolu[i].height == Screen.currentResolution.height)
            {
                currentReluIndex = i;
            }
        }
        ResoluDrop.AddOptions(options);
        ResoluDrop.value = currentReluIndex;
        ResoluDrop.RefreshShownValue();
    }

    public void SetResolu(int resolutionIndex)
    {
        Resolution resolution = resolu[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }


    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void QualidadeSet(int IndexQualidade)
    {
        QualitySettings.SetQualityLevel(IndexQualidade);
    }

    public void SetFullscreen(bool SetFullScreen)
    {
        Screen.fullScreen = SetFullScreen;
    }
}

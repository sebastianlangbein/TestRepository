using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownHandler : MonoBehaviour
{
    public void Quality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public Resolution[] resolutions;
    public Dropdown resDropdown;
    public Toggle fullscreenToggle;
    private void Start()
    {
        fullscreenToggle.isOn = Screen.fullScreen;
        resolutions = Screen.resolutions;
        resDropdown.ClearOptions();
        List<string> options = new List<string>();
        int curResIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            if (!options.Contains(option))
            {
                options.Add(option);
                if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                {
                    curResIndex = options.Count-1;
                }
            }
        }
        resDropdown.AddOptions(options);
        resDropdown.value = curResIndex;
        resDropdown.RefreshShownValue();
    }
    public void SetResolution(int resIndex)
    {
        Resolution res = resolutions[resIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
}

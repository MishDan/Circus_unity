using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ResolutionSettings : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    private List<Resolution> filteredResolutions;
    private int selectedResolutionIndex;

    void Start()
    {
        LoadResolution();
        PopulateDropdown();
        ApplySavedResolution();
    }

    void PopulateDropdown()
    {
        resolutionDropdown.ClearOptions();
        filteredResolutions = new List<Resolution>();
        List<string> options = new List<string>();

        Resolution[] allResolutions = Screen.resolutions;

        for (int i = 0; i < allResolutions.Length; i++)
        {
            string resolutionString = allResolutions[i].width + " x " + allResolutions[i].height;

            if (!options.Contains(resolutionString))
            {
                options.Add(resolutionString);
                filteredResolutions.Add(allResolutions[i]);
            }
        }

        resolutionDropdown.AddOptions(options);

        if (selectedResolutionIndex >= 0 && selectedResolutionIndex < filteredResolutions.Count)
        {
            resolutionDropdown.value = selectedResolutionIndex;
        }
        else
        {
            resolutionDropdown.value = 0;
            selectedResolutionIndex = 0;
        }


        resolutionDropdown.RefreshShownValue();

        resolutionDropdown.onValueChanged.AddListener(SetResolution);
    }

    public void SetResolution(int index)
    {
        selectedResolutionIndex = index;
        Resolution resolution = filteredResolutions[index];
        Screen.SetResolution(resolution.width, resolution.height, FullScreenMode.FullScreenWindow);

        PlayerPrefs.SetInt("ResolutionIndex", selectedResolutionIndex);
        PlayerPrefs.Save();

        Debug.Log("Resolution set to: " + resolution.width + "x" + resolution.height);
    }

    void LoadResolution()
    {
        selectedResolutionIndex = PlayerPrefs.GetInt("ResolutionIndex", 0);
    }

    void ApplySavedResolution()
    {
        if (selectedResolutionIndex >= 0 && selectedResolutionIndex < filteredResolutions.Count)
        {
            Resolution resolution = filteredResolutions[selectedResolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, FullScreenMode.FullScreenWindow);

            Debug.Log(resolution.width + "x" + resolution.height);
        }
    }
}

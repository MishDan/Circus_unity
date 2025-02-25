using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SceneChangeScript : MonoBehaviour
{
    public FadeScript fadeScript;
    public SaveLoadScript saveLoadScript;

    public void CloseGame()
    {
        StartCoroutine(Delay("quit", -1, ""));
    }
    public void settings()
    {
        StartCoroutine(Delay("settings", -1, ""));
    }
    public void mainMenu()
    {
        StartCoroutine(Delay("mainMenu", -1, ""));
    }


    public IEnumerator Delay(string command, int character, string name){
            if(string.Equals(command, "quit", StringComparison.OrdinalIgnoreCase))
        {
                yield return fadeScript.FadeIn(0.1f);
                PlayerPrefs.DeleteAll();

#if UNITY_EDITOR
            if (UnityEditor.EditorApplication.isPlaying)
                {
                    UnityEditor.EditorApplication.isPlaying = false;
                }
#endif
            else
                Application.Quit();

        }else if (string.Equals(command, "play", StringComparison.OrdinalIgnoreCase))
        {
            yield return fadeScript.FadeIn(0.1f);
            saveLoadScript.SaveGame(character, name);
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
        else if (string.Equals(command, "settings", StringComparison.OrdinalIgnoreCase))
        {
            yield return fadeScript.FadeIn(0.1f);
            SceneManager.LoadScene("Settings", LoadSceneMode.Single);
        }
        else if (string.Equals(command, "mainMenu", StringComparison.OrdinalIgnoreCase))
        {
            yield return fadeScript.FadeIn(0.1f);
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
    }   
}



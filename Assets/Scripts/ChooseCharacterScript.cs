using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChooseCharacterScript : MonoBehaviour
{
    public GameObject[] characters;
    int characterIndex;

    public GameObject inputField;
    string characterName;
    public int playerCount = 2;
    public SceneChangeScript sceneChangeScript;

    private void Awake()
    {
        foreach(GameObject character in characters)
        {
            character.SetActive(false);
        }
        characters[characterIndex].SetActive(true);
    }

    public void NextCharacter()
    {
        characters[characterIndex].SetActive(false);
        characterIndex++;
        if (characterIndex == characters.Length)
        {
            characterIndex = 0;
        }
        characters[characterIndex].SetActive(true);
    }

    public void PreviousCharacter()
    {
        characters[characterIndex].SetActive(false);
        characterIndex--;
        if(characterIndex == -1)
        {
            characterIndex = characters.Length - 1;
        }
        characters[characterIndex].SetActive(true);
    }

    public void Play()
    {
        characterName = inputField.GetComponent<TMP_InputField>().text;
        if(characterName.Length > 2)
        {
            PlayerPrefs.SetInt("SelectedCharacter", characterIndex);
            PlayerPrefs.SetString("PlayerName", characterName);
            PlayerPrefs.SetInt("PlayerCount", playerCount);
            StartCoroutine(sceneChangeScript.Delay("play", characterIndex, characterName));
        }
        else
        {
            inputField.GetComponent<TMP_InputField>().Select();
        }

    }
}

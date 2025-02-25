using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class SaveLoadScript : MonoBehaviour
{

    public string saveFileName = "saveFile.json";

    [Serializable]
    public class GameData
    {
        public int characterIndex;
        public string playerName;
    }

    private GameData gameData = new GameData();

    public void SaveGame(int character, string name)
    {
        gameData.characterIndex = character;
        gameData.playerName = name;

        string json = JsonUtility.ToJson(gameData);
        File.WriteAllText(Application.persistentDataPath + "/" + saveFileName, json);
        Debug.Log("Game saved to: " + Application.persistentDataPath + "/" + saveFileName);
    }

    public void LoadGame()
    {
        string filePath = Application.persistentDataPath + "/" + saveFileName;

            if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            gameData = JsonUtility.FromJson<GameData>(json);

            Debug.Log("Game loaded from: " + filePath +"\nCharacter index: " +gameData.characterIndex+ "\nPlayer name: "+gameData.playerName);
        }
        else
        {
            Debug.LogError("Save file not found: " + filePath);
        }
    }
}

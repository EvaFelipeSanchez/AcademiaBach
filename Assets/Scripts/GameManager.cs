using UnityEngine;
using System;

[Serializable]
public class GameData
{
    public int puntos;

}
public class GameManager : MonoBehaviour
{
    public GameData gameData;

    public void Awake()
    {
        LoadGameData();
    }

    public void OnApplicationQuit()
    {
        SaveGameData();
    }

    public void SaveGameData()
    {
        string json = JsonUtility.ToJson(gameData);
        PlayerPrefs.SetString("GameData", json);
        PlayerPrefs.Save();
    }

    public void LoadGameData()
    {
        if (PlayerPrefs.HasKey("GameData"))
        {
            string json = PlayerPrefs.GetString("GameData");
            gameData = JsonUtility.FromJson<GameData>(json);
        }
        else
        {
            gameData = new GameData();
        }
    }
}
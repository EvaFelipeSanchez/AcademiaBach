using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveLoadSystemData
{
    public static void SaveData<T>(T data, string path, string fileName) //Guardar datos
    {
        string fullPath = Application.persistentDataPath + "/" + path + "/";
        bool checkFolderExit = Directory.Exists(fullPath);
        if (checkFolderExit == false) //¿Existe la direccion?
        {
            Directory.CreateDirectory(fullPath); //Si no existe se crea
        }
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(fullPath + fileName + ".json", json); //Guardar en el dispositivo
        Debug.Log("Save date ok. " + fullPath);
    }
    public static T LoadData<T>(string path, string fileName) //Cargar datos
    {
        string fullPath = Application.persistentDataPath + "/" + path + "/" + fileName + ".json";
        if (File.Exists(fullPath))
        {
            string textJson = File.ReadAllText(fullPath);
            var obj = JsonUtility.FromJson<T>(textJson);
            return obj;
        }
        else
        {
            Debug.Log("not file found on load data");
            return default;
        }
    }


}

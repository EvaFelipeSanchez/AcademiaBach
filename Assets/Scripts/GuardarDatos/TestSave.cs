using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TestSave : MonoBehaviour
{
  public TMP_Text puntostext;

  public ExampleDataPuntos data;

  public const string pathData = "Data/test";
  public const string nameFileData = "ExampleData";

  private void Start()
  {
    var dataFound = SaveLoadSystemData.LoadData<ExampleDataPuntos>(pathData, nameFileData);

    if(dataFound != null){
        data = dataFound;
        ChangeValues();
    }
    else{
       data = new ExampleDataPuntos();
       SaveData();
    }
  }

  public void prueba(){
    //Operaciones
    //data.checklistcontent;
    //ChangeValues()
    //SaveData();

  }

  private void ChangeValues(){
      //levelText.text = "Level:" + data.level;
      //if(data.color == "blue")
  }

  private void SaveData(){
      SaveLoadSystemData.SaveData(data, pathData, nameFileData);
  }


  
}

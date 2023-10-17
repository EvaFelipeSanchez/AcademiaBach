using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MascotaMascota : MonoBehaviour
{
   public Button activar;

   
   public Image mascotadespier;
   public Image mascotadurmiendo;

   public GameObject mascotaactual;

   public GameObject mascotaactivar;



   public TMP_Text nombremascotameso;

   public TMP_Text nombremascotaactualpuesto;

   public GameObject avisoactivacion;
     
   public Button cerraravisoactivacion;

   public bool activo = false;


   public ExampleDataMascota data;

   public const string pathData = "Data/test";
   public const string nameFileData = "ExampleData";

   private  string resourcePathDespierto;
   private string resourcePathDormiendo;

   //Pilla correctamente el resourcePath falta pasar ese path a los valores de las imagenes de la mascotactual.



   
   

   //private int limit = 0; //Guardar

   void Start()
   {

         bool hacerprimero = false;



         if (mascotadespier != null)
        {
            // Accede a la textura de la Image
            Texture2D texture = mascotadespier.sprite.texture;

            // Obtén la ruta del recurso de la textura (si está en un recurso)
            resourcePathDespierto = UnityEditor.AssetDatabase.GetAssetPath(texture);

            // Muestra la información
        
        }

         if (mascotadurmiendo != null)
        {
            // Accede a la textura de la Image
            Texture2D texture = mascotadurmiendo.sprite.texture;

            // Obtén la ruta del recurso de la textura (si está en un recurso)
            resourcePathDormiendo = UnityEditor.AssetDatabase.GetAssetPath(texture);
            hacerprimero = true;            
        
        }


      
        mascotadespier.enabled = true; 
        
        //nombre.enabled = false; 
        if(hacerprimero){
          mascotadurmiendo.enabled = false;       
        }
        
        avisoactivacion.SetActive(false); 
        //enActivo.SetActive(false); 
        activo = false;
        //mascotadespier = data.mascotactualdespierta;
        //mascotadurmiendo = data.mascotactualdormido;
        //nombremascotaactualpuesto = data.nombreactual;

      
         var dataFound = SaveLoadSystemData.LoadData<ExampleDataMascota>(pathData, nameFileData);

         if(dataFound != null){
            data = dataFound;
            ChangeValues();
         }
         else{
            data = new ExampleDataMascota();
            SaveData();
         }







         

   }


   private void ChangeValues(){
      resourcePathDespierto= data.imagePathmascotactualdespierta;
      resourcePathDormiendo= data.imagePathmascotactualdormido;
      nombremascotaactualpuesto = data.nombreactual;

        //Debug.Log("Mascota actual es: " +  data.nombreactual);
       
  }

  private void SaveData(){
      SaveLoadSystemData.SaveData(data, pathData, nameFileData);
  
  }



   void Update()
   {
        
        activar.onClick.AddListener(pasarAactivo);        

        /*
        if(activo) {
          enActivo.SetActive(true); 
        }else{
          enActivo.SetActive(false);
        }
        */
                                     
   }

   public void pasarAactivo(){

      Image[] mascotaactualC = mascotaactual.GetComponentsInChildren<Image>();
      Image[] mascotaactivarC = mascotaactivar.GetComponentsInChildren<Image>();
      TMP_Text[] mascotanombre = mascotaactual.GetComponentsInChildren<TMP_Text>();

      mascotaactualC[1].sprite = mascotaactivarC[0].sprite;
      mascotaactualC[0].sprite = mascotaactivarC[1].sprite;
      //mascotaactualC[1].sprite = mascotaactivarC[0].sprite;
      mascotanombre[0].text= nombremascotameso.text;
      nombremascotaactualpuesto.text = nombremascotameso.text;
      //data.mascotactual = mascotaactual;

      
      avisoactivacion.SetActive(true);  
  
      cerraravisoactivacion.onClick.AddListener(cerraraviso); 

      data.imagePathmascotactualdespierta = resourcePathDespierto;
      data.imagePathmascotactualdormido = resourcePathDormiendo;
      data.nombreactual = nombremascotaactualpuesto;

       ChangeValues();
       SaveData();
  
   }

   private void cerraraviso(){
      avisoactivacion.SetActive(false); 
   }




            
              
     



   




}

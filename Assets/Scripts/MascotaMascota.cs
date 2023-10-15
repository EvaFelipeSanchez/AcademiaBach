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



   



   private int limit = 0; //Guardar

   void Start()
   {
        mascotadespier.enabled = true; 
        
        
        //nombre.enabled = false; 
        mascotadurmiendo.enabled = false;  
        avisoactivacion.SetActive(false); 
        //enActivo.SetActive(false); 
        activo = false;

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

      mascotaactualC[0].sprite = mascotaactivarC[1].sprite;
      mascotaactualC[1].sprite = mascotaactivarC[0].sprite;
      mascotanombre[0].text= nombremascotameso.text;
      nombremascotaactualpuesto.text = nombremascotameso.text;
      
      avisoactivacion.SetActive(true);  
  
      cerraravisoactivacion.onClick.AddListener(cerraraviso); 
   }

   private void cerraraviso(){
      avisoactivacion.SetActive(false); 
   }

            
              
     



   




}

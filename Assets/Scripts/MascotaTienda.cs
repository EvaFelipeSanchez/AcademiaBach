using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MascotaTienda : MonoBehaviour
{
     public TMP_Text puntosparaComprar;
     public TMP_Text precio;
     public Button Comprar;

     public Image mascotadespier;
     public Image mascotadurmiendo;

     public GameObject mascotaprefab;

     public RectTransform scrollViewContentMascotas; 
     public  RectTransform scrollViewContentTienda;
 

     private int limit = 0; //Guardar




    void Start()
    {
        mascotadespier.enabled = false; 
        mascotadurmiendo.enabled = false; 
           Comprar.onClick.AddListener(comprarMascota);
        
    }



    public void comprarMascota(){

        RectTransform toggleRectTransform = mascotaprefab.GetComponent<RectTransform>();    
        toggleRectTransform.SetParent(null);
        mascotaprefab.gameObject.SetActive(false);  

        RectTransform scrollViewContent2RectTransform =scrollViewContentTienda.GetComponent<RectTransform>();    
        toggleRectTransform.SetParent(scrollViewContent2RectTransform);
       mascotaprefab.gameObject.SetActive(true);


    }


}

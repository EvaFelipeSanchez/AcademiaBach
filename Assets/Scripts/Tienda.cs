using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Tienda : MonoBehaviour
{
     public TMP_Text puntosparaComprar;
     public TMP_Text puntosparaComprarMenuPrin;
     public TMP_Text precio;
     public Button Comprar;

     public Image mascotadespier;
     public Image mascotadurmiendo;

     public GameObject mascotaprefab;

     public RectTransform scrollViewContentMascotas; 
     public  RectTransform scrollViewContentTienda;

     public GameObject avisonocompra;
     
     public Button cerraraviso;
     public GameObject mascotatienda;

     //Nombre

      public TMP_InputField ponernombre;

     private int limit = 0; //Guardar
     private bool terminadaoperacion = false;




    void Start()
    {
        mascotadespier.enabled = false; 
        mascotadurmiendo.enabled = false; 
        avisonocompra.SetActive(false);

        mascotatienda.SetActive(true);
        terminadaoperacion = false;
        limit = 0; 
        
    }
     void Update()
     {
        if(int.TryParse(puntosparaComprar.text, out int puntosparaComprarint)){
            if(int.TryParse(puntosparaComprarMenuPrin.text, out int puntosparaComprarMenuPrinint)){
             if(int.TryParse(precio.text, out int precioint)){
                 if(puntosparaComprarint >= precioint){

                Comprar.onClick.AddListener(comprarMascota); // inputfieldnombre   

                  
                 }else{
                    Comprar.onClick.AddListener(nocomprarMascota); 

                 }

            
             }
            }
        }

        if(terminadaoperacion){
            limit = 0;
            terminadaoperacion = false;
            ponernombre.text = "";
        }

        

        
            
     }




    public void comprarMascota(){

  
                    if(limit == 0 ){
            
                    avisonocompra.SetActive(false);
                    GameObject newmascotacomprada = Instantiate(mascotaprefab, scrollViewContentMascotas);
                    // Obtén una referencia a los componentes "Image" de A y B
                    //Image[] imagesA =  scrollViewContentMascotas.GetComponentsInChildren<Image>();
                    Image[] imagesB = mascotatienda.GetComponentsInChildren<Image>();                  

                    // Obtén una referencia a los componentes "Image" del GameObject clonado
                    Image[] imagesClonedA = newmascotacomprada.GetComponentsInChildren<Image>();

                    TMP_Text[] tmpTextComponent = newmascotacomprada.GetComponentsInChildren<TMP_Text>();
                    tmpTextComponent[1].text = ponernombre.text;

                    if (imagesClonedA.Length > 0)
                    {
                        // Configura el texto del primer TMP_Text encontrado
                        imagesClonedA[0].sprite = imagesB[0].sprite;

                        // Configura el texto del segundo TMP_Text encontrado (si existe)
                        if (imagesClonedA.Length > 1)
                        {
                            imagesClonedA[1].sprite = imagesB[4].sprite;
                        }

                    }                   
                
                    //mascotatienda.SetActive(false);

                    limit = 1;  
                    terminadaoperacion = true;

                    //activarpuestanombre();
      
                    }      
    }




    private void nocomprarMascota(){
        avisonocompra.SetActive(true);
        cerraraviso.onClick.AddListener(cerraravisos);


    }

    private void cerraravisos(){
        avisonocompra.SetActive(false);

    }

    

}

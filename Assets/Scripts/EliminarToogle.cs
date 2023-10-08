using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;


public class EliminarToogle : MonoBehaviour
{
    public GameObject pantallaAviso;
    public GameObject pantallaCompletar;
    public Toggle togglePrefab;
    public  RectTransform scrollViewPapelera;
    public  RectTransform scrollViewChecklist;
    
    public Button eliminarBoton;

    public Button eliminarfinalBoton;
    public Button noeliminarBoton;

    public Button completarBoton;
    public Button nocompletarBoton;

    public Button Restaurar;

    public TMP_Text nombretarea;

    public TMP_Text nombretareaenaviso;
    public TMP_Text nombretareaenavisoCompletar;

    private DateTime fechaCreacion;
    private bool enPapelera = false;

    public GameObject quitarCheckmark;


    // Start is called before the first frame update
    void Start()
    {   
        eliminarBoton.onClick.AddListener(ActivarAviso);
        eliminarfinalBoton.onClick.AddListener(enviarapapeleratoogle);
        Restaurar.onClick.AddListener(enviarachecklisttoogle);
        noeliminarBoton.onClick.AddListener(quitaraviso);

        completarBoton.onClick.AddListener(enviarapapeleraCompletotoogle);
        nocompletarBoton.onClick.AddListener(quitaravisoCompletar);


        pantallaAviso.SetActive(false);
        pantallaCompletar.SetActive(false);
        Restaurar.gameObject.SetActive(false);
        quitarCheckmark.SetActive(true);
    }

        public void ActivarAviso()
    {
        pantallaAviso.SetActive(true);        
        string textoDelToggle = nombretarea.text;
        nombretareaenaviso.text = textoDelToggle;

    }

        public void enviarapapeleraCompletotoogle(){

        RectTransform toggleRectTransform = togglePrefab.GetComponent<RectTransform>();    
        toggleRectTransform.SetParent(null);
        togglePrefab.gameObject.SetActive(false);  

        RectTransform scrollViewContent2RectTransform =scrollViewPapelera.GetComponent<RectTransform>();    
        toggleRectTransform.SetParent(scrollViewContent2RectTransform);
        togglePrefab.gameObject.SetActive(true);

        //Sumar Puntos y tiempo trabajado

        eliminarBoton.gameObject.SetActive(false); 
        Restaurar.gameObject.SetActive(true); 
         pantallaCompletar.SetActive(false);
        fechaCreacion = DateTime.Now;
        enPapelera = true;
        quitarCheckmark.SetActive(false);


    }



    public void enviarapapeleratoogle(){

        RectTransform toggleRectTransform = togglePrefab.GetComponent<RectTransform>();    
        toggleRectTransform.SetParent(null);
        togglePrefab.gameObject.SetActive(false);  

        RectTransform scrollViewContent2RectTransform =scrollViewPapelera.GetComponent<RectTransform>();    
        toggleRectTransform.SetParent(scrollViewContent2RectTransform);
        togglePrefab.gameObject.SetActive(true);

        eliminarBoton.gameObject.SetActive(false); 
        Restaurar.gameObject.SetActive(true); 
        pantallaAviso.SetActive(false);
        fechaCreacion = DateTime.Now;
        enPapelera = true;
        quitarCheckmark.SetActive(false);


    }

        public void enviarachecklisttoogle(){

        RectTransform toggleRectTransform = togglePrefab.GetComponent<RectTransform>();    
        toggleRectTransform.SetParent(null);
        togglePrefab.gameObject.SetActive(false);  

        RectTransform scrollViewContent2RectTransform =scrollViewChecklist.GetComponent<RectTransform>();    
        toggleRectTransform.SetParent(scrollViewContent2RectTransform);
        togglePrefab.gameObject.SetActive(true);

        eliminarBoton.gameObject.SetActive(true); 
          Restaurar.gameObject.SetActive(false); 
        pantallaAviso.SetActive(false);
        fechaCreacion = DateTime.Now;
        enPapelera = false;
        quitarCheckmark.SetActive(true);


    }

    private void Update()
    {

        if(enPapelera){
                        // Calcula la diferencia en días entre la fecha actual y la fecha de creación.
            TimeSpan diferencia = DateTime.Now - fechaCreacion;

            // Si han pasado 30 días o más, elimina el Toggle.
            if (diferencia.TotalDays >= 30)
            {
                // Elimina el Toggle o realiza cualquier acción necesaria para eliminarlo.
                Destroy(togglePrefab.gameObject);
            }

        }

    }
    public void quitaraviso(){
         pantallaAviso.SetActive(false);
         nombretareaenaviso.text = "";

    }

        public void quitaravisoCompletar(){
         pantallaCompletar.SetActive(false);
         nombretareaenavisoCompletar.text = "";

    }


}
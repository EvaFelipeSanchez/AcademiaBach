using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using JetBrains.Annotations;
using UnityEditor.VersionControl;
using System;


public class Timer : MonoBehaviour
{


    [SerializeField] private Image uiFill;
    [SerializeField] private TMP_Text uiText;
    [SerializeField] private TMP_Text mensajeestado; //Mensajes durante el tiempo.

    [SerializeField] private TMP_Text resultadoText; //Slider
    [SerializeField] private Slider slider;


    public bool Pat = true;
    public int pomset = 5; //1500                                                                  //CAMBIAR
    private int remainingpomset;

    public int desc = 3; //300                                                                     //CAMBIAR
    private int remainingdesc ;

    public int desc2 = 6; //1800
    private int remainingdesc2;

    public int minutostotales = 0;


    private int numtotalset = 8; 
    public int numacset4 = 0; //Sets para el descanso 2
    public int numacset = 0; //Los que lleva realizados el usuario

    //public int Duration; 

    public bool GoOn = false;
    public bool empezarcoroutine = true;
    private bool sesiontrab = true;

    public bool activarboton = true;

    //Salir de la aplicación
    public GameObject confirmationPanel;
    
    public Button isYes;
    public Button isNo;
    private bool isConfirmationOpen = false;
    public bool isInSet = false;

    public Button empezar;

  
    //Distribución de puntos

    public int puntosactuales = 0; //Se guarda
    public TMP_Text puntostexto;
    public TMP_Text puntostexto2;

    //public GameManager gameManager;

    //Mascota

    public GameObject mascotaactual;
    public Image MascotaActualDor;
    public Image MascotaActualDepr;
    public bool viva = true;

    public bool tenermascota = true;

    public GameObject SinMascota;


    public TMP_Text textoamover;
    public RectTransform  scrollViewOrigen;
    public RectTransform  scrollViewCementerio;

    public GameObject mascotacementarioprefab;

     private int limit = 0; //Guardar

     private bool terminadaoperacion = false;

     DateTime fechaActual = DateTime.Now;

    //GuardarPuntosVariableText

    public ExampleDataPuntos data;
    public const string pathData = "Data/test";
    public const string nameFileData = "ExampleData";

    public TMP_Text nombremascotactual;

  



    private void Start()
    {
        Being(pomset);
        mensajeestado.text = "EMPEZAR";
        
        //gameManager = FindObjectOfType<GameManager>();

        MascotaActualDor.enabled = false;
        MascotaActualDepr.enabled = true;
        SinMascota.SetActive(false);
        confirmationPanel.SetActive(isConfirmationOpen);
        isYes.onClick.AddListener(CerrarAplicacion);
        isNo.onClick.AddListener(NoCerrarAplicacion);
        empezar.onClick.AddListener(empezarSet);
        isInSet = false;
        minutostotales = 0;
        numacset= 0;
        viva = true;

        puntostexto.text = data.puntos.ToString();
        puntostexto2.text= data.puntos.ToString();
        puntosactuales = data.puntos;
        //MascotaActualDor = data.mascotactualdormido;
        //MascotaActualDepr = data.mascotactualdespierta;
        //nombremascotactual = data.nombreactual;


        //mascotaactual = data.mascotactual;

        var dataFound = SaveLoadSystemData.LoadData<ExampleDataPuntos>(pathData, nameFileData);

        if(dataFound != null){
            data = dataFound;
            ChangeValues();
        }
        else{
        data = new ExampleDataPuntos();
        SaveData();
        }
        Debug.Log("Estado almacenado: " + data.puntos.ToString());


    }

    private void Update()
    {
        if(minutostotales < -1)
        {
            StopCoroutine(UpdateTimer());
        }

        puntostexto.text = data.puntos.ToString();
        puntostexto2.text= data.puntos.ToString();
        puntosactuales = data.puntos;



        if(isInSet){
          Screen.fullScreen = true;
            MascotaActualDor.enabled = true;
            MascotaActualDepr.enabled = false;
        }else{
          Screen.fullScreen = false;
            MascotaActualDor.enabled = false;
            MascotaActualDepr.enabled = true;
        }

  
        if (Input.GetKeyDown(KeyCode.Escape) && !isConfirmationOpen)
        { 
            if(isInSet){
            // El usuario ha presionado Escape, muestra la ventana de confirmación
            ShowExitConfirmation();
            }

        }


        if(terminadaoperacion){
            limit = 0;
            terminadaoperacion = false;

        }

       //string textoPuntosEntero = puntosactuales.ToString();  
       //puntostexto.text = textoPuntosEntero;
        //puntostexto2.text = textoPuntosEntero;

   
    }

    private void ChangeValues(){
      puntostexto.text = data.puntos.ToString();
      puntostexto2.text= data.puntos.ToString();
      //MascotaActualDor = data.mascotactualdormido;
       //MascotaActualDepr = data.mascotactualdespierta;
      //nombremascotactual = data.nombreactual;
      //mascotaactual = data.mascotactual;
      //Debug.Log("Estado almacenado: " + puntostexto.text);
    }

    private void SaveData(){
        SaveLoadSystemData.SaveData(data, pathData, nameFileData);
    }



    public void Changevivavalue(){
        //viva =  true;
        SinMascota.SetActive(false);
        MascotaActualDor.enabled = false;
        MascotaActualDepr.enabled = true;
        //Debug.Log("Viva es true");
    }
    

    private void ShowExitConfirmation(){
        isConfirmationOpen = true;
        confirmationPanel.SetActive(isConfirmationOpen);


    }

    private void CerrarAplicacion(){
        //Application.Quit();                  //CAMBIAR
        //viva = false;

        SinMascota.SetActive(true);
        MascotaActualDor.enabled = false;
        MascotaActualDepr.enabled = false;
        isConfirmationOpen = false;
        
        mascotamuerta();

        confirmationPanel.SetActive(isConfirmationOpen);
        numacset = 0;
        minutostotales = 0;
         OnEnd();

  

    } 
    
        public GameObject EncontrarObjetoPorTexto()
    {
        // Obtén el contenido de la ScrollView
        Transform content = scrollViewOrigen;

        // Recorre todos los elementos en el contenido de la ScrollView
        foreach (Transform child in content)
        {
            // Intenta obtener el componente TMP_Text en el GameObject hijo
            //TMP_Text tmpText = child.GetComponent<TMP_Text>();
            TMP_Text[] tmpText = child.GetComponentsInChildren<TMP_Text>();

           Debug.Log(tmpText[1].text);
            // Verifica si se encontró un componente TMP_Text y si su texto coincide con el contenido buscado
            if (tmpText != null && tmpText[1].text == textoamover.text)
            {

                // Si se encuentra un objeto con el texto deseado, puedes retornar el GameObject
                return child.gameObject;
            }
        }

        // Si no se encuentra, retorna null
        return null;
    }


    public void mascotamuerta(){

        if(limit == 0 ){
        

  
         GameObject newmascotamuerta = Instantiate(mascotacementarioprefab, scrollViewCementerio);
         GameObject mascotaamover = EncontrarObjetoPorTexto();

        Image[] imagesB = mascotaamover.GetComponentsInChildren<Image>();                  
         Image[] imagesClonedA = newmascotamuerta.GetComponentsInChildren<Image>();
         TMP_Text[] tmpTextComponent = newmascotamuerta.GetComponentsInChildren<TMP_Text>();
         tmpTextComponent[0].text =  textoamover.text;
         string fechaFormateada = fechaActual.ToString("dd/MM/yyyy");
         tmpTextComponent[1].text = fechaFormateada;
         
        imagesClonedA[0].sprite = imagesB[0].sprite;    


         limit = 1;  
         terminadaoperacion = true;
         mascotaamover.SetActive(false);
       
         }  

   }

  private void NoCerrarAplicacion(){
        isConfirmationOpen = false;
        confirmationPanel.SetActive(isConfirmationOpen);
    }

    private void empezarSet(){

        isInSet = true;

    }

    private void Being(int Second)
    {
        remainingpomset = Second;
        remainingdesc = desc;
        remainingdesc2 = desc2;
        sesiontrab = true;

        StartCoroutine(UpdateTimer());
        isInSet = true;
        float valorActual = slider.value;
        float minutos = valorActual / 60; // Convierte el valor del Slider a minutos.
        int minutosredondeados = (int)Math.Round(minutos);
        mensajeestado.text = "EMPEZAR";
        UpdateResultadoText(minutosredondeados);

 
    }

        public void OnSliderValueChanged()
    {
        float valorActual = slider.value;
        float minutos = valorActual / 60; // Convierte el valor del Slider a minutos.
        int minutosredondeados = (int)Math.Round(minutos);

        // Actualiza el texto del resultado con los minutos.
        UpdateResultadoText(minutosredondeados);
    }

    private void UpdateResultadoText(float minutos)
    {
        // Formatea el texto para mostrar los minutos
        resultadoText.text = "Minutos: " + minutos.ToString() + ":00"; // 
    }




    public void calcularminutos(float value)
    {
        minutostotales = (int)value; ///Multiplicar por 60                                                  //CAMBIAR
        minutossalvados = minutostotales;

    }

    public int minutossalvados = 0;

    public string[] mensajesdetrabajo = {
        "Mensaje de trabajo 1",
        "Mensaje de trabajo 2",
        "Mensaje de trabajo 3",
        "Mensaje de trabajo 4"
    };

    public string[] mensajesdedescanso = {
        "Mensaje de descanso 1",
        "Mensaje de descanso 2",
        "Mensaje de descanso 3",
        "Mensaje de descanso 4"
    };
    public string[] mensajesdeconsejos = {
        "Mensaje de consejo 1",
        "Mensaje de consejo 2",
        "Mensaje de consejo 3",
        "Mensaje de consejo 4"
    };


    public IEnumerator UpdateTimer()
    {    
        

           
            //while (minutostotales > 0)
            //{
            
                while (numacset < numtotalset)
                {

                    System.Random random = new System.Random();            
                    int randomIndexTrabajo =  random.Next(0, mensajesdetrabajo.Length);
                    int randomIndexDescanso =  random.Next(0, mensajesdedescanso.Length);
                    int randomIndexConsejo =  random.Next(0, mensajesdeconsejos.Length);

                    if(minutostotales < -1) {
                         OnEnd();
                         yield break;
                    }


                    if (sesiontrab)
                    {
  
                        mensajeestado.text =  mensajesdetrabajo[randomIndexTrabajo];

                        while (remainingpomset >= 0)
                        {
                            uiText.text = $"{remainingpomset / 60:00}:{remainingpomset % 60:00}";
                            uiFill.fillAmount = Mathf.InverseLerp(0, pomset, remainingpomset);

                            if (GoOn)
                            {

                                    uiText.text = $"{remainingpomset / 60:00}:{remainingpomset % 60:00}";
                                    uiFill.fillAmount = Mathf.InverseLerp(0, pomset, remainingpomset);
                                    remainingpomset--;
                                    minutostotales--;
                                    slider.value--; //
                                    if(minutostotales < -1){
                                         OnEnd();
                                         yield break;
                                    }else{
                                      yield return new WaitForSeconds(1f);
                                    }
                
             
                             }
                             yield return null;

                    }
                        remainingpomset = pomset;
                        sesiontrab = !sesiontrab;

                    }
                    else
                    { 
                        mensajeestado.text =  mensajesdedescanso[randomIndexDescanso];
                        if (numacset4 == 4)
                        {

                            while (remainingdesc2 >= 0)
                            {
                                uiText.text = $"{remainingdesc2 / 60:00}:{remainingdesc2 % 60:00}";
                                uiFill.fillAmount = Mathf.InverseLerp(0, desc2, remainingdesc2);

                                if (GoOn)
                                {

                                        uiText.text = $"{remainingdesc2 / 60:00}:{remainingdesc2 % 60:00}";
                                        uiFill.fillAmount = Mathf.InverseLerp(0, desc2, remainingdesc2);
                                        remainingdesc2--;
                                        minutostotales--;
                                        slider.value--; //
                                        if(minutostotales < -1){
                                            OnEnd();
                                            yield break;
                                        }else{
                                        yield return new WaitForSeconds(1f);
                                        }
                                    
                                }
                                yield return null;


                            }
                            remainingdesc2 = desc2;
                            numacset++;
                            sesiontrab = !sesiontrab;
                            numacset4 = 0;

                        }
                        else
                        {
                            while (remainingdesc >= 0)
                            {
                                uiText.text = $"{remainingdesc / 60:00}:{remainingdesc % 60:00}";
                                uiFill.fillAmount = Mathf.InverseLerp(0, desc, remainingdesc);

                                if (GoOn)
                                {

                                        uiText.text = $"{remainingdesc / 60:00}:{remainingdesc % 60:00}";
                                        uiFill.fillAmount = Mathf.InverseLerp(0, desc, remainingdesc);
                                        remainingdesc--;
                                        minutostotales--;
                                        slider.value--; //
                                        if(minutostotales < -1){
                                            OnEnd();
                                            yield break;
                                        }else{
                                        yield return new WaitForSeconds(1f);
                                        }
                                    
                                }
                                yield return null;


                            }
                            remainingdesc = desc;
                            numacset++;
                            sesiontrab = !sesiontrab;
                            numacset4++;

                        }


                    }


                }
         
            //}                 


        OnEnd();
    }


        public void BotonParaEmpezar() //Click para pausar
    {
        if(activarboton){
            GoOn = !GoOn;
            System.Random random = new System.Random();      
            int randomIndexTrabajo =  random.Next(0, mensajesdetrabajo.Length);
            mensajeestado.text =  mensajesdetrabajo[randomIndexTrabajo];
            activarboton = false;

        }

    }

    private void OnEnd()
    {
        //End Time , if want Do something
        print("End");
        
        mensajeestado.text = "EMPEZAR";
        GoOn = !GoOn;
        activarboton = true;
        minutostotales = minutossalvados;
        Being(pomset);
        isInSet = false;
        puntosactuales = puntosactuales + numacset;
        data.puntos = puntosactuales;
        ChangeValues();
        SaveData();
        numacset = 0;
        slider.value = slider.minValue;

        


    }

    
}

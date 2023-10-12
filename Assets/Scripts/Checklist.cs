using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Checklist : MonoBehaviour
{

    public Toggle togglePrefab;
    public Button convertButton;

    public TMP_Text nombretarea;
    public TMP_Text nombretareaenaviso;
    public  RectTransform scrollViewContent;


    public GameObject pantallaAviso;
    public GameObject pantallaAvisoCompleto;

    //Entradas
    public TMP_InputField inputField;
    public Text dateinput;

    //public GameObject togglePrefabb;

    public TMP_Text tipotareainput;

    public TMP_Text puntosinput;

    public GameObject calendario;

    


    public bool isOn = false;
    private List<Toggle> toggles = new List<Toggle>();
    public Transform toggleContainer;
    public List<string> toggleData;


    void Start(){

           convertButton.onClick.AddListener(ConvertTextToToggle);
           pantallaAviso.SetActive(false);
           pantallaAvisoCompleto.SetActive(false);
           calendario.SetActive(true);
           isOn = false;
           //togglePrefab.onValueChanged.AddListener(OnToggleValueChanged);
           //SortElements();
 

           
    }


   /* void Update()
    {
        SortElements();
    }

        private void SortElements()
    {
        // Ordenar la lista de elementos en función del valor del Toggle
       toggles.Sort((a, b) =>
        {
            // Aquí debes definir tu propio criterio de ordenamiento
            // Por ejemplo, si estás ordenando por nombres:
            string nameA = a.GetComponent<Text>().text;
            string nameB = b.GetComponent<Text>().text;
            return nameA.CompareTo(nameB);
        });

        // Reorganizar los elementos en el contenido
        for (int i = 0; i < toggles.Count; i++)
        {
        toggles[i].transform.SetSiblingIndex(i);
        }
    }
    */

        public void ConvertTextToToggle()
    {
        string text = inputField.text;
        string datetext = dateinput.text;
        string tipodatotext = tipotareainput.text;
        string puntostext = puntosinput.text;
        
        

        if (!string.IsNullOrEmpty(text))
        {

            Toggle newToggle = Instantiate(togglePrefab, scrollViewContent);

            //newToggle.GetComponentInChildren<TextMeshProUGUI>().text = text;
            //newToggle.GetComponentInChildren<Text>().text = datetext;

            Toggle toggleComponent = newToggle.GetComponent<Toggle>();

            TMP_Text[] tmpTextComponents = toggleComponent.GetComponentsInChildren<TMP_Text>();
            toggleComponent.GetComponentInChildren<TextMeshProUGUI>().text = text;
            toggleComponent.GetComponentInChildren<Text>().text = datetext;//

            if (tmpTextComponents.Length > 0)
            {
                // Configura el texto del primer TMP_Text encontrado
                tmpTextComponents[0].text = "Eliminar";

                // Configura el texto del segundo TMP_Text encontrado (si existe)
                if (tmpTextComponents.Length > 1)
                {
                    tmpTextComponents[1].text = text;
                }

                // Configura el texto del tercer TMP_Text encontrado (si existe)
                if (tmpTextComponents.Length > 2)
                {
                    tmpTextComponents[2].text = tipodatotext; //puntostext
                }

                if (tmpTextComponents.Length > 3)
                {
                    tmpTextComponents[3].text = puntostext; //puntostext
                }
            }

            toggles.Add(newToggle);

 

        }
    }


    /*private void OnToggleValueChanged(bool isOn)
    {
        if (isOn)
        {
            // El Toggle se encendió, mostrar el Canvas de aviso.
            pantallaAvisoCompleto.SetActive(true);
       
            string textoDelToggle = nombretarea.text;
            nombretareaenaviso.text = textoDelToggle;
  


        }
        else
        {
            // El Toggle se apagó, ocultar el Canvas de aviso.
           pantallaAvisoCompleto.SetActive(false);

        }
    }*/

        public void GetToggleData()
    {
        foreach (Toggle toggle in toggles)
        {
            // Verificar si el toggle está marcado o desmarcado
            bool isToggled = toggle.isOn;

            // Aquí puedes realizar cualquier otra acción basada en el estado del toggle
            Debug.Log("Toggle state: " + isToggled);
        }
    }
    



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Checklist : MonoBehaviour
{
    public TMP_InputField inputField;
    public Toggle togglePrefab;
    public Button convertButton;

    public TMP_Text nombretarea;
    public TMP_Text nombretareaenaviso;
    public  RectTransform scrollViewContent;


    public GameObject pantallaAviso;
    public GameObject pantallaAvisoCompleto;


    public bool isOn = false;



    void Start(){
           convertButton.onClick.AddListener(ConvertTextToToggle);
           pantallaAviso.SetActive(false);
           pantallaAvisoCompleto.SetActive(false);
           isOn = false;
           togglePrefab.onValueChanged.AddListener(OnToggleValueChanged);

           
    }

        public void ConvertTextToToggle()
    {
        string text = inputField.text;

        if (!string.IsNullOrEmpty(text))
        {
        Toggle newToggle = Instantiate(togglePrefab, scrollViewContent);
        newToggle.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }
    }




    private void OnToggleValueChanged(bool isOn)
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
    }
    



}

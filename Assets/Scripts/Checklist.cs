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
    public  RectTransform scrollViewContent;

    void Start(){
           convertButton.onClick.AddListener(ConvertTextToToggle);
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

}

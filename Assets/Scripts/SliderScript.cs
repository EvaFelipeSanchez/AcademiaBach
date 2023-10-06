using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class SliderScript : MonoBehaviour
{
  public Slider slider; // Arrastra el Slider desde la jerarquía al Inspector.
    public TMP_Text resultadoText; // Arrastra el Text desde la jerarquía al Inspector.

    private void Start()
    {
        // Asegúrate de que el valor inicial del Text coincida con el valor inicial del Slider.
        UpdateResultadoText(slider.value);
    }

    public void OnSliderValueChanged()
    {
        float valorActual = slider.value;
        float minutos = valorActual / 60; // Convierte el valor del Slider a minutos.

        // Actualiza el texto del resultado con los minutos.
        UpdateResultadoText(minutos);
    }

    private void UpdateResultadoText(float minutos)
    {
        // Formatea el texto para mostrar los minutos.
        resultadoText.text = "Minutos: " + minutos.ToString("F1") + ":00"; // "F1" muestra un decimal.
    }

}

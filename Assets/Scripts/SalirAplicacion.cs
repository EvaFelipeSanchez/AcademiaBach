using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SalirAplicacion : MonoBehaviour
{

    public GameObject confirmationPanel;

    public Button isYes;
    public Button isNo;
    private bool isConfirmationOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        Screen.fullScreen = true;
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isConfirmationOpen)
        {
            // El usuario ha presionado Escape, muestra la ventana de confirmación
            ShowExitConfirmation();
        }
    }

    private void ShowExitConfirmation()
    {
        isConfirmationOpen = true;
        // Muestra una ventana emergente de confirmación
        // Puedes usar un panel UI o una ventana emergente personalizada aquí

        // Por ejemplo, puedes mostrar un panel de Canvas UI con texto y botones de confirmación y cancelación
        // Asegúrate de configurar el panel de manera adecuada en el editor de Unity

        // Añade un botón de confirmación que llame a la función ConfirmExit() y otro botón para Cancelar
    }

    public void ConfirmExit()
    {
        // Esta función se llama cuando el usuario confirma la salida
        // Puedes agregar aquí cualquier lógica adicional antes de salir de la aplicación
        Application.Quit();
    }

    public void CancelExit()
    {
        // Esta función se llama cuando el usuario cancela la salida
        isConfirmationOpen = false;
        // Cierra la ventana de confirmación o realiza cualquier acción necesaria
    }
}

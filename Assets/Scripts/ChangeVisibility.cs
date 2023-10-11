using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeVisibility : MonoBehaviour
{
    public GameObject objectToToggle;


    public Button button;

    private bool objectsActive = false;

    private void Start()
    {
        button.onClick.AddListener(toogleobjeto);
        objectToToggle.SetActive(false);
 



    }


    public void toogleobjeto(){
        objectsActive = !objectsActive;
        objectToToggle.SetActive(objectsActive);


    }
}

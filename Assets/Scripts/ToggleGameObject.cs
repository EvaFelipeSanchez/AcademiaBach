using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleGameObject : MonoBehaviour
{
    public GameObject objectToToggle;


    private void Start()
    {
    
        objectToToggle.SetActive(false);

    }



}

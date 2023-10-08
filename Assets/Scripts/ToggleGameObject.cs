using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleGameObject : MonoBehaviour
{
    public GameObject objectToToggle;

    public Button toggleButton;

    private bool isObjectActive = false;

    private void Start()
    {
    
        toggleButton.onClick.AddListener(ToggleObjectVisibility);
        objectToToggle.SetActive(isObjectActive);
    }

    private void ToggleObjectVisibility()
    {
        isObjectActive = !isObjectActive;
        objectToToggle.SetActive(isObjectActive);

        
    }


}

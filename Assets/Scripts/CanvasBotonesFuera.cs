using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasBotonesFuera : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject objectToToggle;
    public Button toggleButton;

    private bool isObjectActive = false;


    private void ToggleObjectVisibility()
    {
        isObjectActive = !isObjectActive;
        objectToToggle.SetActive(isObjectActive);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuToggle : MonoBehaviour
{
    bool currentState =false;
    [SerializeField] UnityEvent turnedOn;
    [SerializeField] UnityEvent turnedOff;

    public void ToggleState(){
        currentState = !currentState;

        if(currentState == true){
            TurnOn();
        }else{
            TurnOff();
        }

    }

    public void TurnOn(){
        currentState = true;
        turnedOn.Invoke();

    }

    public void TurnOff(){
        currentState = false;
        turnedOff.Invoke();

    }


}

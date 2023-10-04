using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using JetBrains.Annotations;
using UnityEditor.VersionControl;

public class Timer : MonoBehaviour
{



    public void BotonParaEmpezar() //Click para pausar
    {
        GoOn = !GoOn;

    }

    [SerializeField] private Image uiFill;
    [SerializeField] private TMP_Text uiText;

    public bool Pat = true;
    public int pomset = 5; //1500 //CAMBIAR
    private int remainingpomset;

    public int desc = 3; //300  //CAMBIAR
    private int remainingdesc ;

    public int desc2 = 6; //1800
    private int remainingdesc2;

    public int minutostotales = 0;


    private int numtotalset = 8; 
    public int numacset4 = 0; //Sets para el descanso 2
    public int numacset = 0; //Los que lleva realizados el usuario

    //public int Duration; 

    public bool GoOn = false;
    public bool empezarcoroutine = true;
    private bool sesiontrab = true;


    private void Start()
    {
        Being(pomset);
    }

    private void Update()
    {
        if(minutostotales < -1)
        {
            StopCoroutine(UpdateTimer());
        }
   
    }
    //


    private void Being(int Second)
    {
        remainingpomset = Second;
        remainingdesc = desc;
        remainingdesc2 = desc2;
        StartCoroutine(UpdateTimer());
 
    }



    public void calcularminutos(float value)
    {
        minutostotales = (int)value; ///Multiplicar por 60 //CAMBIAR

    }


    public IEnumerator UpdateTimer()
    {

            //while (minutostotales > 0)
            //{
                while (numacset < numtotalset)
                {
                    if(minutostotales < -1) {
                         yield break;
                    }


                    if (sesiontrab)
                    {
                        while (remainingpomset >= 0)
                        {
                            uiText.text = $"{remainingpomset / 60:00}:{remainingpomset % 60:00}";
                            uiFill.fillAmount = Mathf.InverseLerp(0, pomset, remainingpomset);

                            if (GoOn)
                            {

                                        uiText.text = $"{remainingpomset / 60:00}:{remainingpomset % 60:00}";
                                        uiFill.fillAmount = Mathf.InverseLerp(0, pomset, remainingpomset);
                                        remainingpomset--;
                                        minutostotales--;
                                        yield return new WaitForSeconds(1f);
             
                             }
                             yield return null;

                }
                        remainingpomset = pomset;
                        sesiontrab = !sesiontrab;

                    }
                    else
                    {
                        if (numacset4 == 4)
                        {

                            while (remainingdesc2 >= 0)
                            {
                                uiText.text = $"{remainingdesc2 / 60:00}:{remainingdesc2 % 60:00}";
                                uiFill.fillAmount = Mathf.InverseLerp(0, desc2, remainingdesc2);

                                if (GoOn)
                                {

                                        uiText.text = $"{remainingdesc2 / 60:00}:{remainingdesc2 % 60:00}";
                                        uiFill.fillAmount = Mathf.InverseLerp(0, desc2, remainingdesc2);
                                        remainingdesc2--;
                                        minutostotales--;
                                        yield return new WaitForSeconds(1f);
                                    
                                }
                                yield return null;


                            }
                            remainingdesc2 = desc2;
                            numacset++;
                            sesiontrab = !sesiontrab;
                            numacset4 = 0;

                        }
                        else
                        {
                            while (remainingdesc >= 0)
                            {
                                uiText.text = $"{remainingdesc / 60:00}:{remainingdesc % 60:00}";
                                uiFill.fillAmount = Mathf.InverseLerp(0, desc, remainingdesc);

                                if (GoOn)
                                {

                                        uiText.text = $"{remainingdesc / 60:00}:{remainingdesc % 60:00}";
                                        uiFill.fillAmount = Mathf.InverseLerp(0, desc, remainingdesc);
                                        remainingdesc--;
                                        minutostotales--;
                                        yield return new WaitForSeconds(1f);
                                    
                                }
                                yield return null;


                            }
                            remainingdesc = desc;
                            numacset++;
                            sesiontrab = !sesiontrab;
                            numacset4++;

                        }


                    }


                }
         
            //}                 


        OnEnd();
    }



    private void OnEnd()
    {
        //End Time , if want Do something
        print("End");
    }
}

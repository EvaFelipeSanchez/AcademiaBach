using System.Collections;
using UnityEngine;


public class UIAnimation : MonoBehaviour
{
   [SerializeField] float duration;
   [SerializeField] float delay;
   [SerializeField] AnimationCurve animationCurve;
   [SerializeField] RectTransform target;
   [SerializeField] Vector2 startingPoint;
   [SerializeField] Vector2 finalPoint;

   public void FadeIn(){
        StopAllCoroutines();
        StartCoroutine(FadeInCoroutine(finalPoint,startingPoint ));

   }


      public void FadeOut(){
        StopAllCoroutines();
        StartCoroutine(FadeInCoroutine(startingPoint, finalPoint));
   }
   

   IEnumerator FadeInCoroutine(Vector2 a, Vector2 b){

    Vector2  startingPoint = a;    
    Vector2  finalPoint = b;

    float elapsed = 0;
    while(elapsed <= delay){
        elapsed += Time.deltaTime;
        yield return null;
    }

    elapsed = 0;
    while(elapsed <= duration){
        float percentage = elapsed / duration;
        float curvePercentage = animationCurve.Evaluate(percentage);
        elapsed+= Time.deltaTime;
        Vector2 currentPosition = Vector2.Lerp(startingPoint, finalPoint, curvePercentage  );
        target.anchoredPosition = currentPosition;
        yield return null;
    }

    target.anchoredPosition = finalPoint;

   }

 

}

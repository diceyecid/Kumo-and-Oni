using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class imageFade : MonoBehaviour
{
    public CanvasGroup img1, img2;

    public void FadeIn()
    {
        StartCoroutine(FadeImage(img2, img2.alpha, 1));
    }
    public void FadeOut()
    {
        StartCoroutine(FadeImage(img1, img1.alpha, 0));
    }

    public IEnumerator FadeImage(CanvasGroup cg, float start, float end, float lerp = 0.5f)
    {
        float standartLerp = Time.time;
        float started = Time.time - standartLerp;
        float percentage = started / lerp;

        while (true)
        {
            started = Time.time - standartLerp;
            percentage = started / lerp;

            float current = Mathf.Lerp(start, end, percentage);

            cg.alpha = current;

            if (percentage >= 1){
                if (current == 0) Destroy(cg.gameObject);
                break;
                }

            yield return new WaitForEndOfFrame();
        }
        print("done");
        
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FXAddCoinValue : MonoBehaviour
{
    [SerializeField] private float fadeSpeed = 3;
    [SerializeField] private CanvasGroup canvasGroup;
    public TMP_Text coinValue;


    public void StartShow(bool isExtra)
    {
        StartCoroutine(Show(isExtra));
    }


    //ниже корутины основная задача плавно появлять и пропадать, через CanvasGroup
    private IEnumerator Show(bool isExtra)
    {
        if(isExtra)
            coinValue.color = Color.red;

        float alpha = 0f;
        if (canvasGroup != null)
        {
            while (alpha < 1f)
            {
                alpha += fadeSpeed * Time.deltaTime;
                canvasGroup.alpha = alpha;
                yield return null;
            }
        }
        
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(FadeOut());

    }

    private IEnumerator FadeOut()
    {
        float alpha = 1f;
        if (canvasGroup != null)
        {
            while (alpha > 0f)
            {
                alpha -= fadeSpeed * Time.deltaTime;
                canvasGroup.alpha = alpha;
                yield return null;
            }
        }
        gameObject.transform.SetParent(null);
        gameObject.SetActive(false);
    }
}

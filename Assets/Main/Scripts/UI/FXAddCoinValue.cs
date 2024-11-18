using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FXAddCoinValue : MonoBehaviour
{
    [SerializeField] private float fadeSpeed = 3;
    [SerializeField] private CanvasGroup canvasGroup;
    public TMP_Text coinValue;


    public void StartShow()
    {
        StartCoroutine(Show());
    }

    private IEnumerator Show()
    {
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

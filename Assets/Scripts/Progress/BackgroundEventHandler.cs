using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundEventHandler : MonoBehaviour
{
    private Image image;
    private WaitForSeconds wait;
    private Coroutine disableImageComponentCoroutine;
    private void Awake()
    {
        image = GetComponent<Image>();
    }
    
    public void FadeTo(float alpha, float duration)
    {
        if (alpha == 0)
        {
            if (wait == null)
            {
                wait = new WaitForSeconds(duration);
            }

            if (disableImageComponentCoroutine != null)
            {
                StopCoroutine(disableImageComponentCoroutine);
            }

            disableImageComponentCoroutine = StartCoroutine(DisableImageComponentCoroutine());   
        }
        else
        {
            image.enabled = true;
        }
        
        image.DOFade(alpha, duration);
    }

    private IEnumerator DisableImageComponentCoroutine()
    {
        yield return wait;
        image.enabled = false;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundEventHandler : MonoBehaviour
{
    private Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
    }
    
    public void FadeTo(float alpha, float duration)
    {
        image.DOFade(alpha, duration);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorPreep : MonoBehaviour
{
    private CanvasGroup moonCanvasGroup;
    private float flashSpeed = 0.2f;//���������ٶ�
    private bool isOn = true;
    private float maxAlpha = 0.6f;//��ʾ�����alphaֵ
    private float minAlpha = 0.05f;//��ʾ�����alphaֵ

    void Start()
    {
        moonCanvasGroup = GetComponent<CanvasGroup>();
    }

    void Update()
    {
        if (moonCanvasGroup.alpha < maxAlpha && isOn)
        {
            moonCanvasGroup.alpha += flashSpeed * Time.deltaTime;
        }
        else
        {
            isOn = false;
            moonCanvasGroup.alpha -= flashSpeed * Time.deltaTime;
            if (moonCanvasGroup.alpha < minAlpha)
            {
                isOn = true;
            }
        }
    }
}

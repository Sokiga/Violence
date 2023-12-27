using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using static UnityEngine.ParticleSystem;

public class TerroritySystem : MonoBehaviour
{
    public float terValue = 0;
    public float maxTerValue = 100;
    private PlayerController playerController;
    private BreathingSystem breathingSystem;
    private float maxRadius = 5f;
    private float upValue = 30;
    private float downValue = 20;
    [SerializeField]
    private Image terImage;
    private void Start()
    {
        terValue = 0;
        breathingSystem = GetComponent<BreathingSystem>();
        playerController = GetComponent<PlayerController>();
        upValue = 30;
        downValue = 20;

    }
    private void Update()
    {
        bool isUp = false;
        for (int i = 0; i < playerController.enemyTarget.Count; i++)
        {
            float radius = (transform.position - playerController.enemyTarget[i].transform.position).magnitude;
            if (radius < maxRadius)
            {
                isUp = true;
                break;
            }
        }
        if (isUp)
        {
            terValue += upValue * Time.deltaTime;
            terValue = Mathf.Min(maxTerValue, terValue);
        }
        else
        {
            terValue -= downValue * Time.deltaTime;
            terValue = Mathf.Max(terValue, 0f);
        }
        if (terValue > maxTerValue * 0.9f &&
            breathingSystem.breathingValue > breathingSystem.moveMaxValue)
        {
            playerController.isStopMove = true;
        }
        else if (!playerController.isOpenPlane && !playerController.isOpenBag)
        {
            playerController.isStopMove = false;
        }
        terImage.fillAmount = terValue * 0.5f + 0.5f;
    }

}

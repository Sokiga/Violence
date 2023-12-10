using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using static UnityEngine.ParticleSystem;

public class TerroritySystem : MonoBehaviour
{
    private PlayerController playerController;
    private SpriteRenderer spriteRenderer;
    private float terValue = 0;
    private float maxRadius = 5f;
    private new ParticleSystem particleSystem;
    private float upValue = 30;
    private float downValue = 20;
    private float maxTerValue = 100;
    private void Start()
    {
        terValue = 0;
        particleSystem = GetComponentInChildren<ParticleSystem>();
        playerController = GetComponent<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        upValue = 30;
        downValue = 20;

    }
    private void Update()
    {
        particleSystem.textureSheetAnimation.SetSprite(0, spriteRenderer.sprite);
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
        if (terValue > maxTerValue * 0.9f)
        {
            playerController.isStopMove = true;
        }
        else
        {
            playerController.isStopMove = false;
        }
    }

}

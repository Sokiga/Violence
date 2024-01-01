using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCtrl : MonoBehaviour
{
    [SerializeField]
    Canvas canvas;
    [SerializeField]
    PlayerController playerController;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canvas.gameObject.activeInHierarchy == true)
        {
            canvas.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            canvas.gameObject.SetActive(true);
            playerController.isHasKey = true;
        }
    }
}

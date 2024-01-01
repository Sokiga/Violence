using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCtrl : MonoBehaviour
{
    [SerializeField]
    Canvas canvas;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            canvas.gameObject.SetActive(true);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canvas.gameObject.activeInHierarchy == true)
        {
            canvas.gameObject.SetActive(false);
        }
    }
}

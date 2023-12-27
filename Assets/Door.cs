using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag=="Player" && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log(1);
            GameObject.Find("Textmanager1").GetComponent<Textmanager>().isSpoken = true;
        }
    }
}

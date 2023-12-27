using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    private bool isheard=false;
    private void Update()
    { 
        if(GameObject.Find("Textmanager1").GetComponent<Textmanager>().Index==2&& GameObject.Find("Textmanager1").GetComponent<Textmanager>().dialogIndex == 999)
        {
            isheard = true;
        }
        if (isheard)
        {
            Invoke("scared", 0.5f);
        }
        }
    private void scared()
    {
        
            GameObject.Find("Textmanager1").GetComponent<Textmanager>().isSpoken = true;
            isheard = false;
            Debug.Log("zizizi");
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class Attention : MonoBehaviour
{ public PlayableDirector Director;
    public delegate void MyEventDelegate();
    public event MyEventDelegate MyEvent;
    public Camera C;
    void Start()
    {
        MyEvent += playDirector;
        Director.stopped+=Camera;
    }

    private void Camera(PlayableDirector director)
    {
        C.GetComponent<CmeraControl>().enabled =true;
        
    }

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            MyEvent();
            C.GetComponent<CmeraControl>().enabled=false;

        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        MyEvent-=playDirector;
    }
    void playDirector()
    {
        Director.Play();
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class WakeUp : MonoBehaviour
{
    public PlayableDirector director;
    public Camera followcamera;
    // Start is called before the first frame update
    void Start()
    {
        director.Play();
    }

    // Update is called once per frame
 
}

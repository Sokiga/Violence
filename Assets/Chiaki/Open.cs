using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class OpenDoor : MonoBehaviour
{
    public PlayableDirector Direcotr;
    public Canvas C;
    private bool open=false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player"&&Input.GetKeyDown(KeyCode.F)&&!open)
        {
            C.gameObject.SetActive(true);
            Direcotr.Play();
            Speak();
        }
    }
    private void Speak()
    {
        
        GameObject.Find("TextManager").GetComponent<Textmanager>().hasSpoken = true;
    }
}

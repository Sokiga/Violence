using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterInteraction : MonoBehaviour
{
    public Collider2D Girl;
    public Animator Animator;
    private Tunnel t;
    private void Awake()
    {
        t= GetComponent<Tunnel>();
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Tunnel")
        {
            Debug.Log(1);
            Animator.SetBool("IsDrile", false);
        }
    }
}

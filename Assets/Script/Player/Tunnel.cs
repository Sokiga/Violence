using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Tunnel : MonoBehaviour
{
    [SerializeField] float S_Force;
    private bool isStraddling;
    public Rigidbody rb;
    public Collider Player;
    public Transform S_Target;


    private void FixedUpdate()
    {
        if (isStraddling)
        {if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(S_Force * S_Target.position);
            }
        else if(Input.GetKey(KeyCode.S)) 
            {
                rb.AddForce(-S_Force * S_Target.position);
            }
        }

    }

    private void OnTriggerStay(UnityEngine.Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(3);
            if (Input.GetKeyDown(KeyCode.F))
            {
                Player.isTrigger = true;
                isStraddling = true;
                Debug.Log(2);
            }
        }
    }
    private void OnTriggerExit(UnityEngine.Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player.isTrigger = false;
            isStraddling = false;
            S_Force=-S_Force;
        }
    }
}


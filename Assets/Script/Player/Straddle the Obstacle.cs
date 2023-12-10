using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraddletheObstacle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float S_Force;
    private bool isStraddling;
    public Rigidbody2D rb;
    public Collider2D Player;
    public Transform S_Target;


    private void FixedUpdate()
    {
        if (isStraddling)
        {
            rb.AddForce(S_Force * S_Target.position);
            Debug.Log(1);
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

using BehaviorDesigner.Runtime.Tasks.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Tunnel : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    public bool isDriling;
    public Rigidbody2D rb;
    public Collider2D Player;
    public Transform S_Target;
    public Animator Girl;
    public Transform start;
    Vector3 moveDirection = Vector3.zero;
    private void Start()
    {
        
        moveDirection = (S_Target.position - transform.position).normalized;
    }

    private void Update()
    {
        Debug.Log(transform.position-S_Target.position);
        Debug.DrawLine(rb.transform.position, S_Target.position,Color.red);
        if (isDriling)
        {
            StartDrill();
            //GameObject.Find("Player").GetComponent<PlayerController>().TurnPlayerDirection(S_Target.position);
            if (Input.GetKey(KeyCode.W))
            {
                
                Girl.SetBool("isMoving", true);
                rb.transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.S))
            {

                Girl.SetBool("isMoving", true);
                rb.transform.Translate(-moveDirection * moveSpeed * Time.deltaTime);
            }
            else
            {
                Girl.SetBool("isMoving", false); // Õ£÷π≤•∑≈“∆∂Ø∂Øª≠
            }
        } 
    }

     void OnTriggerStay2D(UnityEngine.Collider2D other)
    {

        if (other.CompareTag("Player")&&Input.GetKeyDown(KeyCode.F))
        {   rb.transform.position= start.transform.position;
            isDriling = true;
            Player.isTrigger = true;
            other.GetComponent<PlayerController>().isStopMove = true;
        }
    }
     void OnTriggerExit2D(UnityEngine.Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player.isTrigger = false;
            isDriling = false;
            Girl.SetBool("IsDrile", false);
            other.GetComponent<PlayerController>().isStopMove = false;
        }
    }

    void StartDrill()
    {
        Girl.SetBool("IsDrile",true);
    }
}


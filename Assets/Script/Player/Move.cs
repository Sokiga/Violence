using BehaviorDesigner.Runtime.Tasks.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private PlayerController playerController;
    private void Start()
    {
<<<<<<< HEAD

=======
>>>>>>> parent of f80107e (Text1)
        playerController = GetComponent<PlayerController>();
    }
    public void Run()
    {
        rb.velocity = MoveSpead * movement;
<<<<<<< HEAD

        //���޸ĵط������Ľ�ɫ�������ƶ�����

=======
>>>>>>> parent of f80107e (Text1)
        if (rb.velocity.magnitude > 0.05f)
        {
            playerController.moveType = MoveType.kTrot;
        }
        else
        {
            playerController.moveType = MoveType.kStop;
        }
    }
    public void SlowMove()
    {
        rb.velocity = MoveSpead * movement / 2;
<<<<<<< HEAD

        playerController.moveType = MoveType.kCreep;

=======
        playerController.moveType = MoveType.kCreep;
>>>>>>> parent of f80107e (Text1)
        if (rb.velocity.magnitude > 0.05f)
        {
            playerController.moveType = MoveType.kCreep;
        }
        else
        {
            playerController.moveType = MoveType.kStop;
        }
<<<<<<< HEAD

=======
>>>>>>> parent of f80107e (Text1)
    }
    public void Dash()
    {
        rb.velocity = MoveSpead * movement * 2;
<<<<<<< HEAD


        playerController.moveType = MoveType.kRun;

=======

        playerController.moveType = MoveType.kRun;
>>>>>>> parent of f80107e (Text1)
        if (rb.velocity.magnitude > 0.05f)
        {
            playerController.moveType = MoveType.kRun;
        }
        else
        {
            playerController.moveType = MoveType.kStop;
        }
    }
    public float MoveSpead = 5f;
    public Rigidbody2D rb;
    Vector3 movement;

    void Update()
    {
        if (!playerController.isStopMove)
        {
<<<<<<< HEAD

            
            movement.x = -Input.GetAxis("Horizontal");

            //����û����� 
            //���޸ĵط��������ƶ�����
            movement.x = -Input.GetAxis("Horizontal");//��������뷵��һ��-1��1֮���ֵ

=======
            
            movement.x = -Input.GetAxis("Horizontal");
>>>>>>> parent of f80107e (Text1)
            movement.y = Input.GetAxis("Vertical");
        }
        else
        {
            movement = Vector3.zero;
        }
<<<<<<< HEAD

       
    }

    void FixedUpdate()
    {

        //�ж�

=======
       
    }
    void FixedUpdate()
    {
        
>>>>>>> parent of f80107e (Text1)
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Dash();
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            SlowMove();
        }
        else
        {
            Run();
        }
<<<<<<< HEAD
     



        //movement*�ٶ�*�����뺯��������֮���ʱ����
        //�㶨�ٶ��ƶ�

=======
        
>>>>>>> parent of f80107e (Text1)
    }
}

    

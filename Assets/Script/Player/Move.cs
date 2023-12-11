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

        //（修改地方）更改角色控制器移动类型

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

            //检测用户输入 
            //（修改地方）调整移动方向
            movement.x = -Input.GetAxis("Horizontal");//会根据输入返回一个-1到1之间的值

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

        //行动

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
     



        //movement*速度*函数与函数被调用之间的时间间隔
        //恒定速度移动

=======
        
>>>>>>> parent of f80107e (Text1)
    }
}

    

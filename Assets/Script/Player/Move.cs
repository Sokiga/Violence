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
        //（修改地方）获取角色控制器
>>>>>>> ced1ad7c68f90008a433a1a15123f8553b33ccaa
        playerController = GetComponent<PlayerController>();
    }
    public void Run()
    {
        rb.velocity = MoveSpead * movement;
<<<<<<< HEAD
=======
        //（修改地方）更改角色控制器移动类型
>>>>>>> ced1ad7c68f90008a433a1a15123f8553b33ccaa
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
        //（修改地方）更改角色控制器移动类型
>>>>>>> ced1ad7c68f90008a433a1a15123f8553b33ccaa
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

>>>>>>> ced1ad7c68f90008a433a1a15123f8553b33ccaa
    }
    public void Dash()
    {
        rb.velocity = MoveSpead * movement * 2;
<<<<<<< HEAD

        playerController.moveType = MoveType.kRun;
=======
        //（修改地方）改角色控制器移动类型
>>>>>>> ced1ad7c68f90008a433a1a15123f8553b33ccaa
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
=======
            //检测用户输入 
            //（修改地方）调整移动方向
            movement.x = -Input.GetAxis("Horizontal");//会根据输入返回一个-1到1之间的值
>>>>>>> ced1ad7c68f90008a433a1a15123f8553b33ccaa
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
        
=======
        //就比如我按下键盘的左箭头，意味着要往左动函数会返回-1
        //如果是右箭头 意味着会返回-1
    }
    void FixedUpdate()
    {

        //行动
>>>>>>> ced1ad7c68f90008a433a1a15123f8553b33ccaa
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
        
=======


        //movement*速度*函数与函数被调用之间的时间间隔
        //恒定速度移动
>>>>>>> ced1ad7c68f90008a433a1a15123f8553b33ccaa
    }
}

    

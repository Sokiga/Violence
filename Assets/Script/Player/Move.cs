using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
<<<<<<< HEAD
<<<<<<< HEAD
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
=======
   
      
    
  

    // Start is called before the first frame update
    public void Run()
    {
        rb.velocity = MoveSpead * movement;
>>>>>>> parent of b38d41a (Text)
=======
   
      
    
  

    // Start is called before the first frame update
    public void Run()
    {
        rb.velocity = MoveSpead * movement;
>>>>>>> parent of ced1ad7 (vio)
    }
    public void SlowMove()
    {
        rb.velocity = MoveSpead * movement / 2;
<<<<<<< HEAD
<<<<<<< HEAD
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
>>>>>>> parent of ced1ad7 (vio)

=======
>>>>>>> parent of f80107e (Text1)
=======

>>>>>>> parent of b38d41a (Text)
    }
    public void Dash()
    {
        rb.velocity = MoveSpead * movement * 2;
<<<<<<< HEAD
<<<<<<< HEAD
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
=======
>>>>>>> parent of b38d41a (Text)
=======
>>>>>>> parent of ced1ad7 (vio)
    }
    public float MoveSpead = 5f;
    public Rigidbody rb;
    Vector3 movement;
    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
<<<<<<< HEAD
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

=======
        //检测用户输入 
        movement.x = Input.GetAxis("Horizontal");//会根据输入返回一个-1到1之间的值
        movement.z = Input.GetAxis("Vertical");
       
    //就比如我按下键盘的左箭头，意味着要往左动函数会返回-1
    //如果是右箭头 意味着会返回-1
}
>>>>>>> parent of ced1ad7 (vio)
    void FixedUpdate()
    {
       
        //行动

=======
=======
        //检测用户输入 
        movement.x = Input.GetAxis("Horizontal");//会根据输入返回一个-1到1之间的值
        movement.z = Input.GetAxis("Vertical");
>>>>>>> parent of b38d41a (Text)
       
    //就比如我按下键盘的左箭头，意味着要往左动函数会返回-1
    //如果是右箭头 意味着会返回-1
}
    void FixedUpdate()
    {
<<<<<<< HEAD
        
>>>>>>> parent of f80107e (Text1)
=======
       
        //行动
>>>>>>> parent of b38d41a (Text)
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
<<<<<<< HEAD
<<<<<<< HEAD
     

=======
      
>>>>>>> parent of ced1ad7 (vio)


        //movement*速度*函数与函数被调用之间的时间间隔
        //恒定速度移动

=======
        
>>>>>>> parent of f80107e (Text1)
    }
}
=======
      
>>>>>>> parent of b38d41a (Text)

        //movement*速度*函数与函数被调用之间的时间间隔
        //恒定速度移动
    }

}

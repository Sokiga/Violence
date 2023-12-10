using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
   
      
    
  

    // Start is called before the first frame update
    public void Run()
    {
        rb.velocity = MoveSpead * movement;
    }
    public void SlowMove()
    {
        rb.velocity = MoveSpead * movement / 2;

    }
    public void Dash()
    {
        rb.velocity = MoveSpead * movement * 2;
    }
    public float MoveSpead = 5f;
    public Rigidbody rb;
    Vector3 movement;
    // Update is called once per frame
    void Update()
    {
        //检测用户输入 
        movement.x = Input.GetAxis("Horizontal");//会根据输入返回一个-1到1之间的值
        movement.z = Input.GetAxis("Vertical");
       
    //就比如我按下键盘的左箭头，意味着要往左动函数会返回-1
    //如果是右箭头 意味着会返回-1
}
    void FixedUpdate()
    {
       
        //行动
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
      

        //movement*速度*函数与函数被调用之间的时间间隔
        //恒定速度移动
    }

}

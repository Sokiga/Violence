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
        //����û����� 
        movement.x = Input.GetAxis("Horizontal");//��������뷵��һ��-1��1֮���ֵ
        movement.z = Input.GetAxis("Vertical");
       
    //�ͱ����Ұ��¼��̵����ͷ����ζ��Ҫ���󶯺����᷵��-1
    //������Ҽ�ͷ ��ζ�Ż᷵��-1
}
    void FixedUpdate()
    {
       
        //�ж�
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
      

        //movement*�ٶ�*�����뺯��������֮���ʱ����
        //�㶨�ٶ��ƶ�
    }

}

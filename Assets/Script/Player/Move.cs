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

=======
        //����û����� 
        movement.x = Input.GetAxis("Horizontal");//��������뷵��һ��-1��1֮���ֵ
        movement.z = Input.GetAxis("Vertical");
       
    //�ͱ����Ұ��¼��̵����ͷ����ζ��Ҫ���󶯺����᷵��-1
    //������Ҽ�ͷ ��ζ�Ż᷵��-1
}
>>>>>>> parent of ced1ad7 (vio)
    void FixedUpdate()
    {
       
        //�ж�

=======
=======
        //����û����� 
        movement.x = Input.GetAxis("Horizontal");//��������뷵��һ��-1��1֮���ֵ
        movement.z = Input.GetAxis("Vertical");
>>>>>>> parent of b38d41a (Text)
       
    //�ͱ����Ұ��¼��̵����ͷ����ζ��Ҫ���󶯺����᷵��-1
    //������Ҽ�ͷ ��ζ�Ż᷵��-1
}
    void FixedUpdate()
    {
<<<<<<< HEAD
        
>>>>>>> parent of f80107e (Text1)
=======
       
        //�ж�
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


        //movement*�ٶ�*�����뺯��������֮���ʱ����
        //�㶨�ٶ��ƶ�

=======
        
>>>>>>> parent of f80107e (Text1)
    }
}
=======
      
>>>>>>> parent of b38d41a (Text)

        //movement*�ٶ�*�����뺯��������֮���ʱ����
        //�㶨�ٶ��ƶ�
    }

}

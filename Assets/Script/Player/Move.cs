using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private PlayerController playerController;
    private void Start()
    {
        //���޸ĵط�����ȡ��ɫ������
        playerController = GetComponent<PlayerController>();
    }
    public void Run()
    {
        rb.velocity = MoveSpead * movement;
        //���޸ĵط������Ľ�ɫ�������ƶ�����
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
        //���޸ĵط������Ľ�ɫ�������ƶ�����
        if(rb.velocity.magnitude>0.05f)
        {
            playerController.moveType = MoveType.kCreep;
        }
        else
        {
            playerController.moveType = MoveType.kStop;
        }

    }
    public void Dash()
    {
        rb.velocity = MoveSpead * movement * 2;
        //���޸ĵط����Ľ�ɫ�������ƶ�����
        if(rb.velocity.magnitude>0.05f)
        {
            playerController.moveType= MoveType.kRun;
        }
        else
        {
            playerController.moveType = MoveType.kStop;
        }
    }
    public float MoveSpead = 5f;
    public Rigidbody2D rb;
    Vector3 movement;
    // Update is called once per frame
    void Update()
    {
        if(!playerController.isStopMove)
        {
            //����û����� 
            //���޸ĵط��������ƶ�����
            movement.x = -Input.GetAxis("Horizontal");//��������뷵��һ��-1��1֮���ֵ
            movement.y = Input.GetAxis("Vertical");
        }
        else
        {
            movement = Vector3.zero;
        }
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

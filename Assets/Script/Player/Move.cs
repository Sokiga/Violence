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
        //���޸ĵط�����ȡ��ɫ������
>>>>>>> ced1ad7c68f90008a433a1a15123f8553b33ccaa
        playerController = GetComponent<PlayerController>();
    }
    public void Run()
    {
        rb.velocity = MoveSpead * movement;
<<<<<<< HEAD
=======
        //���޸ĵط������Ľ�ɫ�������ƶ�����
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
        //���޸ĵط������Ľ�ɫ�������ƶ�����
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
        //���޸ĵط����Ľ�ɫ�������ƶ�����
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
            //����û����� 
            //���޸ĵط��������ƶ�����
            movement.x = -Input.GetAxis("Horizontal");//��������뷵��һ��-1��1֮���ֵ
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
        //�ͱ����Ұ��¼��̵����ͷ����ζ��Ҫ���󶯺����᷵��-1
        //������Ҽ�ͷ ��ζ�Ż᷵��-1
    }
    void FixedUpdate()
    {

        //�ж�
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


        //movement*�ٶ�*�����뺯��������֮���ʱ����
        //�㶨�ٶ��ƶ�
>>>>>>> ced1ad7c68f90008a433a1a15123f8553b33ccaa
    }
}

    

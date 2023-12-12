using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float MoveSpead = 5f;
    public Rigidbody2D rb;
    Vector3 movement;
    private PlayerController playerController;
    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }
    public void Run()
    {
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
        if (rb.velocity.magnitude > 0.05f)
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
        playerController.moveType = MoveType.kRun;
        playerController.moveType = MoveType.kRun;
        if (rb.velocity.magnitude > 0.05f)
        {
            playerController.moveType = MoveType.kRun;
        }
        else
        {
            playerController.moveType = MoveType.kStop;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerController.isStopMove)
        {
            //����û����� 
            movement.x = Input.GetAxis("Horizontal");//��������뷵��һ��-1��1֮���ֵ
            movement.z = Input.GetAxis("Vertical");
        }
        else
        {
            movement = Vector3.zero;
        }

       
    }
    void FixedUpdate()
    {
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

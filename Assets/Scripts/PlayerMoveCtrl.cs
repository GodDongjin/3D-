using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������ٵ� ���۳�Ʈ�� �ڵ� �߰����ش�.
//[RequireComponent(typeof(Rigidbody))]

public class PlayerMoveCtrl : Player
{
   
    float v, h;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    private void FixedUpdate()
    {
        //ĳ���� ������
        Move();
        //�÷��̾� ȸ��
        Rotate();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void Move()
    {
        v = Input.GetAxisRaw("Vertical");
        h = Input.GetAxisRaw("Horizontal");

        movePos = new Vector3(h, 0f, v).normalized;

        player.transform.position += moveSpeed * movePos * Time.deltaTime;

        
    }
    private void Rotate()
    {
       player.transform.LookAt(player.transform.position + movePos);
    }
}

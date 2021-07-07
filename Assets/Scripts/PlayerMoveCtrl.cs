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
        if(!isAttack)
		{
            //ĳ���� ������
            Move();
            //�÷��̾� ȸ��
            Rotate();
        }

        //if (isAttack && isClick)
		//{
        //    
        //    MouseRotate();
        //    
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) ||
            Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            isWalk = true;
            //isAttack = false;
        }

        if (Input.GetKeyUp(KeyCode.W) && Input.GetKeyUp(KeyCode.S) &&
            Input.GetKeyUp(KeyCode.A) && Input.GetKeyUp(KeyCode.D))
        {
            isWalk = false;
            //isAttack = false;
        }
        IsWalk(isWalk);
        IsAttack(isAttack);
       
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

 //   public void MouseRotate()
	//{
 //       ray = Camera.main.ScreenPointToRay(Input.mousePosition);

 //       if (Physics.Raycast(ray, out hit))
 //       {
 //           movePos = hit.point;
 //       }

 //       Vector3 direction = (movePos - player.transform.position).normalized;
 //       Quaternion lookRotation = Quaternion.LookRotation(direction);
 //       player.transform.rotation = lookRotation;

 //       //player.transform.LookAt(player.transform.position + movePos);
 //       //isClick = false;
 //   }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//리지드바디 컴퍼넌트를 자동 추가해준다.
//[RequireComponent(typeof(Rigidbody))]

public class PlayerMoveCtrl : Player
{
	float v, h;

	// Start is called before the first frame update
	void Start()
	{
		player = GameObject.Find("Player");
		playerRig = player.gameObject.GetComponent<Rigidbody>();

		//inventoryUi = GameObject.Find("Inventory");
		//
		//if (inventoryUi.gameObject.activeSelf)
		//{
		//	inventoryUi.SetActive(false);
		//}

	}

	private void FixedUpdate()
	{
		if (state != Player_State.Die || GameManager.instance.g_Boss.isDie == false)
		{
			if (state == Player_State.Move)
			{
				//캐릭터 움직임
				Move();
				//플레이어 회전
				Rotate();
			}
		//}
		//if(state == Player_State.Dash)
		//{
		//	Dash();
		}
	}

	// Update is called once per frame
	void Update()
	{

		if(Input.GetKeyDown(KeyCode.Y))
		{
			currentHp = -1;
		}

		if (state != Player_State.Die || GameManager.instance.g_Boss.isDie == false)
		{
			if (state != Player_State.Dash && state != Player_State.Attack && state != Player_State.HeavyRigidity
			&& state != Player_State.Skille1 && state != Player_State.Skille2 && state != Player_State.Die)
			{
				if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) ||
			   Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
				{
					ChangeState(Player_State.Move);
				}

				else if (!Input.GetKeyDown(KeyCode.W) && !Input.GetKeyDown(KeyCode.S) &&
					!Input.GetKeyDown(KeyCode.A) && !Input.GetKeyDown(KeyCode.D))
				{
					ChangeState(Player_State.Idle);
				}
			}


			if (Input.GetKeyDown(KeyCode.LeftShift) && state != Player_State.Dash)
			{
				ChangeState(Player_State.Dash);


				Rotate();
				playerRig.AddForce(player.transform.forward * dashSpeed, ForceMode.Impulse);
			}

			InventoryOnOff();
			//player.transform.Rotate(0, player.transform.tra.y, 0);
		}
	}

	private void Move()
	{

		v = Input.GetAxisRaw("Vertical");
		h = Input.GetAxisRaw("Horizontal");

		movePos = new Vector3(h, 0f, v).normalized;
		player.transform.position += movePos * moveSpeed * Time.deltaTime;

		//Debug.Log(movePos);
		// Debug.Log("PlayerPos " + player.transform.position + "movePos" + movePos);
	}

	private void Rotate()
	{
		//Quaternion lookRotation = Quaternion.Lerp(boss.transform.rotation, Quaternion.LookRotation(direction), 0.5f);
		//player.transform.rotation = Quaternion.LookRotation(movePos);
		v = Input.GetAxisRaw("Vertical");
		h = Input.GetAxisRaw("Horizontal");

		movePos = new Vector3(h, 0f, v).normalized;

		player.transform.LookAt(player.transform.position + movePos);

		//Debug.Log();
		//Debug.Log("RotateMovePos " + movePos + "playerRotate " + player.transform.position);
	}

	private void InventoryOnOff()
	{
		//if (Input.GetKeyDown(KeyCode.I))
		//{
		//	if (!inventoryUi.gameObject.activeSelf)
		//	{
		//		inventoryUi.SetActive(true);
		//	}
		//
		//	else if (inventoryUi.gameObject.activeSelf)
		//	{
		//		inventoryUi.SetActive(false);
		//	}
		//
		//	
		//}
	}
}

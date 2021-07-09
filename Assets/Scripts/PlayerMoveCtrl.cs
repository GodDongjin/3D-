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
	}

	private void FixedUpdate()
	{
		if (state == Player_State.Move)
		{
			//캐릭터 움직임
			Move();
			//플레이어 회전
			Rotate();
		}

		if(state == Player_State.Dash)
		{
			Dash();
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (state != Player_State.Dash && state != Player_State.Attack)
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
			v = Input.GetAxisRaw("Vertical");
			h = Input.GetAxisRaw("Horizontal");

			movePos = new Vector3(h, 0f, v).normalized;

			Rotate();
			playerRig.AddForce(player.transform.forward * dashSpeed, ForceMode.Impulse);
		}
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
		//Quaternion lookRotation = Quaternion.Lerp(boss.transform.rotation, Quaternion.LookRotation(direction), 0.5f);
		//player.transform.rotation = Quaternion.LookRotation(movePos);

		player.transform.LookAt(player.transform.position + movePos);
	}


	private void Dash()
	{
		//v = Input.GetAxisRaw("Vertical");
		//h = Input.GetAxisRaw("Horizontal");
		//
		//movePos = new Vector3(h, 0f, v).normalized;
		//
		//playerRig.AddForce(movePos * dashSpeed, ForceMode.Impulse);
	}

	//IEnumerator Dash()
	//{
	//	float startTime = Time.time;

	//	while (Time.time < startTime + dashTime)
	//	{
	//		playerRig.AddForce(player.transform.forward * dashSpeed, ForceMode.Impulse);
	
	//		yield return null;
	//	}
	//}
}

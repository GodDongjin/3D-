using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Player_State
{
	Idle, Move, Attack, Dash, AttackDash
}

public class Player : MonoBehaviour
{
	public static GameObject player;
	public static Animator animator;
	public static Rigidbody playerRig;

	public static Player_State state;

	public static Vector3 movePos;
	public static Ray ray;
	static RaycastHit hit;

	public float maxHp;
	public float currentHp;
	public float moveSpeed;
	public float dashSpeed = 0.5f;

	public static float attackCombo = 0f;
	public int maxLevel;
	public int currentLevel;

	public static bool isAttack = false;
	public static bool isWalk = false;
	public static bool isDash = false;
	public static bool isIdle = false;
	
	public static bool isClick = false;
	public static bool isEnemyHit = false;


	//플레이어 상태를 변경 시키면서 모든 상태에 해당하는 값을 초기화 해준다.
	public static void ChangeState(Player_State nextState)
	{
		state = nextState;

		isAttack = false;
		isWalk = false;
		isDash = false;
		isIdle = false;

		attackCombo = 0;

		switch (state)
		{
			case Player_State.Idle: isIdle = true; isAttack = false; isWalk = false; isDash = false; break;
			case Player_State.Move: isIdle = false; isAttack = false; isWalk = true; isDash = false; break;
			case Player_State.Attack: isIdle = false; isAttack = true; isWalk = false; isDash = false; break;
			case Player_State.Dash: isIdle = false; isAttack = false; isWalk = false; isDash = true; break;
			case Player_State.AttackDash: isIdle = false; isAttack = true; isWalk = false; isDash = true; break;
		}


		animator.SetBool("IsDash", isDash);
		animator.SetBool("IsAttack", isAttack);
		animator.SetBool("IsWalk", isWalk);
		animator.SetBool("IsIdle", isIdle);
		animator.SetFloat("combo", attackCombo);
	}
	public static void MouseRotate()
	{
		if (isClick)
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out hit))
			{
				movePos = hit.point;
			}

			Vector3 direction = (movePos - player.transform.position).normalized;
			Quaternion lookRotation = Quaternion.LookRotation(direction);
			player.transform.rotation = lookRotation;
		}

	}
}

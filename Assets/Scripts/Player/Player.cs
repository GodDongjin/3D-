using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Player_State
{
	Idle, Move, Attack, Skiile1, Dash, AttackDash, HeavyRigidity, LightRigidity
}

public class PlayerInfor
{
	
}

public class Player : MonoBehaviour
{
	public static GameObject player;
	public GameObject hitPrefabs;
	public static Animator animator;
	public static Rigidbody playerRig;


	public PlayerInfor playerInfor = new PlayerInfor();

	public static Player_State state;

	public static Vector3 movePos;
	public static Ray ray;
	static RaycastHit hit;

	public static float maxHp;
	public static float currentHp;
	public static float maxMp;
	public static float currentMp;
	public static float damege;
	public static int lv;
	public static float maxExperience;
	public static float currentExperience;
	public static float moveSpeed = 4f;
	public static float dashSpeed = 0.5f;

	public float rigidity = 10f;
	public static float attackCombo = 0f;

	public static bool isAttack = false;
	public static bool isWalk = false;
	public static bool isDash = false;
	public static bool isIdle = false;
	public static bool isSkiile = false;
	//피격판정
	public static bool isHeavyRigidity;
	public static bool isLightRigidity;


	public static bool isClick = false;
	public static bool isEnemyHit = false;

	

	//플레이어 상태를 변경 시키면서 모든 상태에 해당하는 값을 초기화 해준다.
	public void ChangeState(Player_State nextState)
	{
		state = nextState;

		isSkiile = false;	
		isAttack = false;
		isWalk = false;
		isDash = false;
		isHeavyRigidity = false;
		isLightRigidity = false;
		isIdle = false;
		isClick = true;

		attackCombo = 0;

		switch (state)
		{
			case Player_State.Idle: 
				isIdle = true; isAttack = false; isWalk = false; isDash = false;
				isHeavyRigidity = false; isLightRigidity = false; isSkiile = false; break;

			case Player_State.Move: 
				isIdle = false; isAttack = false; isWalk = true; isDash = false;
				isHeavyRigidity = false; isLightRigidity = false; isSkiile = false; break;
			
			case Player_State.Attack: 
				isIdle = false; isAttack = true; isWalk = false; isDash = false;
				isHeavyRigidity = false; isLightRigidity = false; isSkiile = false; break;
			
			case Player_State.Dash: 
				isIdle = false; isAttack = false; isWalk = false; isDash = true;
				isHeavyRigidity = false; isLightRigidity = false; isSkiile = false; break;

			case Player_State.HeavyRigidity: 
				isIdle = false; isAttack = false; isWalk = false; isDash = false; 
				isHeavyRigidity = true; isLightRigidity = false; isSkiile = false; break;

			case Player_State.LightRigidity: 
				isIdle = false; isAttack = false; isWalk = false; isDash = false;
				isHeavyRigidity = false; isLightRigidity = true; isSkiile = false; break;

			case Player_State.Skiile1:
				isIdle = false; isAttack = false; isWalk = false; isDash = false;
				isHeavyRigidity = false; isLightRigidity = false; isSkiile = true; break;

		}


		animator.SetBool("IsDash", isDash);
		//Debug.Log("IsDash" + isHeavyRigidity);
		animator.SetBool("IsAttack", isAttack);
		//Debug.Log("IsAttack" + isHeavyRigidity);
		animator.SetBool("IsWalk", isWalk);
		//Debug.Log("IsWalk" + isHeavyRigidity);
		animator.SetBool("IsIdle", isIdle);
		//Debug.Log("IsIdle" + isHeavyRigidity);
		animator.SetBool("isHeavyRigidity", isHeavyRigidity);
		
		animator.SetBool("isLightRigidity", isLightRigidity);

		animator.SetBool("isSkiil1", isSkiile);
		//Debug.Log(isHeavyRigidity);
		animator.SetFloat("combo", attackCombo);


	}
	public static void MouseRotate()
	{
		if (isClick)
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			//레이케스트 특정 오브젝트 무시하는 코드
			int layerMask = (-1) - (1 << LayerMask.NameToLayer("Boss"));

			if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
			{
				movePos = hit.point;
				Debug.Log(hit.point);
				Debug.Log(hit.collider.name);
			}

			Vector3 direction = (movePos - player.transform.position).normalized;
			Quaternion lookRotation = Quaternion.LookRotation(direction);
			player.transform.rotation = lookRotation;
		}

	}

	public void PlayerHpLose(float damege, bool big, bool light)
	{
		currentHp = currentHp - damege;

		if (big)
		{
			ChangeState(Player_State.HeavyRigidity);
		}

		else if (light)
		{
			ChangeState(Player_State.LightRigidity);
		}

		Debug.Log(damege + "를 입었다");
		
	}

}

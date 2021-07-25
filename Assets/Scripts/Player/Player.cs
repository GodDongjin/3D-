using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Player_State
{
	Idle, Move, Attack, Skille1, Skille2, Dash, AttackDash, HeavyRigidity, LightRigidity
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
	public SkiilePaticles skilles;

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
	public static float moveSpeed;
	public static float dashSpeed = 0.5f;
	public static float skilleDamege = 10;
	public static float gold = 0;
	public static float useMp;

	public static float rigidity = 10f;
	public static float attackCombo = 0f;

	public static bool isAttack = false;
	public static bool isWalk = false;
	public static bool isDash = false;
	public static bool isIdle = false;
	public static bool isSkiile1 = false;
	public static bool isSkiile2 = false;

	//스킬이 나갔는지 판단
	public static bool isSkille = false;

	//스킬 쿨타임
	public static float maxSkille1Cooldown;
	public static float maxSkille2Cooldown;
	public static float currentSkille1Cooldown;
	public static float currentSkille2Cooldown;
	public static bool isSkille1Cooldown = false;
	public static bool isSkille2Cooldown = false;
	//피격판정
	public static bool isHeavyRigidity;
	public static bool isLightRigidity;


	public static bool isClick = false;
	public static bool isEnemyHit = false;

	

	//플레이어 상태를 변경 시키면서 모든 상태에 해당하는 값을 초기화 해준다.
	public void ChangeState(Player_State nextState)
	{
		state = nextState;

		isSkille = false;
		isSkiile1 = false;
		isSkiile2 = false;
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
				isHeavyRigidity = false; isLightRigidity = false; isSkiile1 = false; isSkiile2 = false; break;

			case Player_State.Move: 
				isIdle = false; isAttack = false; isWalk = true; isDash = false;
				isHeavyRigidity = false; isLightRigidity = false; isSkiile1 = false; isSkiile2 = false; break;
			
			case Player_State.Attack: 
				isIdle = false; isAttack = true; isWalk = false; isDash = false;
				isHeavyRigidity = false; isLightRigidity = false; isSkiile1 = false; isSkiile2 = false; break;
			
			case Player_State.Dash: 
				isIdle = false; isAttack = false; isWalk = false; isDash = true;
				isHeavyRigidity = false; isLightRigidity = false; isSkiile1 = false; isSkiile2 = false; break;

			case Player_State.HeavyRigidity: 
				isIdle = false; isAttack = false; isWalk = false; isDash = false; 
				isHeavyRigidity = true; isLightRigidity = false; isSkiile1 = false; isSkiile2 = false; break;

			case Player_State.LightRigidity: 
				isIdle = false; isAttack = false; isWalk = false; isDash = false;
				isHeavyRigidity = false; isLightRigidity = true; isSkiile1 = false; isSkiile2 = false; break;

			case Player_State.Skille1:
				isIdle = false; isAttack = false; isWalk = false; isDash = false;
				isHeavyRigidity = false; isLightRigidity = false; isSkiile1 = true; isSkiile2 = false; break;

			case Player_State.Skille2:
				isIdle = false; isAttack = false; isWalk = false; isDash = false;
				isHeavyRigidity = false; isLightRigidity = false; isSkiile1 = false; isSkiile2 = true; break;

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

		animator.SetBool("isSkill1", isSkiile1);
		animator.SetBool("isSkill2", isSkiile2);
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
				//Debug.Log(hit.point);
				//Debug.Log(hit.collider.name);
			}

			Vector3 direction = (movePos - player.transform.position).normalized;
			Quaternion lookRotation = Quaternion.LookRotation(direction);
			player.transform.rotation.Equals(new Vector3(player.transform.rotation.x, lookRotation.y, player.transform.position.z));
		}
		if(!isSkille)
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			//레이케스트 특정 오브젝트 무시하는 코드
			int layerMask = (1 << LayerMask.NameToLayer("Ground"));

			if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
			{
				movePos = hit.point;
				//Debug.Log(hit.point);
				//Debug.Log(hit.collider.name);
			}

			Vector3 direction = (movePos - player.transform.position).normalized;
			Quaternion lookRotation = Quaternion.LookRotation(direction);
			player.transform.rotation = lookRotation;
		}

	}

	public void PlayerHpLose(float damege)
	{
		currentHp = currentHp - damege;

		ChangeState(Player_State.HeavyRigidity);
	}

	public void SkilleCooldown()
	{
		if(isSkille1Cooldown)
		{
			currentSkille1Cooldown = currentSkille1Cooldown - Time.deltaTime;

			//Debug.Log("쿨타임 " + currentSkille1Cooldown);

			if(0 >= currentSkille1Cooldown)
			{
				currentSkille1Cooldown = maxSkille1Cooldown;
				isSkille1Cooldown = false;	
			}
		}

		if (isSkille2Cooldown)
		{
			currentSkille2Cooldown = currentSkille2Cooldown - Time.deltaTime;

			//Debug.Log("쿨타임 " + currentSkille2Cooldown);

			if (0 >= currentSkille2Cooldown)
			{
				currentSkille2Cooldown = maxSkille2Cooldown;
				isSkille2Cooldown = false;
			}
		}
	}

	public void UseMp()
	{
		currentMp = currentMp - useMp;

		if(currentMp <= 0)
		{
			currentMp = 0;
		}
	}

	public void UseGold(float num)
	{
		gold = gold - num;
	}

	public void ItemHpUp(float value)
	{
		maxHp = maxHp + value;
	}
	public void ItemMpUp(float value)
	{

		maxMp = maxMp + value;
	}

	public void ItemDamegeUp(float value)
	{

		damege = damege + value;
	}

	public void ItemMoveSpeedUp(float value)
	{
		moveSpeed = moveSpeed + value;
	}
	

}

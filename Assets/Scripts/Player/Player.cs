using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Player_State
{
	Idle, Move, Attack, Skille1, Skille2, Dash, AttackDash, HeavyRigidity, LightRigidity, Die
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
	public static float moveSpeed = 4;
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
	public static bool isDie = false;

	//스킬이 나갔는지 판단
	public static bool isSkille = false;

	//스킬 쿨타임
	public static float maxSkille1Cooldown;
	public static float maxSkille2Cooldown;
	public static float maxItem1Cooldown;
	public static float maxItem2Cooldown;
	public static float currentSkille1Cooldown;
	public static float currentSkille2Cooldown;
	public static float currentItem1Cooldown;

	public static float maxAttckItemTiem;
	public static float currentAttckItemTiem;
	public static float currentMoveSpeedItemTiem;
	public static float maxMoveSpeedItemTiem;

	
	public static float currentItem2Cooldown;
	public static bool isSkille1Cooldown = false;
	public static bool isSkille2Cooldown = false;
	public static bool isItem1Cooldown = false;
	public static bool isItem2Cooldown = false;
	public static bool isAttckItem = false;
	public static bool isMoveSpeedItem = false;
	//피격판정
	public static bool isHeavyRigidity;
	public static bool isLightRigidity;

	//공격판정
	public static bool isAttckCollider = false;

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
		isAttckCollider = false;
		isDie = false;
		attackCombo = 0;

		switch (state)
		{
			case Player_State.Idle: 
				isIdle = true; isAttack = false; isWalk = false; isDash = false;
				isHeavyRigidity = false; isLightRigidity = false; isSkiile1 = false; isSkiile2 = false; isDie = false; break;

			case Player_State.Move: 
				isIdle = false; isAttack = false; isWalk = true; isDash = false;
				isHeavyRigidity = false; isLightRigidity = false; isSkiile1 = false; isSkiile2 = false; isDie = false; break;
			
			case Player_State.Attack: 
				isIdle = false; isAttack = true; isWalk = false; isDash = false;
				isHeavyRigidity = false; isLightRigidity = false; isSkiile1 = false; isSkiile2 = false; isDie = false; break;
			
			case Player_State.Dash: 
				isIdle = false; isAttack = false; isWalk = false; isDash = true;
				isHeavyRigidity = false; isLightRigidity = false; isSkiile1 = false; isSkiile2 = false; isDie = false; break;

			case Player_State.HeavyRigidity: 
				isIdle = false; isAttack = false; isWalk = false; isDash = false; 
				isHeavyRigidity = true; isLightRigidity = false; isSkiile1 = false; isSkiile2 = false; isDie = false; break;

			case Player_State.LightRigidity: 
				isIdle = false; isAttack = false; isWalk = false; isDash = false;
				isHeavyRigidity = false; isLightRigidity = true; isSkiile1 = false; isSkiile2 = false; isDie = false; break;

			case Player_State.Skille1:
				isIdle = false; isAttack = false; isWalk = false; isDash = false;
				isHeavyRigidity = false; isLightRigidity = false; isSkiile1 = true; isSkiile2 = false; isDie = false; break;

			case Player_State.Skille2:
				isIdle = false; isAttack = false; isWalk = false; isDash = false;
				isHeavyRigidity = false; isLightRigidity = false; isSkiile1 = false; isSkiile2 = true; isDie = false; break;

			case Player_State.Die:
				isIdle = false; isAttack = false; isWalk = false; isDash = false;
				isHeavyRigidity = false; isLightRigidity = false; isSkiile1 = false; isSkiile2 = false; isDie = true; break;

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

		animator.SetBool("isDie", isDie);
		//Debug.Log(isHeavyRigidity);
		animator.SetFloat("combo", attackCombo);


	}
	public static void MouseRotate()
	{
		if (isClick)
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			isAttckCollider = true;
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

	public void ItemCooldown()
	{
		if (isItem1Cooldown)
		{
			currentItem1Cooldown = currentItem1Cooldown - Time.deltaTime;

			//Debug.Log("쿨타임 " + currentSkille1Cooldown);

			if (0 >= currentItem1Cooldown)
			{
				currentItem1Cooldown = maxItem1Cooldown;
				isItem1Cooldown = false;
			}
		}

		if (isItem2Cooldown)
		{
			currentItem2Cooldown = currentItem2Cooldown - Time.deltaTime;

			//Debug.Log("쿨타임 " + currentSkille2Cooldown);

			if (0 >= currentItem2Cooldown)
			{
				currentItem2Cooldown = maxItem2Cooldown;
				isItem2Cooldown = false;
			}
		}
	}

	public void ItemTime()
	{
		if (isAttckItem)
		{
			currentAttckItemTiem = currentAttckItemTiem - Time.deltaTime;

			//Debug.Log("쿨타임 " + currentSkille1Cooldown);

			if (0 >= currentAttckItemTiem)
			{
				currentAttckItemTiem = maxAttckItemTiem;
				isAttckItem = false;
				for (int i = 0; i < GameManager.instance.ingameInventory.Slots.Length; i++)
				{
					if (GameManager.instance.ingameInventory.Slots[i].GetItem().itmeInfo.itemName == "attckPotion")
					{
						ItemDamegeUp(-GameManager.instance.ingameInventory.Slots[i].GetItem().itmeInfo.itemValue);
						return;
					}
				}
				
			}
		}

		if (isMoveSpeedItem)
		{
			currentMoveSpeedItemTiem = currentMoveSpeedItemTiem - Time.deltaTime;

			//Debug.Log("쿨타임 " + currentSkille1Cooldown);

			if (0 >= currentMoveSpeedItemTiem)
			{
				currentMoveSpeedItemTiem = maxMoveSpeedItemTiem;
				isMoveSpeedItem = false;
				for (int i = 0; i < GameManager.instance.ingameInventory.Slots.Length; i++)
				{
					if (GameManager.instance.ingameInventory.Slots[i].GetItem().itmeInfo.itemName == "speedPotion")
					{
						ItemMoveSpeedUp(-GameManager.instance.ingameInventory.Slots[i].GetItem().itmeInfo.itemValue);
						return;
					}
				}
			}
		}
	}

	public void UseMp(float value)
	{
		currentMp = currentMp - value;

		if(currentMp >= maxMp)
		{
			currentMp = maxMp;
		}
	}
	public void UseHp(float value)
	{
		currentHp = currentHp - value;

		if (currentHp >= maxHp)
		{
			currentHp = maxHp;
		}
	}

	public void UseAttack(float value)
	{
		damege = damege - value;
		//skilleDamege = skilleDamege - value;
		if (damege <= 0)
		{
			damege = 0;
		}
	}

	public void UseMoveSpeed(float value)
	{
		moveSpeed = moveSpeed - value;

		if (currentMp <= 0)
		{
			currentMp = 0;
		}
	}

	public void UseCollDown(float value)
	{
		currentSkille1Cooldown = currentSkille1Cooldown - value;
		currentSkille2Cooldown = currentSkille2Cooldown - value;

		if (currentSkille1Cooldown <= 0)
		{
			currentSkille1Cooldown = 0;
		}
		if (currentSkille2Cooldown <= 0)
		{
			currentSkille2Cooldown = 0;
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

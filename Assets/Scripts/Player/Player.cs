using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Player_State
{
	Idle, Move, Attack, Dash, AttackDash, HeavyRigidity, LightRigidity
}

public class Player : MonoBehaviour
{
	public static GameObject player;
	public GameObject hitPrefabs;
	public static Animator animator;
	public static Rigidbody playerRig;


	public static Player_State state;

	public static Vector3 movePos;
	public static Ray ray;
	static RaycastHit hit;

	public float maxHp = 100f;
	public float currentHp;
	public float moveSpeed;
	public float dashSpeed = 0.5f;
	public float rigidity = 10f;
	public float damege = 10f;

	public static float attackCombo = 0f;
	public int maxLevel;
	public int currentLevel;

	public static bool isAttack = false;
	public static bool isWalk = false;
	public static bool isDash = false;
	public static bool isIdle = false;
	//�ǰ�����
	public static bool isHeavyRigidity;
	public static bool isLightRigidity;


	public static bool isClick = false;
	public static bool isEnemyHit = false;

	

	//�÷��̾� ���¸� ���� ��Ű�鼭 ��� ���¿� �ش��ϴ� ���� �ʱ�ȭ ���ش�.
	public void ChangeState(Player_State nextState)
	{
		state = nextState;

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
				isHeavyRigidity = false; isLightRigidity = false; break;

			case Player_State.Move: 
				isIdle = false; isAttack = false; isWalk = true; isDash = false;
				isHeavyRigidity = false; isLightRigidity = false; break;
			
			case Player_State.Attack: 
				isIdle = false; isAttack = true; isWalk = false; isDash = false;
				isHeavyRigidity = false; isLightRigidity = false; break;
			
			case Player_State.Dash: 
				isIdle = false; isAttack = false; isWalk = false; isDash = true;
				isHeavyRigidity = false; isLightRigidity = false; break;

			case Player_State.HeavyRigidity: 
				isIdle = false; isAttack = false; isWalk = false; isDash = false; 
				isHeavyRigidity = true; isLightRigidity = false; break;

			case Player_State.LightRigidity: 
				isIdle = false; isAttack = false; isWalk = false; isDash = false;
				isHeavyRigidity = false; isLightRigidity = true; break;
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
		//Debug.Log(isHeavyRigidity);
		animator.SetFloat("combo", attackCombo);
	}
	public static void MouseRotate()
	{
		if (isClick)
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			//�����ɽ�Ʈ Ư�� ������Ʈ �����ϴ� �ڵ�
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

		Debug.Log(damege + "�� �Ծ���");
		
	}
}

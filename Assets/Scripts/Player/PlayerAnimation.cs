using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : Player
{
	string[] name = new string[7];
	float index = 0f;
	// Start is called before the first frame update
	void Start()
	{
		animator = gameObject.GetComponent<Animator>();

		name[0] = "Base Layer.Attack_7Combo_1";
		name[1] = "Base Layer.Attack_7Combo_2";
		name[2] = "Base Layer.Attack_7Combo_3";
		name[3] = "Base Layer.Attack_7Combo_4";
		name[4] = "Base Layer.Attack_7Combo_5";
		name[5] = "Base Layer.Attack_7Combo_6";
	}

	// Update is called once per frame
	void Update()
	{
		
		//animator.SetBool("IsWalk", isWalk);

		if (state == Player_State.Attack)
		{
			AttackCombo();
		}

		if (state == Player_State.Dash)
		{
			Dash();
		}

		if(state == Player_State.HeavyRigidity || state == Player_State.LightRigidity)
		{
			Rigidity();
		}

		if(state == Player_State.Skille1 || state == Player_State.Skille2)
		{
			Skille();
		}
		
	}

	private void AttackCombo()
	{
		if (animator.GetCurrentAnimatorStateInfo(0).IsName(name[(int)attackCombo]))
		{
			float normalizedTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
			
			if (0.7 <= normalizedTime && normalizedTime <= 0.9)
			{
				if (Input.GetMouseButtonDown(0))
				{
					if (attackCombo == 5)
					{
						attackCombo = 0;
						animator.SetFloat("combo", attackCombo);
						ChangeState(Player_State.Idle);
						return;
					}
					isEnemyHit = false;
					isClick = true;
					attackCombo += 1;
					animator.SetFloat("combo", attackCombo);

					MouseRotate();
					isClick = false;

					//isClick = false;	
					return;
				}
			}
			else if (normalizedTime >= 0.9)
			{
				isEnemyHit = false;
				attackCombo = 0;
				animator.SetFloat("combo", attackCombo);
				ChangeState(Player_State.Idle);
				Debug.Log("1초 지남");
			}

			//if (0.2 <= normalizedTime && normalizedTime <= 0.6)
			//{
			//	isEnemyHit = true;
			//}

			//isEnemyHit = false;
		}
	}

	private void Dash()
	{
		if (animator.GetCurrentAnimatorStateInfo(0).IsName("Dodge_Front"))
		{
			float normalizedTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;

			if (normalizedTime >= 0.7)
			{
				ChangeState(Player_State.Idle);
			}
		}
	}

	private void Rigidity()
	{
		if (isHeavyRigidity)
		{
			if (animator.GetCurrentAnimatorStateInfo(0).IsName("Damage_Front_Big_ver_B"))
			{
				float normalizedTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
				if (normalizedTime >= 0.8)
				{
					ChangeState(Player_State.Idle);
				}
			}
		}
		else if (isLightRigidity)
		{
			if (animator.GetCurrentAnimatorStateInfo(0).IsName("Damage_Front_Small_ver_A"))
			{
				float normalizedTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
				if (normalizedTime >= 0.8)
				{
					ChangeState(Player_State.Idle);
				}
			}
		}
	}

	private void Skille()
	{
		if(isSkiile1)
		{
			if(animator.GetCurrentAnimatorStateInfo(0).IsName("3"))
			{
				float normalizedTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
				if (normalizedTime >= 0.8)
				{
					ChangeState(Player_State.Idle);
				}
			}
		}

		if (isSkiile2)
		{
			if (animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
			{
				float normalizedTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
				if (normalizedTime >= 0.8)
				{
					ChangeState(Player_State.Idle);
				}
			}
		}
	}
	//플레이어 공격 코드(수정 전)
	//private void Attack1()
	//{		

	//}

	//private void Attack2()
	//{
	//	if (animator.GetCurrentAnimatorStateInfo(0).IsName(name[1]))
	//	{
	//		float normalizedTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
	//		if (0.8 <= normalizedTime && normalizedTime <= 1)
	//		{
	//			if (Input.GetKeyDown(KeyCode.Space))
	//			{
	//				attackCombo += 1;
	//				animator.SetFloat("combo", attackCombo);

	//			}
	//		}
	//		else if (normalizedTime >= 1)
	//		{
	//			isAttack = false;
	//			Debug.Log("1초 지남");
	//		return;
	//		}
	//	}


	//}

	//private void Attack3()
	//{

	//	if (animator.GetCurrentAnimatorStateInfo(0).IsName(name[2]))
	//	{
	//		float normalizedTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
	//		if (0.8 <= normalizedTime && normalizedTime <= 1)
	//		{
	//			if (Input.GetKeyDown(KeyCode.Space))
	//			{
	//				attackCombo += 1;
	//				animator.SetFloat("combo", attackCombo);

	//				//break;

	//			}
	//		}
	//		else if (normalizedTime >= 1)
	//		{
	//			isAttack = false;
	//			Debug.Log("1초 지남");
	//			return;
	//		}

	//	}

	//}

	//private void Attack4()
	//{
	//	//animator.Play(name[3], 0);
	//	if (animator.GetCurrentAnimatorStateInfo(0).IsName(name[3]))
	//	{
	//		float normalizedTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
	//		if (0.8 <= normalizedTime && normalizedTime <= 1)
	//		{
	//			if (Input.GetKeyDown(KeyCode.Space))
	//			{
	//				attackCombo += 1;
	//				animator.SetFloat("combo", attackCombo);

	//				//break;

	//			}
	//		}
	//		else if (normalizedTime >= 1)
	//		{
	//			isAttack = false;
	//			Debug.Log("1초 지남");
	//			return;
	//		}

	//	}
	//}

	//private void Attack5()
	//{

	//if (animator.GetCurrentAnimatorStateInfo(0).IsName(name[4]))
	//	{
	//		float normalizedTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
	//		//if (0.8 <= normalizedTime && normalizedTime <= 1)
	//		//{
	//		//	if (Input.GetKeyDown(KeyCode.Space))
	//		//	{
	//		//		attackCombo += 1;
	//		//		animator.SetFloat("combo", attackCombo);
	//		//		//break;
	//		//		//StartCoroutine(Attack2());
	//		//	}
	//		//}
	//		/*else*/ if (normalizedTime >= 1)
	//		{
	//			isAttack = false;
	//			Debug.Log("1초 지남");
	//			return;
	//		}

	//	}
	//}

}

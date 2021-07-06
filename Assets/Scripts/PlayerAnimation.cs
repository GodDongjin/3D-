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

		if (isAttack)
		{
			AttackCombo();
		}
		animator.SetBool("IsAttack", isAttack);
	}

	private void AttackCombo()
	{
		if (animator.GetCurrentAnimatorStateInfo(0).IsName(name[(int)attackCombo]))
		{
			float normalizedTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
			
			if (0.8 <= normalizedTime && normalizedTime <= 1)
			{
				if (Input.GetMouseButtonDown(0))
				{
					//isClick = true;
					if (attackCombo == 5)
					{
						attackCombo = 0;
						isAttack = false;
						animator.SetFloat("combo", attackCombo);
						return;
					}
					isClick = true;
					attackCombo += 1;
					animator.SetFloat("combo", attackCombo);
					
					MouseRotate();
					isClick = false;

					//isClick = false;	
					return;
				}
			}
			else if (normalizedTime >= 1)
			{
				isAttack = false;
				attackCombo = 0;
				animator.SetFloat("combo", attackCombo);
				Debug.Log("1초 지남");
			}
		}

		
	}
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

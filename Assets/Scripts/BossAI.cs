using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : Boss
{
	float dis;
	int index;
	string[,] animationName = new string[4, 3];

	

	public GameObject[] prefabs;

	// Start is called before the first frame update
	void Start()
	{
		animationName[0, 0] = "G_Attack1";
		animationName[0, 1] = "G_Attack2";
		animationName[0, 2] = "G_Attack4";

		animationName[1, 0] = "G_Attack3";
		animationName[1, 1] = "G_Attack5_Opp";
		animationName[1, 2] = "G_Attack6";

		animationName[2, 0] = "G_Attack_Special1";
		animationName[3, 0] = "G_Attack_Special2";

		nameOfThePrefab = prefabs[index].name;

		boss = GameObject.Find("Boss");
		player = GameObject.Find("Player");

		animator = gameObject.GetComponent<Animator>();

		state = AI_State.Skill1;
		ChangeState(state);

	}

	// Update is called once per frame
	void Update()
	{
		switch (state)
		{
			case AI_State.Idle: IdleUpdate(); break;
			case AI_State.Move: MoveUpdate(); break;
			case AI_State.Attack1: Attack1Update(); break;
			case AI_State.Attack2: Attack2Update(); break;
			case AI_State.Skill1: Skill1Update(); break;
			case AI_State.Skill2: Skill2Update(); break;
			case AI_State.Stiffness: IdleUpdate(); break;
			case AI_State.Die: IdleUpdate(); break;
		}



		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			animator.SetBool("Attack1", true);
		}

		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			animator.SetBool("Attack2", true);
		}


	}

	public void ChangeState(AI_State nextState)
	{
		state = nextState;

		animator.SetBool("Attack1", false);
		animator.SetBool("Attack2", false);
		animator.SetBool("Skill1", false);
		animator.SetBool("Skill2", false);
		animator.SetBool("Move", false);

		StopAllCoroutines();

		switch (state)
		{
			case AI_State.Idle: StartCoroutine(CoroutineIdel()); break;
			case AI_State.Move: StartCoroutine(CoroutineMove()); break;
			case AI_State.Attack1: StartCoroutine(CoroutineAttack1()); break;
			case AI_State.Attack2: StartCoroutine(CoroutineAttack2()); break;
			case AI_State.Skill1: StartCoroutine(CoroutineSkill1()); break;
			case AI_State.Skill2: StartCoroutine(CoroutineSkill2()); break;
			case AI_State.Stiffness: break;
			case AI_State.Die: break;
		}
	}

	public void IdleUpdate()
	{
		//플레이어랑 보스 거리 차이 체크
		Vector3 direction = (player.transform.position - boss.transform.position).normalized;
		Quaternion lookRotation = Quaternion.Lerp(boss.transform.rotation, Quaternion.LookRotation(direction), 1f);
		boss.transform.rotation = lookRotation;

	}

	public void MoveUpdate()
	{
		boss.transform.position =
			Vector3.MoveTowards(boss.transform.position, player.transform.position, moveSpeed * Time.deltaTime);

		Vector3 direction = (player.transform.position - boss.transform.position).normalized;
		//Quaternion lookRotation = Quaternion.LookRotation(direction);
		Quaternion lookRotation = Quaternion.Lerp(boss.transform.rotation, Quaternion.LookRotation(direction), 0.5f);
		boss.transform.rotation = lookRotation;

		dis = Vector3.Distance(boss.transform.position, player.transform.position);

		if (dis < 5f)
		{
			ChangeState(AI_State.Idle);
		}

		Debug.Log(dis);
	}

	public void Attack1Update()
	{
		//StartCoroutine(CoroutineAttack1());

		//ChangeState(AI_State.Idle);
	}

	public void Attack2Update()
	{
		//StartCoroutine(CoroutineAttack2());


	}

	public void Skill1Update()
	{
		nameOfThePrefab = prefabs[index].name;
		if(!isEffect)
		{
			if (animator.GetCurrentAnimatorStateInfo(0).IsName("G_Attack_Special1"))
			{
				float normalizedTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;

				if (normalizedTime >= 0.4)
				{
					Vector3 vector3 = boss.transform.position + transform.forward * 2;
					Instantiate(prefabs[index], vector3, Quaternion.identity);
					isEffect = true;
				}
			}
		}
		
	}

	public void Skill2Update()
	{

	}

	//코루틴 
	IEnumerator CoroutineIdel()
	{
		dis = Vector3.Distance(boss.transform.position, player.transform.position);

		if (dis <= 3f)
		{
			int randAction = Random.Range(0, 10);

			switch (randAction)
			{
				case 0: state = AI_State.Attack1; break;
				case 1: state = AI_State.Attack1; break;
				case 2: state = AI_State.Attack1; break;
				case 3: state = AI_State.Attack1; break;
				case 4: state = AI_State.Attack2; break;
				case 5: state = AI_State.Attack2; break;
				case 6: state = AI_State.Attack2; break;
				case 7: state = AI_State.Attack2; break;
				case 8: state = AI_State.Skill2; break;
				case 9: state = AI_State.Skill2; break;
				case 10: state = AI_State.Skill1; break;
			}

			Debug.Log("쫒아가");
			ChangeState(state);
		}
		if (dis > 3f)
		{
			ChangeState(AI_State.Move);
			Debug.Log("따라가");
		}


		yield break;

	}

	IEnumerator CoroutineMove()
	{
		animator.SetBool("Move", true);

		//while(true)
		//{
		//
		//}
		if (dis < 3f)
		{
			ChangeState(AI_State.Idle);
		}

		yield return new WaitForSeconds(3f);

		ChangeState(AI_State.Idle);

		yield break;
	}

	IEnumerator CoroutineAttack1()
	{
		animator.SetBool("Attack1", true);

		while (true)
		{
			yield return new WaitUntil(() => BossAnimatorEnd("G_Attack4"));

			ChangeState(AI_State.Idle);

			yield break;
		}
	}

	IEnumerator CoroutineAttack2()
	{
		animator.SetBool("Attack2", true);

		while (true)
		{
			yield return new WaitUntil(() => BossAnimatorEnd("G_Attack6"));

			ChangeState(AI_State.Idle);

			yield break;
		}
	}

	IEnumerator CoroutineSkill1()
	{
		animator.SetBool("Skill1", true);

		while (true)
		{
			
			yield return new WaitUntil(() => BossAnimatorEnd("G_Attack_Special1"));

			ChangeState(AI_State.Idle);

			yield break;
		}
	}

	IEnumerator CoroutineSkill2()
	{
		animator.SetBool("Skill2", true);

		while (true)
		{
			yield return new WaitUntil(() => BossAnimatorEnd("G_Attack_Special2"));

			ChangeState(AI_State.Idle);

			yield break;
		}
	}

	//보스 애니메이션 끝났는지 확인
	bool BossAnimatorEnd(string animatorName)
	{

		if (animator.GetCurrentAnimatorStateInfo(0).IsName(animatorName))
		{
			float normalizedTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;

			if (normalizedTime >= 0.9)
			{
				return true;
			}
		}

		return false;
	}

	float BossTargetDistance(GameObject gameObject, GameObject target)
	{
		dis = Vector3.Distance(gameObject.transform.position, target.transform.position);

		return dis;
	}


}

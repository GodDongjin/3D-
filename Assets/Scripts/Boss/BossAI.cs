using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : Boss
{
	float dis;
	int index;
	string[,] animationName = new string[4, 3];

	public GameObject[] prefabs;
	public List<BoxCollider> l_BossBoxCollider = new List<BoxCollider>();
	public PlayerAnimation player;

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
		player = GameObject.Find("Player").GetComponent<PlayerAnimation>();

		animator = gameObject.GetComponent<Animator>();

		l_BossBoxCollider.Add(GameObject.Find(" R Foot").GetComponentInChildren<BoxCollider>());
		l_BossBoxCollider.Add(GameObject.Find(" R Hand").GetComponentInChildren<BoxCollider>());
		l_BossBoxCollider.Add(GameObject.Find(" L Foot").GetComponentInChildren<BoxCollider>());
		l_BossBoxCollider.Add(GameObject.Find(" L Hand").GetComponentInChildren<BoxCollider>());

		for (int i = 0; i < l_BossBoxCollider.Count; i++)
		{
			l_BossBoxCollider[i].enabled = false;
		}

		state = AI_State.Idle;
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
			case AI_State.Rigidity: IdleUpdate(); break;
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


		//Debug.Log(distance);

		HeavyHit();
		BossPlayerDistance();
	}

	public void ChangeState(AI_State nextState)
	{
		state = nextState;

		for (int i = 0; i < l_BossBoxCollider.Count; i++)
		{
			l_BossBoxCollider[i].enabled = false;
		}

		animator.SetBool("Attack1", false);
		animator.SetBool("Attack2", false);
		animator.SetBool("Skill1", false);
		animator.SetBool("Skill2", false);
		animator.SetBool("Move", false);
		animator.SetBool("HeavyHit", false);

		StopAllCoroutines();

		switch (state)
		{
			case AI_State.Idle: StartCoroutine(CoroutineIdel()); break;
			case AI_State.Move: StartCoroutine(CoroutineMove()); break;
			case AI_State.Attack1: StartCoroutine(CoroutineAttack1()); break;
			case AI_State.Attack2: StartCoroutine(CoroutineAttack2()); break;
			case AI_State.Skill1: StartCoroutine(CoroutineSkill1()); break;
			case AI_State.Skill2: StartCoroutine(CoroutineSkill2()); break;
			case AI_State.Rigidity: StartCoroutine(CoroutineHit()); break;
			case AI_State.Die: break;
		}
	}

	public void IdleUpdate()
	{

		for (int i = 0; i < l_BossBoxCollider.Count; i++)
		{
			l_BossBoxCollider[i].enabled = false;
		}

		if(distance < 8f)
		{
			//플레이어랑 보스 거리 차이 체크
			Trun();
		}
		

	}

	public void MoveUpdate()
	{
		for (int i = 0; i < l_BossBoxCollider.Count; i++)
		{
			l_BossBoxCollider[i].enabled = false;
		}

		boss.transform.position =
			Vector3.MoveTowards(boss.transform.position, player.transform.position, moveSpeed * Time.deltaTime);

		Trun();


		if (dis < 5f)
		{
			ChangeState(AI_State.Idle);
		}

		//Debug.Log(dis);
	}

	public void Attack1Update()
	{
		if (animator.GetCurrentAnimatorStateInfo(0).IsName("G_Attack1"))
		{
			ColliderOnOff(1);
			isHeavyRigidity = true;
			isLightRigidity = false;
		}

		if (animator.GetCurrentAnimatorStateInfo(0).IsName("G_Attack2"))
		{
			ColliderOnOff(3);
			isHeavyRigidity = true;
			isLightRigidity = false;
		}

		if (animator.GetCurrentAnimatorStateInfo(0).IsName("G_Attack4"))
		{
			float normalizedTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;

			if (normalizedTime <= 0.2f)
			{
				isPlayerHit = false;
			}

			if (!isPlayerHit)
			{
				for (int i = 0; i < l_BossBoxCollider.Count; i++)
				{
					l_BossBoxCollider[i].enabled = false;
				}
				l_BossBoxCollider[1].enabled = true;
				l_BossBoxCollider[3].enabled = true;
			}
			else
			{
				for (int i = 0; i < l_BossBoxCollider.Count; i++)
				{
					l_BossBoxCollider[i].enabled = false;
				}
			}

			isHeavyRigidity = true;
			isLightRigidity = false;
		}
	}

	public void Attack2Update()
	{
		if (animator.GetCurrentAnimatorStateInfo(0).IsName("G_Attack3"))
		{
			ColliderOnOff(0);
			isHeavyRigidity = true;
			isLightRigidity = false;
		}

		if (animator.GetCurrentAnimatorStateInfo(0).IsName("G_Attack5_Opp"))
		{
			ColliderOnOff(2);
			isHeavyRigidity = true;
			isLightRigidity = false;
		}

		if (animator.GetCurrentAnimatorStateInfo(0).IsName("G_Attack6"))
		{
			ColliderOnOff(3);
			isHeavyRigidity = true;
			isLightRigidity = false;
		}
	}

	public void Skill1Update()
	{
		nameOfThePrefab = prefabs[index].name;
		if (!isEffect)
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
		ColliderOnOff(1);
		isHeavyRigidity = true;
		isLightRigidity = false;
	}

	public void HeavyHit()
	{
		if(currentRigidity >= maxRigidity)
		{
			ChangeState(AI_State.Rigidity);
			//Debug.Log("경직");
			currentRigidity = 0;
		}
	}

	//코루틴 
	IEnumerator CoroutineIdel()
	{
		
		//if(distance < 10f)
		//{
			if (distance <= 3f)
			{
				int randAction = Random.Range(0, 10);

				yield return new WaitForSeconds(1f);

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

				//Debug.Log("쫒아가");
				ChangeState(state);
			}
			if (distance > 3f)
			{
				ChangeState(AI_State.Move);
				//Debug.Log("따라가");
			}
			
				
			
		//}
		//else
		//{
		//	ChangeState(AI_State.Idle);
		//}

		yield break;

	}

	IEnumerator CoroutineMove()
	{
		animator.SetBool("Move", true);

		if (distance < 3f)
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

	IEnumerator CoroutineHit()
	{
		animator.SetBool("HeavyHit", true);

		while (true)
		{
			yield return new WaitUntil(() => BossAnimatorEnd("G_HeavyHit From Front"));

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

	public void Trun()
	{

		Vector3 direction = (player.transform.position - boss.transform.position).normalized;
		Quaternion lookRotation = Quaternion.Lerp(boss.transform.rotation, Quaternion.LookRotation(direction), 3f * Time.deltaTime);
		boss.transform.rotation = lookRotation;

	}

	public void ColliderOnOff(int index)
	{
		float normalizedTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;

		if (normalizedTime <= 0.2f)
		{
			isPlayerHit = false;
		}

		if (!isPlayerHit)
		{
			for (int i = 0; i < l_BossBoxCollider.Count; i++)
			{
				l_BossBoxCollider[i].enabled = false;
			}
			l_BossBoxCollider[index].enabled = true;
		}
		else
		{
			for (int i = 0; i < l_BossBoxCollider.Count; i++)
			{
				l_BossBoxCollider[i].enabled = false;
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{

		if (other.name == "Player")
		{
			if (!isPlayerHit)
			{
				//Debug.Log("딱 한번이라메");
				StartCoroutine(OnDamege(damege, isHeavyRigidity, isLightRigidity));
				//StartCoroutine(CollrderOff());
				isPlayerHit = true;

			}

		}
	}



	IEnumerator OnDamege(float damege, bool big, bool light)
	{
		player.PlayerHpLose(damege, big, light);

		yield return new WaitForSeconds(0.5f);

	}

	public void BossPlayerDistance()
	{
		distance = Vector3.Distance(boss.transform.position, player.transform.position);
	}

	//IEnumerator CollrderOn(int index)
	//{
	//	Debug.Log("코루틴 실행");
	//	//if (isPlayerHit)
	//	//{
	//	l_BossBoxCollider[index].enabled = true;
	//	//}
	//
	//
	//	yield return null;
	//}
	//
	//IEnumerator CollrderOff()
	//{
	//	for (int i = 0; i < l_BossBoxCollider.Count; i++)
	//	{
	//		l_BossBoxCollider[index].enabled = false;
	//	}
	//
	//
	//	yield break;
	//}

}

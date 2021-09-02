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
	public SphereCollider skiileCollider;

	public PlayerAnimation player;
	public Vector3[] newVector;

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


		boss = GameObject.Find("Boss");
		player = GameObject.Find("Player").GetComponent<PlayerAnimation>();

		animator = gameObject.GetComponent<Animator>();

		l_BossBoxCollider.Add(GameObject.Find(" R Foot").GetComponentInChildren<BoxCollider>());
		l_BossBoxCollider.Add(GameObject.Find(" R Hand").GetComponentInChildren<BoxCollider>());
		l_BossBoxCollider.Add(GameObject.Find(" L Foot").GetComponentInChildren<BoxCollider>());
		l_BossBoxCollider.Add(GameObject.Find(" L Hand").GetComponentInChildren<BoxCollider>());
		l_BossBoxCollider.Add(GameObject.Find("AttckCollider").GetComponentInChildren<BoxCollider>());

		skiileCollider = GameObject.Find("SkilleColider").GetComponent<SphereCollider>();

		for (int i = 0; i < l_BossBoxCollider.Count; i++)
		{
			l_BossBoxCollider[i].enabled = false;
		}

		isDie = false;

		state = AI_State.Idle;
		ChangeState(state);

	}

	// Update is called once per frame
	void Update()
	{
		if(state != AI_State.Die && GameManager.instance.g_playerInfo._PlayerInfomation.isDie == false)
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
				case AI_State.Die: break;
			}



			if (Input.GetKeyDown(KeyCode.Alpha6))
			{
				ChangeState(AI_State.Attack1);
			}
			
			if (Input.GetKeyDown(KeyCode.Alpha7))
			{
				ChangeState(AI_State.Attack2);
			}
			if (Input.GetKeyDown(KeyCode.Alpha8))
			{
				ChangeState(AI_State.Skill1);
			}
			
			if (Input.GetKeyDown(KeyCode.Alpha9))
			{
				ChangeState(AI_State.Skill2);
			}
			if (Input.GetKeyDown(KeyCode.T))
			{
				currentHp = -1;
				//currentRigidity = 0;
			}

			HeavyHit();
			BossPlayerDistance();

			if (currentHp < 0)
			{
				if (isDie == false)
				{
					ChangeState(AI_State.Die);
				}

			}
		}

		
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
		animator.SetBool("Die", false);

		isPlayerHit = false;
		StopAllCoroutines();

		//isPlayerHit = false;

		switch (state)
		{
			case AI_State.Idle: StartCoroutine(CoroutineIdel()); break;
			case AI_State.Move: StartCoroutine(CoroutineMove()); break;
			case AI_State.Attack1: StartCoroutine(CoroutineAttack1()); break;
			case AI_State.Attack2: StartCoroutine(CoroutineAttack2()); break;
			case AI_State.Skill1: StartCoroutine(CoroutineSkill1()); break;
			case AI_State.Skill2: StartCoroutine(CoroutineSkill2()); break;
			case AI_State.Rigidity: StartCoroutine(CoroutineHit()); break;
			case AI_State.Die: StartCoroutine(CoroutineDie()); break;
		}
	}

	public void IdleUpdate()
	{

		if (distance < 8f)
		{
			//플레이어랑 보스 거리 차이 체크
			Trun();
		}


	}

	public void MoveUpdate()
	{

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
		}

		if (animator.GetCurrentAnimatorStateInfo(0).IsName("G_Attack2"))
		{
			ColliderOnOff(3);
		}

		if (animator.GetCurrentAnimatorStateInfo(0).IsName("G_Attack4"))
		{

			ColliderOnOff(4);
		}

	}

	public void Attack2Update()
	{
		if (animator.GetCurrentAnimatorStateInfo(0).IsName("G_Attack3"))
		{
			ColliderOnOff(0);
		}

		if (animator.GetCurrentAnimatorStateInfo(0).IsName("G_Attack5_Opp"))
		{
			ColliderOnOff(2);
		}

		if (animator.GetCurrentAnimatorStateInfo(0).IsName("G_Attack6"))
		{
			ColliderOnOff(3);
		}


	}

	public void Skill1Update()
	{
		if (!isEffect)
		{
			if (animator.GetCurrentAnimatorStateInfo(0).IsName("G_Attack_Special1"))
			{
				float normalizedTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;

				if (normalizedTime >= 0.4)
				{
					Vector3 vector3 = boss.transform.position + transform.forward * 2;
					Instantiate(prefabs[0], vector3, Quaternion.identity);
					isEffect = true;
				}
			}
		}



	}

	public void Skill2Update()
	{
		if (!isEffect)
		{
			if (animator.GetCurrentAnimatorStateInfo(0).IsName("G_Attack_Special2"))
			{
				float normalizedTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;

				if (normalizedTime >= 0.7)
				{
					int random = Random.Range(1, 15);

					for(int i = 0; i < random; i++)
					{
						Instantiate(prefabs[1], Return_RandomPosition(), Quaternion.identity);
					}
					
					isEffect = true;
				}
			}
		}
	}
	public Vector3 Return_RandomPosition()
	{
		Vector3 originPotion = gameObject.transform.position;//skiileCollider.transform.position;

		float range_x = gameObject.transform.position.x;
		float range_z = gameObject.transform.position.z;

		range_x = Random.Range(((range_x + 14) / 2) * -1, range_x + 14);
		range_z = Random.Range(((range_z + 14) / 2) * -1, range_z + 14);

		Vector3 randomPostion = new Vector3(range_x, 0, range_z);

		Vector3 respqwnPostion = originPotion + randomPostion;
		return respqwnPostion;

	}

	public void HeavyHit()
	{
		if (currentRigidity <= 0)
		{
			ChangeState(AI_State.Rigidity);
			currentRigidity = maxRigidity;
			//Debug.Log("경직");
		}
	}

	//코루틴 
	IEnumerator CoroutineIdel()
	{

		if(distance < 10f)
		{
			if (distance <= 3f)
			{
				int rand = Random.Range(0, 100);
				
				yield return new WaitForSeconds(1f);
				
				if(currentHp > maxHp / 2)
				{
					if (rand < 40)
					{
						ChangeState(AI_State.Attack1);
				
					}
					else if (rand >= 40 && rand < 70)
					{
						ChangeState(AI_State.Attack2);
				
					}
				
					else if (rand >= 70 && rand < 90)
					{
						ChangeState(AI_State.Skill1);
					}
					else if (rand >= 90 && rand <= 100)
					{
						ChangeState(AI_State.Skill2);
					}
				
				}
				if (currentHp <= maxHp / 2)
				{
					if (rand < 20)
					{
						ChangeState(AI_State.Attack1);
				
					}
					else if (rand >= 20 && rand < 40)
					{
						ChangeState(AI_State.Attack2);
				
					}
				
					else if (rand >= 40 && rand < 70)
					{
						ChangeState(AI_State.Skill1);
					}
					else if (rand >= 70 && rand <= 100)
					{
						ChangeState(AI_State.Skill2);
					}
				
				}
			}
			if (distance > 3f)
			{
				ChangeState(AI_State.Move);
			}

		}
		else
		{
			ChangeState(AI_State.Idle);
		}

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
			yield return new WaitForSeconds(2f);

			ChangeState(AI_State.Idle);

			yield break;
		}
	}
	IEnumerator CoroutineDie()
	{
		animator.SetBool("Die", true);

		while (true)
		{
			yield return new WaitUntil(() => BossAnimatorEnd("G_Die3"));

			player.UseGold(-glod);
			isDie = true;

			yield break;
		}
	}


	//보스 애니메이션 끝났는지 확인
	bool BossAnimatorEnd(string animatorName)
	{
		if (animator.GetCurrentAnimatorStateInfo(0).IsName(animatorName))
		{
			float normalizedTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;



			if (normalizedTime >= 0.8)
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
		if (!isPlayerHit)
		{
			for (int i = 0; i < l_BossBoxCollider.Count; i++)
			{
				l_BossBoxCollider[i].enabled = false;
			}
			l_BossBoxCollider[index].enabled = true;
		}
		else if (isPlayerHit)
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
			isPlayerHit = true;
			StartCoroutine(OnDamege(damege));
		}
	}



	IEnumerator OnDamege(float damege)
	{
		player.PlayerHpLose(damege);

		yield return new WaitForSeconds(1f);

		isPlayerHit = false;
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

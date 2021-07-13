//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class BossSkill1 : MonoBehaviour
//{
//	public GameObject Effect;
//	PlayerInfo playerInfo;
//	public ParticleSystem particle;

//	Animator bossAni;

//	bool isTrigger = false;

//	//ParticleSystem.

//	private void Start()
//	{
//		bossAni = GameObject.Find("Boss").GetComponent<Animator>();
//		playerInfo = GameObject.Find("Player").GetComponent<PlayerInfo>();
//		particle = Effect.GetComponentInChildren<ParticleSystem>();

//	}

//	private void Update()
//	{
//		if(particle)
//		{
//			if (!particle.IsAlive())
//			{
//				isTrigger = false;	
//				Destroy(Effect);
//			}
//		}
//	}

//	private void OnTriggerExit(Collider other)
//	{
//		if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
//		{
//			StopAllCoroutines();
//		}
//	}
//	private void OnTriggerEnter(Collider other)
//	{
//		Debug.Log("파티클 충돌");
//		if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
//		{
//			if(!isTrigger)
//			{
//				isTrigger = true;
//				StartCoroutine(BossSkillAttack());
//			}
//			if(isTrigger)
//			{
//				StartCoroutine(BossSkillContinuousDamage());
//			}
			
//		}
//	}

//	private void OnTriggerStay(Collider other)
//	{
//		if(!other.gameObject)
//		{
			
//		}
//	}

	
	

//	//보스 스킬 첫 공격 대미지
//	IEnumerator BossSkillAttack()
//	{
//		playerInfo.PlayerHpLose(20f);
//		Debug.Log(20f + "를 입었다");

//		yield return new WaitForSeconds(0.5f);

//		StartCoroutine(BossSkillContinuousDamage());

//		yield break;
//	}

//	//보스 스킬 장판 지속딜
//	IEnumerator BossSkillContinuousDamage()
//	{
//		while(true)
//		{
//			playerInfo.Rigidity(true, false);
//			playerInfo.PlayerHpLose(5f);
//			Debug.Log(10f + "를 입었다");

//			yield return new WaitForSeconds(0.5f);
//		}
//	}
//}

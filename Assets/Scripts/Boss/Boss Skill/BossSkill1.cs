using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEffect : MonoBehaviour
{
	public GameObject Effect;
	PlayerInfo playerInfo;
	public ParticleSystem particle;
	Collider collider;
	BoxCollider bossBoxCollider;

	Animator bossAni;

	bool isTrigger = false;

	//ParticleSystem.

	private void Start()
	{
		bossAni = GameObject.Find("Boss").GetComponent<Animator>();
		playerInfo = GameObject.Find("Player").GetComponent<PlayerInfo>();
		particle = Effect.GetComponentInChildren<ParticleSystem>();
		collider = Effect.GetComponent<Collider>();
		//bossBoxCollider
	}

	private void Update()
	{
		if(particle)
		{
			if (!particle.IsAlive())
			{
				isTrigger = false;	
				Destroy(Effect);
			}
		}
	}

	//private void OnTriggerStay(Collider other)
	//{
	//	if (other.gameObject.name != "Player")
	//	{
	//		StopAllCoroutines();
	//	}
	//}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			StopAllCoroutines();
		}
	}
	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("��ƼŬ �浹");
		if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			if(!isTrigger)
			{
				StartCoroutine(BossSkillAttack());
				isTrigger = true;
			}
			if(isTrigger)
			{
				StartCoroutine(BossSkillContinuousDamage());
			}
			
		}
	}

	//���� ��ų ù ���� �����
	IEnumerator BossSkillAttack()
	{
		playerInfo.PlayerHpLose(20f, true, false);
		Debug.Log(20f + "�� �Ծ���");

		yield return new WaitForSeconds(0.5f);

		StartCoroutine(BossSkillContinuousDamage());

		yield break;
	}

	//���� ��ų ���� ���ӵ�
	IEnumerator BossSkillContinuousDamage()
	{
		while(true)
		{
			playerInfo.PlayerHpLose(5f, true, false);
			Debug.Log(10f + "�� �Ծ���");

			yield return new WaitForSeconds(0.5f);
		}
	}
}

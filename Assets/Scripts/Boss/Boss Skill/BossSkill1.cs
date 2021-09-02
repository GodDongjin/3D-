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

	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			StopCoroutine(BossSkillAttack());
			StopCoroutine(BossSkillContinuousDamage());
		}
	}
	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("��ƼŬ �浹");
		if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			if (!isTrigger)
			{
				StartCoroutine(BossSkillAttack());
				StartCoroutine(SkilleDestory());
				isTrigger = true;
			}
			if (isTrigger)
			{
				StartCoroutine(BossSkillContinuousDamage());
			}
		}
	}

	//���� ��ų ù ���� �����
	IEnumerator BossSkillAttack()
	{
		playerInfo.PlayerHpLose(20f);
		Debug.Log(20f + "�� �Ծ���");

		yield return new WaitForSeconds(0.5f);

		StartCoroutine(BossSkillContinuousDamage());

		yield break;
	}

	//���� ��ų ���� ���ӵ�
	IEnumerator BossSkillContinuousDamage()
	{
		while (true)
		{
			playerInfo.PlayerHpLose(5f);
			Debug.Log(10f + "�� �Ծ���");

			yield return new WaitForSeconds(0.5f);
		}
	}

	IEnumerator SkilleDestory()
	{
		yield return new WaitForSeconds(2f);

		Destroy(gameObject);
	}
}

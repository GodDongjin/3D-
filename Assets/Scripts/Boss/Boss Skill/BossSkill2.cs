using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill2 : MonoBehaviour
{
	PlayerInfo playerInfo;
	//Collider collider;
	BoxCollider bossBoxCollider;

	Animator bossAni;

	float maxTime = 3f;
	float currentTime = 0f;

	bool isTrigger = false;

	// Start is called before the first frame update
	void Start()
	{
		bossAni = GameObject.Find("Boss").GetComponent<Animator>();
		playerInfo = GameObject.Find("Player").GetComponent<PlayerInfo>();
		bossBoxCollider = gameObject.GetComponentInChildren<BoxCollider>();
	}

	// Update is called once per frame
	void Update()
	{
		currentTime += Time.deltaTime;

		if(currentTime >= maxTime)
		{
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			StartCoroutine(BossSkillAttack());
		}
	}

	IEnumerator BossSkillAttack()
	{
		bossBoxCollider.enabled = false;

		yield return new WaitForSeconds(1f);
		playerInfo.PlayerHpLose(0.1f);

		

		yield break;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttack : Player
{
	BossInfo boss;
	BoxCollider boxCollider;
	//SkiilePaticles skilles;

	// Start is called before the first frame update
	void Start()
	{
		boss = GameObject.Find("Boss").GetComponent<BossInfo>();
		boxCollider = GameObject.Find("Player").GetComponentInChildren<BoxCollider>();
		maxSkille1Cooldown = 3;
		maxSkille2Cooldown = 5;
		currentSkille1Cooldown = maxSkille1Cooldown;
		currentSkille2Cooldown = maxSkille2Cooldown;

		//ps = GetComponent<ParticleSystem>();
	}

	// Update is called once per frame
	void Update()
	{
		if (state != Player_State.Die || GameManager.instance.g_Boss.isDie == false)
		{
			if (Input.GetMouseButtonDown(0))
			{
				if (state != Player_State.Attack && attackCombo == 0)
				{
					damege = 10;
					rigidity = 10f;

					MouseRotate();
					ChangeState(Player_State.Attack);

				}
			}

			if (currentMp > 0)
			{
				if (Input.GetKeyDown(KeyCode.Q))
				{
					if (state != Player_State.Skille1 && isSkille1Cooldown == false)
					{
						skilleDamege = damege + 50;
						rigidity = 40f;
						useMp = 10f;
						MouseRotate();
						UseMp(useMp);
						maxSkille1Cooldown = 3f;
						isSkille1Cooldown = true;
						ChangeState(Player_State.Skille1);
					}
				}

				if (Input.GetKeyDown(KeyCode.E))
				{
					if (state != Player_State.Skille2 && isSkille2Cooldown == false)
					{
						skilleDamege = damege + 100;
						rigidity = 80f;
						useMp = 20f;
						MouseRotate();
						UseMp(useMp);
						maxSkille2Cooldown = 5f;
						isSkille2Cooldown = true;
						ChangeState(Player_State.Skille2);
					}
				}
			}

			if (isAttckCollider)
			{
				boxCollider.enabled = true;
			}
			else if (!isAttckCollider)
			{
				boxCollider.enabled = false;
			}
		}
	}

	//ParticleSystemTriggerEventType

	private void OnTriggerEnter(Collider other)
	{
		
		if (other.name == "Boss")
		{
			Vector3 bossPos = GameManager.instance.g_Boss.transform.position;
			Vector3 hitPrefabsPos = new Vector3(bossPos.x, bossPos.y + 3, bossPos.z);
			Instantiate(hitPrefabs, hitPrefabsPos, Quaternion.identity);

			//boss.BossHpLose(damege, rigidity);

			
			GameManager.instance.g_Boss.BossHpLose(damege, rigidity);

		}
		
	}



}

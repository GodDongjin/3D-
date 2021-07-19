using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkiilePaticles : Player
{
	BossAI boss;

	private void Start()
	{
		boss = GameObject.Find("Boss").GetComponent<BossAI>();
	}
	private void OnTriggerEnter(Collider other)
	{
		if(other.name == "Boss")
		{
			boss.BossHpLose(skilleDamege, rigidity);
		}
	}

}

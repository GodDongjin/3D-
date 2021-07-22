using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkiilePaticles : Player
{
	BossAI boss;

	public EffectInfo[] Effects;
	[System.Serializable]

	public class EffectInfo
	{
		public GameObject Effect;
		public Transform StartPositionRotation;
	}
		//public List<>

		private void Start()
	{
		boss = GameObject.Find("Boss").GetComponent<BossAI>();
	}

	public void InstantiateEffect(int EffectNumber)
	{
		if (Effects == null || Effects.Length <= EffectNumber)
		{
			Debug.LogError("Incorrect effect number or effect is null");
		}

		var instance = Instantiate(Effects[EffectNumber].Effect, Effects[EffectNumber].StartPositionRotation.position, Effects[EffectNumber].StartPositionRotation.rotation);

		Destroy(instance, 0.6f);
	}

	public void EffectDestory(int EffectNumber)
	{
		Destroy(this);
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.name == "Boss")
		{
			boss.BossHpLose(skilleDamege, rigidity);
		}
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEffect : MonoBehaviour
{
	public GameObject Effect;

	Animator bossAni;

	ParticleSystem.

	private void Start()
	{
		bossAni = GameObject.Find("Boss").GetComponent<Animator>();
	}

	private void Update()
	{
		if (bossAni.GetCurrentAnimatorStateInfo(0).IsName("G_Attack_Special1"))
		{
			float normalizedTime = bossAni.GetCurrentAnimatorStateInfo(0).normalizedTime;

			if (normalizedTime >= 0.9)
			{
				GameManager.instance.g_Boss.isEffect = false;
				Destroy(Effect);
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossInfo : Boss
{
	private void Awake()
	{
		currentHp = maxHp;
	}

	private void Update()
	{
		Debug.Log(currentHp);
	}

}

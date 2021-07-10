using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : Player
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

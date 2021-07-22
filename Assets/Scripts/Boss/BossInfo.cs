using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossInfo : Boss
{
	public struct BossInfomation
	{
		public float maxHp;
		public float currentHp;
		public float maxRigidity;
		public float currentRigidity;
		public float distance;

		public Transform startPos;

	
	}

	public BossInfomation _BossInfomation;

	private void Awake()
	{
		currentHp = maxHp;

		_BossInfomation.maxHp = maxHp;
		_BossInfomation.currentHp = currentHp;
		_BossInfomation.distance = distance;
		_BossInfomation.maxRigidity = maxRigidity;
		_BossInfomation.currentRigidity = maxRigidity;

		_BossInfomation.startPos = startPos;
	}

	private void Update()
	{
		_BossInfomation.maxHp = maxHp;
		_BossInfomation.currentHp = currentHp;
		_BossInfomation.maxRigidity = maxRigidity;
		_BossInfomation.currentRigidity = currentRigidity;
		//Debug.Log("sfjks " + _BossInfomation.currentHp);
	}

}

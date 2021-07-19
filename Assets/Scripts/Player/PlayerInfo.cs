using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : Player
{

	public struct PlayerInfomation
	{
		public float maxHp;
		public float currentHp;
		public float maxMp;
		public float currentMp;
		public float damege;
		public float maxExperience;
		public float currentExperience;
	}

	public PlayerInfomation _PlayerInfomation;

	//private void Awake()
	//{
	//	currentHp = maxHp;
	//
	//	_PlayerInfomation.maxHp = maxHp;
	//	_PlayerInfomation.currentHp = currentHp;
	//	_PlayerInfomation.distance = distance;
	//
	//	_PlayerInfomation.startPos = startPos;
	//}

	//private void Update()
	//{
	//	_BossInfomation.maxHp = maxHp;
	//	_BossInfomation.currentHp = currentHp;
	//	Debug.Log("sfjks " + _BossInfomation.currentHp);
	//}

	//public float _maxHp;
	//public float _currentHp;
	//public float _maxMp;
	//public float _currentMp;
	//public float _damege;
	//public float _maxExperience;
	//public float _currentExperience;

	private void Awake()
	{
		lv = 2;
		SetPlayerInfo(lv);

		currentHp = maxHp;
		
		_PlayerInfomation.maxHp = maxHp;
		_PlayerInfomation.currentHp = maxHp;
		_PlayerInfomation.maxMp = maxMp;
		_PlayerInfomation.currentMp = maxMp;
		_PlayerInfomation.damege = damege;
		_PlayerInfomation.maxExperience = maxExperience;
		_PlayerInfomation.currentExperience = 0;
	}

	private void Update()
	{
		_PlayerInfomation.maxHp = maxHp;
		_PlayerInfomation.currentHp = currentHp;
		_PlayerInfomation.maxMp = maxMp;
		_PlayerInfomation.currentMp = currentMp;
		_PlayerInfomation.damege = damege;
		_PlayerInfomation.maxExperience = maxExperience;
		_PlayerInfomation.currentExperience = currentExperience;

		//Debug.Log(currentHp);
	}


	public void SetPlayerInfo(int lv)
	{
		lv = lv - 1;
		maxHp = DataManager.instance.GetPlayerInfo(lv)._MaxHp;
		maxMp = DataManager.instance.GetPlayerInfo(lv)._MaxMp;
		damege = DataManager.instance.GetPlayerInfo(lv)._Damage;
		maxExperience = DataManager.instance.GetPlayerInfo(lv)._MaxExperience;




		//Debug.Log("maxHp " + maxHp);
		//Debug.Log("maxMp " + maxMp);
		//Debug.Log("damege " + damege);
		//Debug.Log("maxExperience " + maxExperience);
	}
	
}

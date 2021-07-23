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
		public float moveSpeed;
		public float maxExperience;
		public float currentExperience;
		public float maxSkille1Cooldown;
		public float maxSkille2Cooldown;
		public float currentSkille1Cooldown;
		public float currentSkille2Cooldown;
		public float currentGold;
		public bool isCooldown1;
		public bool isCooldown2;

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

	private void Start()
	{
		SetPlayerInfo();

		currentHp = maxHp;
		currentMp = maxHp;

		_PlayerInfomation.maxHp = maxHp;
		_PlayerInfomation.currentHp = maxHp;
		_PlayerInfomation.maxMp = maxMp;
		_PlayerInfomation.currentMp = maxMp;
		_PlayerInfomation.damege = damege;
		_PlayerInfomation.moveSpeed = moveSpeed;
		_PlayerInfomation.maxExperience = maxExperience;
		_PlayerInfomation.currentExperience = 0;
		_PlayerInfomation.maxSkille1Cooldown = maxSkille1Cooldown;
		_PlayerInfomation.maxSkille2Cooldown= maxSkille2Cooldown;
		_PlayerInfomation.currentSkille1Cooldown = currentSkille1Cooldown;
		_PlayerInfomation.currentSkille2Cooldown = currentSkille2Cooldown;
		_PlayerInfomation.isCooldown1 = isSkille1Cooldown;
		_PlayerInfomation.isCooldown2 = isSkille2Cooldown;
		_PlayerInfomation.currentGold = gold;
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
		_PlayerInfomation.maxSkille1Cooldown = maxSkille1Cooldown;
		_PlayerInfomation.maxSkille2Cooldown = maxSkille2Cooldown;
		_PlayerInfomation.currentSkille1Cooldown = currentSkille1Cooldown;
		_PlayerInfomation.currentSkille2Cooldown = currentSkille2Cooldown;
		_PlayerInfomation.isCooldown1 = isSkille1Cooldown;
		_PlayerInfomation.isCooldown2 = isSkille2Cooldown;
		_PlayerInfomation.currentGold = gold;

		//Debug.Log(currentHp);
	}


	public void SetPlayerInfo()
	{

		maxHp = DataManager.instance.GetPlayerInfo()._MaxHp;
		maxMp = DataManager.instance.GetPlayerInfo()._MaxMp;
		damege = DataManager.instance.GetPlayerInfo()._Damage;
		moveSpeed = DataManager.instance.GetPlayerInfo()._MoveSpeed;
		gold = DataManager.instance.GetPlayerInfo()._Gold; ;
		Debug.Log("moveSpeed " + moveSpeed);

	}


	
}

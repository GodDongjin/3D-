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
		public float maxItem1Cooldown;
		public float maxItem2Cooldown;
		public float currentSkille1Cooldown;
		public float currentSkille2Cooldown;
		public float currentItem1Cooldown;
		public float currentItem2Cooldown;
		public float currentGold;
		public bool isCooldown1;
		public bool isCooldown2;
		public bool isItem1Cooldown;
		public bool isItem2Cooldown;
		public bool isDie;
		
	}

	public PlayerInfomation _PlayerInfomation;

	

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
		_PlayerInfomation.maxItem1Cooldown= maxItem1Cooldown;
		_PlayerInfomation.maxItem2Cooldown= maxItem2Cooldown;
		_PlayerInfomation.currentSkille1Cooldown = currentSkille1Cooldown;
		_PlayerInfomation.currentSkille2Cooldown = currentSkille2Cooldown;
		_PlayerInfomation.currentItem1Cooldown = currentItem1Cooldown;
		_PlayerInfomation.currentItem2Cooldown = currentItem2Cooldown;

		_PlayerInfomation.isCooldown1 = isSkille1Cooldown;
		_PlayerInfomation.isCooldown2 = isSkille2Cooldown;
		_PlayerInfomation.isItem1Cooldown = isItem1Cooldown;
		_PlayerInfomation.isItem2Cooldown = isItem2Cooldown;
		_PlayerInfomation.isDie = isDie;

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
		_PlayerInfomation.maxItem1Cooldown = maxItem1Cooldown;
		_PlayerInfomation.maxItem2Cooldown = maxItem2Cooldown;
		_PlayerInfomation.currentSkille1Cooldown = currentSkille1Cooldown;
		_PlayerInfomation.currentSkille2Cooldown = currentSkille2Cooldown;
		_PlayerInfomation.currentItem1Cooldown = currentItem1Cooldown;
		_PlayerInfomation.currentItem2Cooldown = currentItem2Cooldown;
		_PlayerInfomation.isCooldown1 = isSkille1Cooldown;
		_PlayerInfomation.isCooldown2 = isSkille2Cooldown;
		_PlayerInfomation.isItem1Cooldown = isItem1Cooldown;
		_PlayerInfomation.isItem2Cooldown = isItem2Cooldown;
		_PlayerInfomation.isDie = isDie;
		_PlayerInfomation.currentGold = gold;

		if (state != Player_State.Die || GameManager.instance.g_Boss.isDie == false)
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				if (isItem1Cooldown == false)
				{
					if (GameManager.instance.ingameInventory.Slots[0].GetItem().itmeInfo.itemName == "hpPotion")
					{
						UseHp(-GameManager.instance.ingameInventory.Slots[0].GetItem().itmeInfo.itemValue);
						maxItem1Cooldown = 3;
						isItem1Cooldown = true;
						GameManager.instance.ingameInventory.Slots[0].SetSlotCount(-1);
					}
					if (GameManager.instance.ingameInventory.Slots[0].GetItem().itmeInfo.itemName == "mpPotion")
					{
						UseMp(-GameManager.instance.ingameInventory.Slots[0].GetItem().itmeInfo.itemValue);
						maxItem1Cooldown = 3;
						isItem1Cooldown = true;
						GameManager.instance.ingameInventory.Slots[0].SetSlotCount(-1);
					}
					if (GameManager.instance.ingameInventory.Slots[0].GetItem().itmeInfo.itemName == "attckPotion")
					{
						UseAttack(-GameManager.instance.ingameInventory.Slots[0].GetItem().itmeInfo.itemValue);
						maxItem1Cooldown = 8;
						maxAttckItemTiem = 5;
						isAttckItem = true;
						isItem1Cooldown = true;
						GameManager.instance.ingameInventory.Slots[0].SetSlotCount(-1);
					}
					if (GameManager.instance.ingameInventory.Slots[0].GetItem().itmeInfo.itemName == "speedPotion")
					{
						UseMoveSpeed(-GameManager.instance.ingameInventory.Slots[0].GetItem().itmeInfo.itemValue);
						maxItem1Cooldown = 8;
						maxMoveSpeedItemTiem = 3;
						isMoveSpeedItem = true;
						isItem1Cooldown = true;
						GameManager.instance.ingameInventory.Slots[0].SetSlotCount(-1);
					}
					if (GameManager.instance.ingameInventory.Slots[0].GetItem().itmeInfo.itemName == "coolDownPotion")
					{
						UseCollDown(-GameManager.instance.ingameInventory.Slots[0].GetItem().itmeInfo.itemValue);
						maxItem1Cooldown = 12;
						isItem1Cooldown = true;
						GameManager.instance.ingameInventory.Slots[0].SetSlotCount(-1);
					}
				}

			}

			if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				if (isItem2Cooldown == false)
				{
					if (GameManager.instance.ingameInventory.Slots[1].GetItem().itmeInfo.itemName == "hpPotion")
					{
						UseHp(-GameManager.instance.ingameInventory.Slots[1].GetItem().itmeInfo.itemValue);
						maxItem2Cooldown = 3;
						isItem2Cooldown = true;
						GameManager.instance.ingameInventory.Slots[1].SetSlotCount(-1);
					}
					if (GameManager.instance.ingameInventory.Slots[1].GetItem().itmeInfo.itemName == "mpPotion")
					{
						UseMp(-GameManager.instance.ingameInventory.Slots[1].GetItem().itmeInfo.itemValue);
						maxItem2Cooldown = 3;
						isItem2Cooldown = true;
						GameManager.instance.ingameInventory.Slots[1].SetSlotCount(-1);
					}
					if (GameManager.instance.ingameInventory.Slots[1].GetItem().itmeInfo.itemName == "attckPotion")
					{
						UseAttack(-GameManager.instance.ingameInventory.Slots[1].GetItem().itmeInfo.itemValue);
						maxItem2Cooldown = 8;
						maxAttckItemTiem = 5;
						isAttckItem = true;
						isItem2Cooldown = true;
						GameManager.instance.ingameInventory.Slots[1].SetSlotCount(-1);
					}
					if (GameManager.instance.ingameInventory.Slots[1].GetItem().itmeInfo.itemName == "speedPotion")
					{
						UseMoveSpeed(-GameManager.instance.ingameInventory.Slots[1].GetItem().itmeInfo.itemValue);
						maxItem2Cooldown = 8;
						maxMoveSpeedItemTiem = 3;
						isMoveSpeedItem = true;
						isItem2Cooldown = true;
						GameManager.instance.ingameInventory.Slots[1].SetSlotCount(-1);
					}
					if (GameManager.instance.ingameInventory.Slots[1].GetItem().itmeInfo.itemName == "coolDownPotion")
					{
						UseCollDown(-GameManager.instance.ingameInventory.Slots[1].GetItem().itmeInfo.itemValue);
						maxItem2Cooldown = 12;
						isItem2Cooldown = true;
						GameManager.instance.ingameInventory.Slots[1].SetSlotCount(-1);
					}
				}
			}

			//if (currentHp <= 0)
			//{
			//	state = Player_State.Die;
			//	ChangeState(state);
			//}
			//
			//if (GameManager.instance.g_Boss.isDie)
			//{
			//	ChangeState(Player_State.Idle);
			//}
		}
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

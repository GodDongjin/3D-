using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDB
{
	public int id;
	public int value;
	public int buyGold;
	public int sellGold;
	public string name;
	public string imageName;
	public string type;

}

public class PlayerDB
{
	public float _MaxHp;
	public float _MaxMp;
	public float _Damage;
	public float _MoveSpeed;
	public float _Gold;
}

public class EquipmentInventory
{
	public int equipmentId;
}

public class StuffInventory
{
	public int stuffId;
	public int stuffCount;
}

public class DataFileName
{
	public string _ItemData = "ItemData";
	public string _PlayerData = "PlayerInfoData";
	public string _equipmentInvenData = "EquipmentInvenData";
	public string _stuffInvenData = "stuffInvenData";
	//public string _ItemData = "ItemData";
	//public string _ItemData = "ItemData";
}

public class DataBase : MonoBehaviour
{
	//public string m_strCSVFileName = string.Empty;

	public DataFileName dataFileName = new DataFileName();

	public List<ItemDB> items = new List<ItemDB>();
	public PlayerDB player = new PlayerDB();
	public List<EquipmentInventory> equipmentInven = new List<EquipmentInventory>();
	public List<StuffInventory> stuffInven = new List<StuffInventory>();

	private void Awake()
	{
		List<Dictionary<string, object>> m_dictionaryData = CSVReader.Read(dataFileName._ItemData);

		for (int i = 0; i < m_dictionaryData.Count; i++)
		{
			items.Add(new ItemDB());

			items[i].id = int.Parse((m_dictionaryData[i]["id"].ToString()));
			items[i].name = m_dictionaryData[i]["name"].ToString();
			items[i].imageName = m_dictionaryData[i]["image"].ToString();
			items[i].type = m_dictionaryData[i]["itemType"].ToString();
			items[i].value = int.Parse((m_dictionaryData[i]["value"].ToString()));
			items[i].buyGold = int.Parse((m_dictionaryData[i]["buyGold"].ToString()));
			items[i].sellGold = int.Parse((m_dictionaryData[i]["sellGold"].ToString()));


		}

		m_dictionaryData.Clear();

		m_dictionaryData = CSVReader.Read(dataFileName._PlayerData);

		for (int i = 0; i < m_dictionaryData.Count; i++)
		{
			
			player._MaxHp = float.Parse((m_dictionaryData[i]["maxHp"].ToString()));
			player._MaxMp = float.Parse((m_dictionaryData[i]["maxMp"].ToString()));
			player._MoveSpeed = float.Parse((m_dictionaryData[i]["moveSpeed"].ToString()));
			player._Damage = float.Parse((m_dictionaryData[i]["damege"].ToString()));
			player._Gold = float.Parse((m_dictionaryData[i]["gold"].ToString()));


		}

		m_dictionaryData.Clear();

		m_dictionaryData = CSVReader.Read(dataFileName._equipmentInvenData);

		for (int i = 0; i < m_dictionaryData.Count; i++)
		{
			equipmentInven.Add(new EquipmentInventory());

			equipmentInven[i].equipmentId = int.Parse((m_dictionaryData[i]["EquipmentId"].ToString()));
			Debug.Log("왜 안되죠? " + equipmentInven[i].equipmentId);
		}

		m_dictionaryData.Clear();

		m_dictionaryData = CSVReader.Read(dataFileName._stuffInvenData);

		for (int i = 0; i < m_dictionaryData.Count; i++)
		{
			stuffInven.Add(new StuffInventory());

			stuffInven[i].stuffId = int.Parse((m_dictionaryData[i]["StuffId"].ToString()));
			stuffInven[i].stuffCount = int.Parse((m_dictionaryData[i]["StuffCount"].ToString()));

		}


	}

	public void SaveData()
	{
		//using (var writer = new CsvFileWriter("Assets/Resources/PlayerInfo.csv"))
		//{
		//	List<string> columns = new List<string>() { "StuffId", "StuffCount" };// making Index Row
		//	writer.WriteRow(columns);
		//	columns.Clear();
		//
		//	columns.Add(info.Level.ToString()); // Level
		//	columns.Add(info.HP.ToString());  // HP
		//	columns.Add(info.MP.ToString()); // MP
		//	columns.Add(info.ATK.ToString()); // ATK
		//	columns.Add(info.SPEED.ToString()); // SPEED
		//	columns.Add(inventory.Gold.ToString()); // GOLD
		//	columns.Add(info.SP.ToString()); // SP
		//	columns.Add(info.SP_FirePunch.ToString()); // SP_FirePunch
		//	columns.Add(info.SP_EnergyBall.ToString()); // SP_EnergyBall
		//	columns.Add(info.SP_Meteor.ToString()); // SP_Meteor
		//	columns.Add(info.SP_Blizard.ToString()); // SP_Blizard
		//	columns.Add(info.SP_Shild.ToString()); // SP_Shild
		//	columns.Add(equip.slot[0].itemID.ToString()); // Equip_Head
		//	columns.Add(equip.slot[3].itemID.ToString()); // Equip_Foot
		//	columns.Add(equip.slot[1].itemID.ToString()); // Equip_Staff
		//	columns.Add(equip.slot[2].itemID.ToString()); // Equip_Body
		//	columns.Add(inventory.potionSlot.GetComponent<UI_Inventory_Slot>().itemID.ToString()); // PotionSlot
		//	string tempInventory = "";
		//	for (int i = 0; i < inventory.slot.Length; i++)
		//	{
		//		tempInventory += inventory.slot[i].itemID.ToString();
		//		if (i < inventory.slot.Length - 1) tempInventory += '|';
		//	}
		//	columns.Add(tempInventory);
		//	string tempItemCount = "";
		//	for (int i = 0; i < inventory.slot.Length; i++)
		//	{
		//		tempItemCount += inventory.slot[i].itemCount.ToString();
		//		if (i < inventory.slot.Length - 1) tempItemCount += '|';
		//	}
		//	columns.Add(tempItemCount);
		//	columns.Add(info.Exp.ToString()); // EXP
		//
		//
		//	writer.WriteRow(columns);
		//}
	}


}

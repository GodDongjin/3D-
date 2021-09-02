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
	public int itemCount;

}

public class StuffInventory
{
	public int itemId;
	public int itemCount;
}

public class Inventory
{
	public int itemId;
	public int itemCount;
}

public class DataFileName
{
	public string _ItemData = "ItemData";
	public string _PlayerData = "PlayerInfoData";
	public string _equipmentInvenData = "EquipmentInvenData";
	public string _stuffInvenData = "stuffInvenData";
	public string _inventoryData = "InventoryData";
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
	public List<Inventory> inventory = new List<Inventory>();

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
			player._Gold = float.Parse((m_dictionaryData[i]["currentGold"].ToString()));

		}

		m_dictionaryData.Clear();

		m_dictionaryData = CSVReader.Read(dataFileName._equipmentInvenData);

		for (int i = 0; i < m_dictionaryData.Count; i++)
		{
			equipmentInven.Add(new EquipmentInventory());

			equipmentInven[i].equipmentId = int.Parse((m_dictionaryData[i]["EquipmentId"].ToString()));
			equipmentInven[i].itemCount = int.Parse((m_dictionaryData[i]["itemCount"].ToString()));
			//Debug.Log(equipmentInven[i].equipmentId);
		}

		m_dictionaryData.Clear();

		m_dictionaryData = CSVReader.Read(dataFileName._stuffInvenData);

		for (int i = 0; i < m_dictionaryData.Count; i++)
		{
			stuffInven.Add(new StuffInventory());

			stuffInven[i].itemId = int.Parse((m_dictionaryData[i]["itemId"].ToString()));
			stuffInven[i].itemCount = int.Parse((m_dictionaryData[i]["itemCount"].ToString()));

		}

		m_dictionaryData.Clear();

		m_dictionaryData = CSVReader.Read(dataFileName._inventoryData);

		for (int i = 0; i < m_dictionaryData.Count; i++)
		{
			inventory.Add(new Inventory());

			inventory[i].itemId = int.Parse((m_dictionaryData[i]["itemId"].ToString()));
			inventory[i].itemCount = int.Parse((m_dictionaryData[i]["itemCount"].ToString()));

		}


	}

	private void Update()
	{
		//if (Input.GetKeyDown(KeyCode.P))
		//{
		//SaveData();
		//SaveItemData();
		//}
	}

	public void SaveData()
	{
		using (var writer = new CsvFileWriter("Assets/Resources/PlayerInfoData.csv"))
		{
			List<string> columns = new List<string>() { "maxHp", "maxMp", "moveSpeed", "damege", "currentGold" };// making Index Row
			writer.WriteRow(columns);
			columns.Clear();
			PlayerInfo player = GameManager.instance.g_playerInfo.GetComponent<PlayerInfo>();
			columns.Add(player._PlayerInfomation.maxHp.ToString());  // HP
			columns.Add(player._PlayerInfomation.maxMp.ToString());
			columns.Add(player._PlayerInfomation.moveSpeed.ToString());
			columns.Add(player._PlayerInfomation.damege.ToString());
			columns.Add(player._PlayerInfomation.currentGold.ToString());
			writer.WriteRow(columns);
			columns.Clear();

		}


	}

	public void SaveItemData()
	{
		using (var writer = new CsvFileWriter("Assets/Resources/stuffInvenData.csv"))
		{
			List<string> columns = new List<string>() { "itemId", "itemCount" };

			for (int i = 0; i < 2; i++)
			{
				// making Index Row
				writer.WriteRow(columns);
				columns.Clear();
				ItemSlot slot = GameManager.instance.inventory.equipmentSlots[6 + i];
				if (slot.GetItem().itmeInfo.itemId != 0)
				{
					columns.Add(slot.GetItem().itmeInfo.itemId.ToString());
					columns.Add(slot.itemCount.ToString());
				}
				else if (slot.GetItem().itmeInfo.itemId == 0)
				{
					int num = 0;
					columns.Add(num.ToString());
					columns.Add(num.ToString());
				}
			}
			writer.WriteRow(columns);
			columns.Clear();
		}
	}

	public void SaveArmorData()
	{
		using (var writer = new CsvFileWriter("Assets/Resources/EquipmentInvenData.csv"))
		{
			List<string> columns = new List<string>() { "EquipmentId", "itemCount" };

			for (int i = 0; i < 6; i++)
			{
				// making Index Row
				writer.WriteRow(columns);
				columns.Clear();
				ItemSlot slot = GameManager.instance.inventory.equipmentSlots[i];
				if (slot.GetItem().itmeInfo.itemId != 0)
				{
					columns.Add(slot.GetItem().itmeInfo.itemId.ToString());
					columns.Add(slot.itemCount.ToString());
				}
				else if (slot.GetItem().itmeInfo.itemId == 0)
				{
					int num = 0;
					columns.Add(num.ToString());
					columns.Add(num.ToString());
				}
			}
			writer.WriteRow(columns);
			columns.Clear();
		}
	}

	public void SaveInventoryData()
	{
		using (var writer = new CsvFileWriter("Assets/Resources/InventoryData.csv"))
		{
			List<string> columns = new List<string>() { "itemId", "itemCount" };

			for (int i = 0; i < GameManager.instance.inventory.stuffSlots.Length; i++)
			{
				// making Index Row
				writer.WriteRow(columns);
				columns.Clear();
				ItemSlot slot = GameManager.instance.inventory.stuffSlots[i];
				if (slot.GetItem().itmeInfo.itemId != 0)
				{
					columns.Add(slot.GetItem().itmeInfo.itemId.ToString());
					columns.Add(slot.itemCount.ToString());
				}
				else if (slot.GetItem().itmeInfo.itemId == 0)
				{
					int num = 0;
					columns.Add(num.ToString());
					columns.Add(num.ToString());
				}
			}
			writer.WriteRow(columns);
			columns.Clear();
		}
	}




}

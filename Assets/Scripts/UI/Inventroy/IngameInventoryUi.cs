using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameInventoryUi : MonoBehaviour
{
	public static bool inventoryActivated = false;
	public bool isClear = false;

	[SerializeField]
	private GameObject InventoryBase;
	[SerializeField]
	private GameObject SlotsParent;

	private ItemSlot[] Slots;
	[SerializeField]
	private Item item = new Item();

	// Start is called before the first frame update
	void Start()
	{
		Slots = SlotsParent.GetComponentsInChildren<ItemSlot>();

		LoadInventory();
	}

	// Update is called once per frame
	void Update()
	{

		

	}

	public void LoadInventory()
	{
		for (int i = 0; i < Slots.Length; i++)
		{
			Slots[i].itemCount = DataManager.instance.GetStuffInventoryInfo(i).itemCount;
			item.itmeInfo.itemId = DataManager.instance.GetStuffInventoryInfo(i).itemId;
			if (item.itmeInfo.itemId > 0)
			{

				item.itmeInfo.itemName = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).name;
				item.itmeInfo.itemImageName = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).imageName;
				item.itmeInfo.itemType = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).type;
				item.itmeInfo.itemValue = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).value;
				item.itmeInfo.itemBuyGold = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).buyGold;
				item.itmeInfo.itemSellGold = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).sellGold;

				Slots[i].AddItem(item, Slots[i].itemCount);
			}
		}

	}
}

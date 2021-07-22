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
	private Item item;

	// Start is called before the first frame update
	void Start()
	{
		Slots = SlotsParent.GetComponentsInChildren<ItemSlot>();

		//LoadInventory();
	}

	// Update is called once per frame
	void Update()
	{

		if (Input.GetKeyDown(KeyCode.Alpha6))
		{
			item.itmeInfo.itemId = 1;
			item.itmeInfo.itemImageName = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).imageName;
			item.itmeInfo.itemName = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).name;
			item.itmeInfo.itemType = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).type;
			item.itmeInfo.itemValue = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).value;
			item.itmeInfo.itemBuyGold = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).buyGold;
			item.itmeInfo.itemSellGold = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).sellGold;

			Debug.Log(item.name);

			Slots[0].AddItem(item);
		}

		TryOpenInventory();
		ClearInventory();

	}

	private void TryOpenInventory()
	{
		if (Input.GetKeyDown(KeyCode.I))
		{
			inventoryActivated = !inventoryActivated;

			if (inventoryActivated)
				OpenInventory();
			if (!inventoryActivated)
				CloseInventory();
		}
	}

	private void OpenInventory()
	{
		//equipmentInventoryBase.SetActive(true);
		//inventoryActivated = true;
	}

	private void CloseInventory()
	{
		//equipmentInventoryBase.SetActive(false);
		//inventoryActivated = false;
	}

	public void AcquireItem(Item _item, int _count = 1)
	{
		//아이템이 무기 종류가 아니면 실행
		if ("Used" == _item.itmeInfo.itemType)
		{
			for (int i = 0; i < Slots.Length; i++)
			{
				if (Slots[i].item != null)
				{
					//슬롯에 아이템이 있다 그럼 아이템 갯수를 전달
					if (Slots[i].item.itmeInfo.itemId == _item.itmeInfo.itemId)
					{
						//if (slots[i].itemCount < 99)
						//{
						Slots[i].SetSlotCount(_count);
						return;
						//}
					}
				}

			}

			for (int i = 0; i < Slots.Length; i++)
			{
				if (Slots[i].item == null)
				{
					Slots[i].AddItem(_item, _count);
					return;
				}

				if (Slots[i].item != null)
				{
					Slots[i].AddItem(_item, _count);
					return;
				}
			}
		}







	}

	public void ClearInventory()
	{
		//if (isClear)
		//{
		//	for (int i = 0; i < equipmentSlots.Length; i++)
		//	{
		//		Debug.Log(equipmentSlots[i].slotType);
		//		if (equipmentSlots[i].item != null)
		//		{
		//			equipmentSlots[i].ClearSlot();
		//		}
		//	}
		//	isClear = false;
		//}

	}

	public void LoadInventory()
	{
		for (int i = 0; i < Slots.Length; i++)
		{
			Slots[i].itemCount = DataManager.instance.GetStuffInventoryInfo(i).stuffCount;
			item.itmeInfo.itemId = DataManager.instance.GetStuffInventoryInfo(i).stuffId;
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

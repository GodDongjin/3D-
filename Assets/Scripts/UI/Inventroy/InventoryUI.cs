using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
	public static bool inventoryActivated = false;
	public bool isClear = false;

	[SerializeField]
	private Button armorBotton;
	[SerializeField]
	private Button shopBotton;

	[SerializeField]
	public GameObject equipmentInventoryBase;
	[SerializeField]
	private GameObject equipmentSlotsParent;

	[SerializeField]
	private GameObject stuffInventoryBase;
	[SerializeField]
	private GameObject stuffSlotsParent;

	public ItemSlot[] equipmentSlots;
	public ItemSlot[] stuffSlots;
	[SerializeField]
	public Item item = new Item();


	// Start is called before the first frame update
	void Start()
	{
		equipmentSlots = equipmentSlotsParent.GetComponentsInChildren<ItemSlot>();
		stuffSlots = stuffSlotsParent.GetComponentsInChildren<ItemSlot>();
		armorBotton.onClick.AddListener(OnClickArmorButton);
		//LoadstuffInventory();
		//shopBotton.onClick.AddListener(OnClickShopButton);
		//LoadInventory();
		//LoadstuffInventory();
	}

	// Update is called once per frame
	void Update()
	{


		//      if(Input.GetKeyDown(KeyCode.Alpha6))
		//{
		//          item.itmeInfo.itemId = 1;
		//          item.itmeInfo.itemImageName = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).imageName;
		//          item.itmeInfo.itemName = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).name;
		//          item.itmeInfo.itemType = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).type;
		//          item.itmeInfo.itemValue = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).value;
		//          item.itmeInfo.itemBuyGold = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).buyGold;
		//          item.itmeInfo.itemSellGold = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).sellGold;

		//          Debug.Log(item.name);

		//          AcquireItem(item);
		//}

		DataManager.instance.dataBase.SaveArmorData();
		DataManager.instance.dataBase.SaveItemData();
		//DataManager.instance.dataBase.sav

	}

	public void OnClickArmorButton()
	{
		LoadInventory();
		LoadstuffInventory();
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
		equipmentInventoryBase.SetActive(true);
		//inventoryActivated = true;
	}

	private void CloseInventory()
	{
		equipmentInventoryBase.SetActive(false);
		//inventoryActivated = false;
	}

	public void StuffSlotAddItem(Item _item, int _count = 1)
	{
		item = _item;

		for (int i = 0; i < stuffSlots.Length; i++)
		{
			if (stuffSlots[i].GetItem() != null)
			{
				//���Կ� �������� �ִ� �׷� ������ ������ ����
				if (stuffSlots[i].GetItem().itmeInfo.itemId == item.itmeInfo.itemId && stuffSlots[i].GetItem().itmeInfo.itemType == "Stuff")
				{
					if (stuffSlots[i].itemCount < 99)
					{
						stuffSlots[i].SetSlotCount(_count);
						return;
					}
				}
				else if (stuffSlots[i].GetItem().itmeInfo.itemId == 0)
				{
					stuffSlots[i].AddItem(item, _count);
					return;
				}
			}

		}
	}

	//public void AcquireItem(Item _item, int _count = 1)
	//{
	//	//�������� ���� ������ �ƴϸ� ����
	//	if ("Stuff" == _item.itmeInfo.itemType)
	//	{
	//		for (int i = 0; i < stuffSlots.Length; i++)
	//		{
	//			if (stuffSlots[i].item != null)
	//			{
	//				//���Կ� �������� �ִ� �׷� ������ ������ ����
	//				if (stuffSlots[i].item.itmeInfo.itemId == _item.itmeInfo.itemId)
	//				{
	//					//if (slots[i].itemCount < 99)
	//					//{
	//					stuffSlots[i].SetSlotCount(_count);
	//					return;
	//					//}
	//				}
	//			}
	//
	//			if (stuffSlots[i].item == null)
	//			{
	//				stuffSlots[i].AddItem(_item, _count);
	//				return;
	//			}
	//		}
	//	}
	//	else
	//	{
	//		for (int i = 0; i < equipmentSlots.Length; i++)
	//		{
	//			if (equipmentSlots[i].slotType.ToString() == _item.itmeInfo.itemType)
	//			{
	//
	//				equipmentSlots[i].AddItem(_item);
	//				return;
	//			}
	//		}
	//
	//	}
	//
	//
	//}
	//if (slots[i].item == null)
	//{
	//
	//    //Debug.Log(slots[i].item.name);
	//    slots[i].AddItem(_item);
	//    return;
	//
	//}
	//else if (slots[i].item != null)
	//{
	//    Debug.Log(slots[i].item.itmeInfo.itemName);
	//    if (slots[i].item.itmeInfo.itemName != _item.itmeInfo.itemName)
	//    {
	//        //Debug.Log(slots[i].item.name);
	//        slots[i].ClearSlot();
	//        slots[i].AddItem(_item);
	//        return;
	//    }
	//    else return;
	// 
	//
	//}z

	//public void SlotCheck(ItemSlot Slot, int itemCount = 1, int index = 0)
	//{
	//	Item itmesd = Slot.item;

	//	//if (Slot.item.itmeInfo.itemType != "Stuff")
	//	//{
	//	//	for (int i = 0; i < equipmentSlots.Length; i++)
	//	//	{
	//	//
	//	//		if (equipmentSlots[i].slotType.ToString() == Slot.item.itmeInfo.itemType)
	//	//		{
	//	//			if (equipmentSlots[i].slotType.ToString() != "Stuff")
	//	//			{
	//	//				if (equipmentSlots[i].item.itmeInfo.itemId > 0)
	//	//				{
	//	//					Item itme = equipmentSlots[i].item;
	//	//					equipmentSlots[i].PlayerInfoUpdate(itme, -itme.itmeInfo.itemValue);
	//	//					equipmentSlots[i].AddItem(Slot.item, Slot.itemCount);
	//	//					equipmentSlots[i].PlayerInfoUpdate(Slot.item, Slot.item.itmeInfo.itemValue);
	//	//					Slot.AddItem(itme, itemCount);
	//	//					return;
	//	//				}
	//	//				else if (equipmentSlots[i].item.itmeInfo.itemId == 0)
	//	//				{
	//	//					equipmentSlots[i].AddItem(Slot.item, itemCount);
	//	//					equipmentSlots[i].PlayerInfoUpdate(Slot.item, Slot.item.itmeInfo.itemValue);
	//	//					Slot.ClearSlot();
	//	//					return;
	//	//				}
	//	//			}
	//	//
	//	//		}
	//	//	}
	//	//}
	//	if (Slot.item.itmeInfo.itemType == "Stuff")
	//	{
	//		for(int i = 6; i < 8; i++)
	//		{
	//			if (equipmentSlots[i].slotType.ToString() == "Stuff")
	//			{

	//				if (equipmentSlots[i + index].item.itmeInfo.itemId > 0)
	//				{

	//					if (equipmentSlots[i + index].item.itmeInfo.itemId == Slot.item.itmeInfo.itemId)
	//					{
	//						equipmentSlots[i + index].AddItem(item, itemCount);
	//						//equipmentSlots[i + index].SetSlotCount(Slot.itemCount);
	//						Slot.ClearSlot();
	//						return;
	//					}
	//					else
	//					{

	//						//int _itemCount = Slot.itemCount;//equipmentSlots[i + index].itemCount;
	//														//equipmentSlots[i + index].PlayerInfoUpdate(itme, -itme.itmeInfo.itemValue);
	//						Slot.AddItem(equipmentSlots[i + index].item, equipmentSlots[i + index].itemCount);
	//						equipmentSlots[i + index].AddItem(itmesd, itemCount);
	//						//equipmentSlots[i + index].AddItem(Slot.item, Slot.itemCount);
	//						//equipmentSlots[i + index].PlayerInfoUpdate(Slot.item, Slot.item.itmeInfo.itemValue);
	//					}

	//					return;
	//				}
	//				else if (equipmentSlots[i + index].item.itmeInfo.itemId == 0)
	//				{
	//					equipmentSlots[i + index].AddItem(Slot.item, itemCount);
	//					equipmentSlots[i + index].PlayerInfoUpdate(Slot.item, Slot.item.itmeInfo.itemValue);
	//					Slot.ClearSlot();
	//					return;
	//				}

	//			}
	//		}

	//	}







	//}


	public void SlotCheck(ItemSlot _slot, int index = 0, int itemCount = 0)
	{
		if (_slot.GetItem().itmeInfo.itemType == "Stuff")
		{
			if (equipmentSlots[6 + index].GetItem().itmeInfo.itemId > 0)
			{
				if (equipmentSlots[6 + index].GetItem().itmeInfo.itemId == _slot.GetItem().itmeInfo.itemId)
				{
					equipmentSlots[6 + index].AddItem(_slot.GetItem(), equipmentSlots[6 + index].itemCount + itemCount);
					_slot.ClearSlot();
						
					return;
				}
				else
				{
					item = equipmentSlots[6 + index].GetItem();
					int tempCoumt = equipmentSlots[6 + index].itemCount;

					equipmentSlots[6 + index].SetItem(_slot.GetItem(), itemCount);

					for (int i = 0; i < stuffSlots.Length; i++)
					{
						if (_slot.GetItem().itmeInfo.itemId == stuffSlots[i].GetItem().itmeInfo.itemId)
						{
							_slot.SetItem(item, tempCoumt);
							return;
						}
					}
					return;
				}
			}
			else if (equipmentSlots[6 + index].GetItem().itmeInfo.itemId == 0)
			{
				equipmentSlots[6 + index].AddItem(_slot.GetItem(), itemCount);
				for (int i = 0; i < stuffSlots.Length; i++)
				{
					if (_slot.GetItem().itmeInfo.itemId == stuffSlots[i].GetItem().itmeInfo.itemId)
					{
						_slot.ClearSlot();
						return;
					}
				}
				return;
			}
		}
		if (_slot.GetItem().itmeInfo.itemType != "Stuff")
		{
			for (int i = 0; i < 6; i++)
			{
				if (equipmentSlots[i].slotType.ToString() == _slot.GetItem().itmeInfo.itemType)
				{
					if (equipmentSlots[i].GetItem().itmeInfo.itemId > 0)
					{
						if (equipmentSlots[i].GetItem().itmeInfo.itemId != _slot.GetItem().itmeInfo.itemId)
						{
							item = equipmentSlots[i].GetItem();
							int tempCoumt = equipmentSlots[i].itemCount;
							equipmentSlots[i].SetItem(_slot.GetItem());
							_slot.SetItem(item, tempCoumt);

							return;
						}
					}
					else if (equipmentSlots[i].GetItem().itmeInfo.itemId == 0)
					{
						equipmentSlots[i].AddItem(_slot.GetItem(), itemCount);
						_slot.ClearSlot();

						return;
					}

				}
			}
		}
	}

	public void LoadInventory()
	{
		for (int j = 0; j < 6; j++)
		{
			item.itmeInfo.itemId = DataManager.instance.GetEquipmentInventoryInfo(j).equipmentId;

			if (item.itmeInfo.itemId > 0)
			{
				item.itmeInfo.itemName = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).name;
				item.itmeInfo.itemImageName = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).imageName;
				item.itmeInfo.itemType = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).type;
				item.itmeInfo.itemValue = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).value;
				item.itmeInfo.itemBuyGold = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).buyGold;
				item.itmeInfo.itemSellGold = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).sellGold;
				equipmentSlots[j].AddItem(item, equipmentSlots[j].itemCount);
			}
			
			
		}
	}

	public void LoadstuffInventory()
	{

		equipmentSlots[6].itemCount = DataManager.instance.GetStuffInventoryInfo(0).itemCount;
		item.itmeInfo.itemId = DataManager.instance.GetStuffInventoryInfo(0).itemId;
		if (item.itmeInfo.itemId > 0)
		{
			item.itmeInfo.itemName = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).name;
			item.itmeInfo.itemImageName = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).imageName;
			item.itmeInfo.itemType = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).type;
			item.itmeInfo.itemValue = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).value;
			item.itmeInfo.itemBuyGold = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).buyGold;
			item.itmeInfo.itemSellGold = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).sellGold;
			equipmentSlots[6].AddItem(item, equipmentSlots[6].itemCount);
		}
		

		equipmentSlots[7].itemCount = DataManager.instance.GetStuffInventoryInfo(1).itemCount;
		item.itmeInfo.itemId = DataManager.instance.GetStuffInventoryInfo(1).itemId;
		if (item.itmeInfo.itemId > 0)
		{
			item.itmeInfo.itemName = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).name;
			item.itmeInfo.itemImageName = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).imageName;
			item.itmeInfo.itemType = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).type;
			item.itmeInfo.itemValue = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).value;
			item.itmeInfo.itemBuyGold = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).buyGold;
			item.itmeInfo.itemSellGold = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).sellGold;
			equipmentSlots[7].AddItem(item, equipmentSlots[7].itemCount);
		}
		
	}
}


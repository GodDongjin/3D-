using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
	public static bool inventoryActivated = false;

	[SerializeField]
	private GameObject go_InventoryBase;
	[SerializeField]
	private GameObject go_SlotsParent;

	private ItemSlot[] slots;

	// Start is called before the first frame update
	void Start()
	{
		slots = go_SlotsParent.GetComponentsInChildren<ItemSlot>();
	}

	// Update is called once per frame
	void Update()
	{
		TryOpenInventory();

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
		go_InventoryBase.SetActive(true);
		//inventoryActivated = true;
	}

	private void CloseInventory()
	{
		go_InventoryBase.SetActive(false);
		//inventoryActivated = false;
	}

	public void AcquireItem(Item _item, int _count = 1)
	{
		//아이템이 무기 종류가 아니면 실행
		if ("Equipment" != _item.itmeInfo.itemType)
		{
			for (int i = 0; i < slots.Length; i++)
			{
				if (slots[i].item != null)
				{
					//슬롯에 아이템이 있다 그럼 아이템 갯수를 전달
					if (slots[i].item.itmeInfo.itemId == _item.itmeInfo.itemId)
					{
						//if (slots[i].itemCount < 99)
						//{
						slots[i].SetSlotCount(_count);
						return;
						//}
					}
				}

			}

			for (int i = 0; i < slots.Length; i++)
			{
				if (slots[i].item == null)
				{

					slots[i].AddItem(_item, _count);
					return;

				}
			}
		}


	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public static bool inventoryActivated = false;
    public bool isClear = false;

    [SerializeField]
    private GameObject equipmentInventoryBase;
    [SerializeField]
    private GameObject equipmentSlotsParent;

    [SerializeField]
    private GameObject stuffInventoryBase;
    [SerializeField]
    private GameObject stuffSlotsParent;

    private ItemSlot[] equipmentSlots;
    private ItemSlot[] stuffSlots;
    [SerializeField]
    private Item item;

    // Start is called before the first frame update
    void Start()
    {
        equipmentSlots = equipmentSlotsParent.GetComponentsInChildren<ItemSlot>();
        stuffSlots = stuffSlotsParent.GetComponentsInChildren<ItemSlot>();

        LoadInventory();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Alpha6))
		{
            item.itmeInfo.itemId = 1;
            item.itmeInfo.itemImageName = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).imageName;
            item.itmeInfo.itemName = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).name;
            item.itmeInfo.itemType = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).type;
            item.itmeInfo.itemValue = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).value;
            item.itmeInfo.itemBuyGold = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).buyGold;
            item.itmeInfo.itemSellGold = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).sellGold;

            Debug.Log(item.name);

            AcquireItem(item);
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
        equipmentInventoryBase.SetActive(true);
        //inventoryActivated = true;
    }

    private void CloseInventory()
    {
        equipmentInventoryBase.SetActive(false);
        //inventoryActivated = false;
    }

    public void AcquireItem(Item _item, int _count = 1)
    {
        //아이템이 무기 종류가 아니면 실행
        if ("Used" == _item.itmeInfo.itemType)
        {
            for (int i = 0; i < stuffSlots.Length; i++)
            {
                if (stuffSlots[i].item != null)
                {
                    //슬롯에 아이템이 있다 그럼 아이템 갯수를 전달
                    if (stuffSlots[i].item.itmeInfo.itemId == _item.itmeInfo.itemId)
                    {
                        //if (slots[i].itemCount < 99)
                        //{
                        stuffSlots[i].SetSlotCount(_count);
                        return;
                        //}
                    }
                }

            }

            for (int i = 0; i < stuffSlots.Length; i++)
            {
                if (stuffSlots[i].item == null)
                {
                    stuffSlots[i].AddItem(_item, _count);
                    return;
                }

                if (stuffSlots[i].item != null)
                {
                    stuffSlots[i].AddItem(_item, _count);
                    return;
                }
            }
        }
        else
        {
            for (int i = 0; i < equipmentSlots.Length; i++)
            {
                if (equipmentSlots[i].slotType.ToString() == _item.itmeInfo.itemType)
                {
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
                    equipmentSlots[i].AddItem(_item);
                        return;
                }

            }

        }


    }

    public void ClearInventory()
    {
        if(isClear)
        {
            for (int i = 0; i < equipmentSlots.Length; i++)
            {
                Debug.Log(equipmentSlots[i].slotType);
                if (equipmentSlots[i].item != null)
                {
                    equipmentSlots[i].ClearSlot();
                }
            }
            isClear = false;
        }
        
    }

    public void LoadInventory()
	{
        for (int i = 0; i < stuffSlots.Length; i++)
        {
            stuffSlots[i].itemCount = DataManager.instance.GetStuffInventoryInfo(i).stuffCount;
            item.itmeInfo.itemId = DataManager.instance.GetStuffInventoryInfo(i).stuffId;
            item.itmeInfo.itemName = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).name;
            item.itmeInfo.itemImageName = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).imageName;
            item.itmeInfo.itemType = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).type;
            item.itmeInfo.itemValue = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).value;
            item.itmeInfo.itemBuyGold = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).buyGold;
            item.itmeInfo.itemSellGold = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).sellGold;

            stuffSlots[i].AddItem(item, stuffSlots[i].itemCount);
        }


        for (int i = 0; i < equipmentSlots.Length; i++)
		{
            equipmentSlots[i].item.itmeInfo.itemId = DataManager.instance.GetEquipmentInventoryInfo(i).equipmentId;
            equipmentSlots[i].item.itmeInfo.itemName = DataManager.instance.GetItemInfo(equipmentSlots[i].item.itmeInfo.itemId).name;
            equipmentSlots[i].item.itmeInfo.itemImageName = DataManager.instance.GetItemInfo(equipmentSlots[i].item.itmeInfo.itemId).imageName;
            equipmentSlots[i].item.itmeInfo.itemType = DataManager.instance.GetItemInfo(equipmentSlots[i].item.itmeInfo.itemId).type;
            equipmentSlots[i].item.itmeInfo.itemValue = DataManager.instance.GetItemInfo(equipmentSlots[i].item.itmeInfo.itemId).value;
            equipmentSlots[i].item.itmeInfo.itemBuyGold = DataManager.instance.GetItemInfo(equipmentSlots[i].item.itmeInfo.itemId).buyGold;
            equipmentSlots[i].item.itmeInfo.itemSellGold = DataManager.instance.GetItemInfo(equipmentSlots[i].item.itmeInfo.itemId).sellGold;

            equipmentSlots[i].AddItem(equipmentSlots[i].item);
		}

      

	}
}

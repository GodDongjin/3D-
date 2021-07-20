using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public static bool inventoryActivated = false;
    public bool isClear = false;

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
        if ("Used" == _item.itmeInfo.itemType)
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

                if (slots[i].item != null)
                {
                    slots[i].AddItem(_item, _count);
                    return;
                }
            }
        }
        else
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].slotType.ToString() == _item.itmeInfo.itemType)
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
                    slots[i].AddItem(_item);
                        return;
                }

            }

        }


    }

    public void ClearInventory()
    {
        if(isClear)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                Debug.Log(slots[i].slotType);
                if (slots[i].item != null)
                {
                    slots[i].ClearSlot();
                }
            }
            isClear = false;
        }
        
    }
}

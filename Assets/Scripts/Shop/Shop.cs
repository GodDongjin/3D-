using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private GameObject shopBase;
    [SerializeField]
    private GameObject shopSlotsParent;

    private ShpSlot[] shopSlots;
    [SerializeField]
    private Item item;

    // Start is called before the first frame update
    void Start()
    {
        shopSlots = shopSlotsParent.GetComponentsInChildren<ShpSlot>();


    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
		{
            RandomItem();

        }
    }



    public void RandomSelect()
    {

    }

    public void RandomItem()
    {
        int rand = Random.Range(0, 100);

        if (rand < 40)
        {
            int randomId = Random.Range(0, 3);
            item.itmeInfo.itemId = DataManager.instance.GetItemInfo(randomId).id;
            item.itmeInfo.itemImageName = DataManager.instance.GetItemInfo(randomId).imageName;
            item.itmeInfo.itemName = DataManager.instance.GetItemInfo(randomId).name;
            item.itmeInfo.itemSellGold = DataManager.instance.GetItemInfo(randomId).sellGold;
            item.itmeInfo.itemBuyGold = DataManager.instance.GetItemInfo(randomId).buyGold;
            item.itmeInfo.itemValue = DataManager.instance.GetItemInfo(randomId).value;
            item.itmeInfo.itemType = DataManager.instance.GetItemInfo(randomId).type;

            Debug.Log("아이템" + item.itmeInfo.itemId);
            Debug.Log(randomId);

            shopSlots[0].AddItem(item);

            //for (int i = 0; i < shopSlots.Length; i++)
            //{
            //    if(shopSlots[i].item.itmeInfo.itemId != item.itmeInfo.itemId)
            //	{
            //        shopSlots[i].AddItem(item);
            //
            //    }
            //}

        }
        else if (rand >= 40 && rand < 70)
        {
            int randomId = Random.Range(4, 9);
            item.itmeInfo.itemId = DataManager.instance.GetItemInfo(randomId).id;
            item.itmeInfo.itemImageName = DataManager.instance.GetItemInfo(randomId).imageName;
            item.itmeInfo.itemName = DataManager.instance.GetItemInfo(randomId).name;
            item.itmeInfo.itemSellGold = DataManager.instance.GetItemInfo(randomId).sellGold;
            item.itmeInfo.itemBuyGold = DataManager.instance.GetItemInfo(randomId).buyGold;
            item.itmeInfo.itemValue = DataManager.instance.GetItemInfo(randomId).value;
            item.itmeInfo.itemType = DataManager.instance.GetItemInfo(randomId).type;

            Debug.Log("아이템" + item.itmeInfo.itemId);
            Debug.Log(randomId);

            shopSlots[0].AddItem(item);
        }

        else if (rand >= 70 && rand < 90)
        {
            int randomId = Random.Range(10, 15);
            item.itmeInfo.itemId = DataManager.instance.GetItemInfo(randomId).id;
            item.itmeInfo.itemImageName = DataManager.instance.GetItemInfo(randomId).imageName;
            item.itmeInfo.itemName = DataManager.instance.GetItemInfo(randomId).name;
            item.itmeInfo.itemSellGold = DataManager.instance.GetItemInfo(randomId).sellGold;
            item.itmeInfo.itemBuyGold = DataManager.instance.GetItemInfo(randomId).buyGold;
            item.itmeInfo.itemValue = DataManager.instance.GetItemInfo(randomId).value;
            item.itmeInfo.itemType = DataManager.instance.GetItemInfo(randomId).type;

            Debug.Log("아이템" + item.itmeInfo.itemId);
            Debug.Log(randomId);

            shopSlots[0].AddItem(item);
        }
        else if (rand >= 90 && rand <= 100)
        {
            int randomId = Random.Range(10, 15);
            item.itmeInfo.itemId = DataManager.instance.GetItemInfo(randomId).id;
            item.itmeInfo.itemImageName = DataManager.instance.GetItemInfo(randomId).imageName;
            item.itmeInfo.itemName = DataManager.instance.GetItemInfo(randomId).name;
            item.itmeInfo.itemSellGold = DataManager.instance.GetItemInfo(randomId).sellGold;
            item.itmeInfo.itemBuyGold = DataManager.instance.GetItemInfo(randomId).buyGold;
            item.itmeInfo.itemValue = DataManager.instance.GetItemInfo(randomId).value;
            item.itmeInfo.itemType = DataManager.instance.GetItemInfo(randomId).type;

            Debug.Log("아이템" + item.itmeInfo.itemId);
            Debug.Log(randomId);

            shopSlots[0].AddItem(item);
        }
    }
}

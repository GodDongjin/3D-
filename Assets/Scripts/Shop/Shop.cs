using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
	[SerializeField]
	private Button button;

	[SerializeField]
	private GameObject shopBase;
	[SerializeField]
	private GameObject shopSlotsParent;

	private ShpSlot[] shopSlots;

	[SerializeField]
	private Item item;

	public int count;


	// Start is called before the first frame update
	void Start()
	{
		shopSlots = shopSlotsParent.GetComponentsInChildren<ShpSlot>();
		button.onClick.AddListener(OnClickButton);

	}

	// Update is called once per frame
	void Update()
	{
		//if (Input.GetKeyDown(KeyCode.U))
		//{
		//	for (int i = 0; i < shopSlots.Length; i++)
		//	{
		//
		//		shopSlots[i].AddItem(RandomItem(), count);
		//
		//	}
		//}

		//Debug.Log("Ä«¿îµå" + items.Count);

	}

	public void OnClickButton()
	{
		if(shopBase.activeSelf)
		{
			for (int i = 0; i < shopSlots.Length; i++)
			{

				shopSlots[i].AddItem(RandomItem(), count);

			}
		}
		
	}


	public void RandomSelect()
	{

	}

	public Item RandomItem()
	{
		int rand = Random.Range(0, 100);

		if (rand < 40)
		{
			int randomId = Random.Range(1, 5);
			int randomCount = Random.Range(1, 10);
			item.itmeInfo.itemId = DataManager.instance.GetItemInfo(randomId).id;
			item.itmeInfo.itemImageName = DataManager.instance.GetItemInfo(randomId).imageName;
			item.itmeInfo.itemName = DataManager.instance.GetItemInfo(randomId).name;
			item.itmeInfo.itemSellGold = DataManager.instance.GetItemInfo(randomId).sellGold;
			item.itmeInfo.itemBuyGold = DataManager.instance.GetItemInfo(randomId).buyGold;
			item.itmeInfo.itemValue = DataManager.instance.GetItemInfo(randomId).value;
			item.itmeInfo.itemType = DataManager.instance.GetItemInfo(randomId).type;
			count = randomCount;

		}
		else if (rand >= 40 && rand < 70)
		{
			int randomId = Random.Range(5, 10);
			item.itmeInfo.itemId = DataManager.instance.GetItemInfo(randomId).id;
			item.itmeInfo.itemImageName = DataManager.instance.GetItemInfo(randomId).imageName;
			item.itmeInfo.itemName = DataManager.instance.GetItemInfo(randomId).name;
			item.itmeInfo.itemSellGold = DataManager.instance.GetItemInfo(randomId).sellGold;
			item.itmeInfo.itemBuyGold = DataManager.instance.GetItemInfo(randomId).buyGold;
			item.itmeInfo.itemValue = DataManager.instance.GetItemInfo(randomId).value;
			item.itmeInfo.itemType = DataManager.instance.GetItemInfo(randomId).type;
			count = 1;

		}

		else if (rand >= 70 && rand < 90)
		{
			int randomId = Random.Range(10, 16);
			item.itmeInfo.itemId = DataManager.instance.GetItemInfo(randomId).id;
			item.itmeInfo.itemImageName = DataManager.instance.GetItemInfo(randomId).imageName;
			item.itmeInfo.itemName = DataManager.instance.GetItemInfo(randomId).name;
			item.itmeInfo.itemSellGold = DataManager.instance.GetItemInfo(randomId).sellGold;
			item.itmeInfo.itemBuyGold = DataManager.instance.GetItemInfo(randomId).buyGold;
			item.itmeInfo.itemValue = DataManager.instance.GetItemInfo(randomId).value;
			item.itmeInfo.itemType = DataManager.instance.GetItemInfo(randomId).type;
			count = 1;

		}
		else if (rand >= 90 && rand <= 100)
		{
			int randomId = Random.Range(16, 24);
			item.itmeInfo.itemId = DataManager.instance.GetItemInfo(randomId).id;
			item.itmeInfo.itemImageName = DataManager.instance.GetItemInfo(randomId).imageName;
			item.itmeInfo.itemName = DataManager.instance.GetItemInfo(randomId).name;
			item.itmeInfo.itemSellGold = DataManager.instance.GetItemInfo(randomId).sellGold;
			item.itmeInfo.itemBuyGold = DataManager.instance.GetItemInfo(randomId).buyGold;
			item.itmeInfo.itemValue = DataManager.instance.GetItemInfo(randomId).value;
			item.itmeInfo.itemType = DataManager.instance.GetItemInfo(randomId).type;
			count = 1;
		}


		return item;
	}
}

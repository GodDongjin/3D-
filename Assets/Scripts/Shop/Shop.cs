using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
	[SerializeField]
	private Button button;

	[SerializeField]
	public GameObject shopBase;
	[SerializeField]
	private GameObject shopSlotsParent;

	private ShpSlot[] shopSlots;

	[SerializeField]
	private Item item = new Item();

	public int count;


	// Start is called before the first frame update
	void Start()
	{
		shopSlots = shopSlotsParent.GetComponentsInChildren<ShpSlot>();
		button.onClick.AddListener(OnClickButton);
		

		//item = gameObject.GetComponent<Item>();
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
			item.itmeInfo.itemImageName = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).imageName;
			item.itmeInfo.itemName = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).name;
			item.itmeInfo.itemSellGold = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).sellGold;
			item.itmeInfo.itemBuyGold = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).buyGold;
			item.itmeInfo.itemValue = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).value;
			item.itmeInfo.itemType = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).type;
			count = randomCount;

		}
		else if (rand >= 40 && rand < 70)
		{
			int randomId = Random.Range(5, 10);
			item.itmeInfo.itemId = DataManager.instance.GetItemInfo(randomId).id;
			item.itmeInfo.itemImageName = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).imageName;
			item.itmeInfo.itemName = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).name;
			item.itmeInfo.itemSellGold = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).sellGold;
			item.itmeInfo.itemBuyGold = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).buyGold;
			item.itmeInfo.itemValue = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).value;
			item.itmeInfo.itemType = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).type;
			count = 1;

		}

		else if (rand >= 70 && rand < 90)
		{
			int randomId = Random.Range(11, 16);
			item.itmeInfo.itemId = DataManager.instance.GetItemInfo(randomId).id;
			item.itmeInfo.itemImageName = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).imageName;
			item.itmeInfo.itemName = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).name;
			item.itmeInfo.itemSellGold = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).sellGold;
			item.itmeInfo.itemBuyGold = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).buyGold;
			item.itmeInfo.itemValue = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).value;
			item.itmeInfo.itemType = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).type;
			count = 1;

		}
		else if (rand >= 90 && rand <= 100)
		{
			int randomId = Random.Range(16, 24);
			item.itmeInfo.itemId = DataManager.instance.GetItemInfo(randomId).id;
			item.itmeInfo.itemImageName = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).imageName;
			item.itmeInfo.itemName = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).name;
			item.itmeInfo.itemSellGold = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).sellGold;
			item.itmeInfo.itemBuyGold = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).buyGold;
			item.itmeInfo.itemValue = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).value;
			item.itmeInfo.itemType = DataManager.instance.GetItemInfo(item.itmeInfo.itemId).type;
			count = 1;
		}


		return item;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : MonoBehaviour
{
	[System.Serializable]
	public struct ItemInfo
	{
		public int itemId;
		public int itemValue;
		public int itemBuyGold;
		public int itemSellGold;
		public string itemName;         //������ �̸�  
		public string itemType;
		public string itemImageName;        //������ �̹���
	}

	//[SerializeField]
	public ItemInfo itmeInfo;
	//public string weaponType;

	//public enum ItemType
	//{
	//    None,
	//    Equipment,
	//    Used,
	//    Ingredient,
	//    ETC
	//}


	void Start()
	{
		//itmeInfo.itemName = DataManager.instance.GetItemInfo(itmeInfo.itemId).name;
		//itmeInfo.itemValue = DataManager.instance.GetItemInfo(itmeInfo.itemId).value;
		//itmeInfo.itemType = DataManager.instance.GetItemInfo(itmeInfo.itemId).type;
		//itmeInfo.itemImageName = DataManager.instance.GetItemInfo(itmeInfo.itemId).imageName;
		//itmeInfo.itemBuyGold = DataManager.instance.GetItemInfo(itmeInfo.itemId).buyGold;
		//itmeInfo.itemSellGold = DataManager.instance.GetItemInfo(itmeInfo.itemId).sellGold;
		//
		//Debug.Log(itmeInfo.itemName);
		//Debug.Log(itmeInfo.itemValue);
		//Debug.Log(itmeInfo.itemType);
		//Debug.Log(itmeInfo.itemImageName);
	}

	//public void SetItemInfo(int itemId)
	//{
	//	i
	//}


}

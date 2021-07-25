using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item
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

	public ItemInfo itmeInfo;


}

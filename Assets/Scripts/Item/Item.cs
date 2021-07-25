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
		public string itemName;         //아이템 이름  
		public string itemType;
		public string itemImageName;        //아이템 이미지
	}

	public ItemInfo itmeInfo;


}

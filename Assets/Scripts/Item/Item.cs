using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : MonoBehaviour
{
	[System.Serializable]
	public class ItmeInfo
	{
		public int itemId;
		public int itemValue;
		public string itemName;         //������ �̸�  
		public string itemType;
		public string itemImageName;        //������ �̹���
		public GameObject itemPrefab;   //�������� ������
	}

	//[SerializeField]
	public ItmeInfo itmeInfo;
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
		itmeInfo.itemName = DataManager.instance.GetItemInfo(itmeInfo.itemId).name;
		itmeInfo.itemValue = DataManager.instance.GetItemInfo(itmeInfo.itemId).value;
		itmeInfo.itemType = DataManager.instance.GetItemInfo(itmeInfo.itemId).type;
		itmeInfo.itemImageName = DataManager.instance.GetItemInfo(itmeInfo.itemId).imageName;

		Debug.Log(itmeInfo.itemName);
		Debug.Log(itmeInfo.itemValue);
		Debug.Log(itmeInfo.itemType);
		Debug.Log(itmeInfo.itemImageName);
	}

	//public void SetItemInfo(int itemId)
	//{
	//	i
	//}


}

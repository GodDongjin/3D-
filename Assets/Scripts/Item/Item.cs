using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "New item", menuName = "New Item/item" )]
public class Item : ScriptableObject
{
    public string itemName;         //아이템 이름  
    public ItemType itemType;
    public Sprite itemImage;        //아이템 이미지
    public GameObject itemPrefab;   //아이템의 프리팹

    //public string weaponType;

    public enum ItemType
    {
        Equipment,
        Used,
        Ingredient,
        ETC
    }
}

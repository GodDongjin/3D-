using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public DataBase dataBase;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("씬에 두 개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);
        }

        dataBase = GameObject.Find("GameManager").GetComponent<DataBase>();
    }

    public PlayerDB GetPlayerInfo(int playerLv)
	{
        return dataBase.player[playerLv];
	}

    public ItemDB GetItemInfo(int itemId)
	{
        for(int i = 0; i < dataBase.items.Count; i++)
		{
            if(dataBase.items[i].id == itemId)
			{
                //Debug.Log(dataBase.items[i].id);
                //Debug.Log(dataBase.items[i].imageName);
                //Debug.Log(dataBase.items[i].type);
                //Debug.Log(dataBase.items[i].imageName);
                return dataBase.items[i];

            }
		}

        return null;
	}

    public EquipmentInventory GetEquipmentInventoryInfo(int itemId)
    {
        return dataBase.equipmentInven[itemId];
    }

    public StuffInventory GetStuffInventoryInfo(int itemId)
    {
        return dataBase.stuffInven[itemId];
    }
}

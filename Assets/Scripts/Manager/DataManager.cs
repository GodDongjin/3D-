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
            Debug.LogWarning("���� �� �� �̻��� ���� �Ŵ����� �����մϴ�!");
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
                Debug.Log(dataBase.items[i].id);
                Debug.Log(dataBase.items[i].imageName);
                Debug.Log(dataBase.items[i].type);
                //Debug.Log(dataBase.items[i].imageName);
                return dataBase.items[i];

            }
		}

        return null;
	}
}

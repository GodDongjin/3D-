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
}

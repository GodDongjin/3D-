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
}

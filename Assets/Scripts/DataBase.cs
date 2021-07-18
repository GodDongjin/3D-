using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDB
{
    public int id;
    public int name;
}

public class PlayerDB
{
    public int _Lv;
    public float _MaxHp;
    public float _MaxMp;
    public float _Damage;
    public float _MaxExperience;
}

public class DataFileName
{
    public string _ItemData = "ItemData";
    public string _PlayerData = "PlayerInfoData";
    //public string _ItemData = "ItemData";
    //public string _ItemData = "ItemData";
}

public class DataBase : MonoBehaviour
{
    //public string m_strCSVFileName = string.Empty;

    public DataFileName dataFileName = new DataFileName();

    public List<ItemDB> items = new List<ItemDB>();
    public List<PlayerDB> player = new List<PlayerDB>();

	private void Awake()
	{
        List<Dictionary<string, object>> m_dictionaryData = CSVReader.Read(dataFileName._ItemData);
        
        for (int i = 0; i < m_dictionaryData.Count; i++)
		{
            items.Add(new ItemDB());
        
            items[i].id = int.Parse((m_dictionaryData[i]["id"].ToString()));
            items[i].name = int.Parse((m_dictionaryData[i]["name"].ToString()));
        }

        m_dictionaryData.Clear();
        
        m_dictionaryData = CSVReader.Read(dataFileName._PlayerData);

        for(int i = 0; i < m_dictionaryData.Count; i++)
		{
            player.Add(new PlayerDB());

            player[i]._Lv = int.Parse((m_dictionaryData[i]["Lv"].ToString()));
            player[i]._MaxHp = int.Parse((m_dictionaryData[i]["maxHp"].ToString()));
            player[i]._MaxMp = int.Parse((m_dictionaryData[i]["maxMp"].ToString()));
            player[i]._Damage = int.Parse((m_dictionaryData[i]["damage"].ToString()));
            player[i]._MaxExperience = int.Parse((m_dictionaryData[i]["maxExperience"].ToString()));

           
		}

    }
	

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Player g_Player;
    public Boss g_Boss;

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

        g_Player = GameObject.Find("Player").GetComponent<Player>();
        g_Boss = GameObject.Find("Boss").GetComponent<Boss>();

    }
        // Update is called once per frame
        void Update()
    {
        
    }
}

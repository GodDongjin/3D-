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
            Debug.LogWarning("씬에 두 개 이상의 게임 매니저가 존재합니다!");
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

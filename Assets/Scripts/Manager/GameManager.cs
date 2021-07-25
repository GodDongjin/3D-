using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	public Player g_Player;
	public PlayerInfo g_playerInfo;
	public Boss g_Boss;
	public InventoryUI inventory;
	public Item item = new Item();

	[SerializeField]
	private Text text;
	[SerializeField]
	private Text hp;
	[SerializeField]
	private Text mp;
	[SerializeField]
	private Text attck;
	[SerializeField]
	private Text moveSpeed;

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
		g_playerInfo = g_Player.GetComponent<PlayerInfo>();
	
		//inventory = GameObject.Find("Inventory").GetComponent<InventoryUI>();
		//g_Boss = GameObject.Find("Boss").GetComponent<Boss>();

	}
	// Update is called once per frame
	void Update()
	{
		CurrentGold();

		hp.text = "HP : " + g_playerInfo._PlayerInfomation.maxHp.ToString();

		mp.text = "MP : " + g_playerInfo._PlayerInfomation.maxMp.ToString();

		attck.text = "Attck : " + g_playerInfo._PlayerInfomation.damege.ToString();

		moveSpeed.text = "MoveSpeed : " + g_playerInfo._PlayerInfomation.moveSpeed.ToString();
	}



	private void CurrentGold()
	{
		text.text = g_playerInfo._PlayerInfomation.currentGold.ToString();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
	[SerializeField]
	private GameObject gameOver;
	[SerializeField]
	private GameObject gameOver1;
	[SerializeField]
	private Button Button1;
	[SerializeField]
	private Button Button2;
	[SerializeField]
	private Button Button3;
	[SerializeField]
	private Button Button4;

	private void Start()
	{
		Button1.onClick.AddListener(OnClickContinueButton);
		Button2.onClick.AddListener(OnClickExitButton);
		Button3.onClick.AddListener(OnClickContinueButton);
		Button4.onClick.AddListener(OnClickExitButton);
	}
	private void Update()
	{
		if (GameManager.instance.g_Boss.isDie)
		{
			gameOver.SetActive(true);
		}
		if(GameManager.instance.g_playerInfo._PlayerInfomation.isDie)
		{
			gameOver1.SetActive(true);
		}
	}

	public void OnClickContinueButton()
	{
		SceneManager.LoadScene("mainScene");
	}

	public void OnClickExitButton()
	{
		Application.Quit();
	}
}

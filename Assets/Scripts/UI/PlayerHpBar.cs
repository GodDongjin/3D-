using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour
{
    public PlayerInfo playerInfo;

    public Text hpTxt;
    public Text hpInfoTxt;

    public Image hpBar;

    public int hpSingleBar = 100;

    public float maxHP = 100;
    public float currHp = 100;


    // Start is called before the first frame update
    void Start()
    {
        playerInfo = GameObject.Find("Player").GetComponent<PlayerInfo>();

        maxHP = playerInfo._PlayerInfomation.maxHp;
        currHp = playerInfo._PlayerInfomation.currentHp;


    }

    // Update is called once per frame
    void Update()
    {
        maxHP = playerInfo._PlayerInfomation.maxHp;
        currHp = playerInfo._PlayerInfomation.currentHp;

        HandleHp();

        hpInfoTxt.text = currHp + " / " + maxHP;
    }

    private void HandleHp()
	{
        //hpBar.rectTransform.sizeDelta = new Vector2(hpBar.rectTransform.sizeDelta.x * ((float)(currHp) % hpSingleBar), hpBar.rectTransform.sizeDelta.y);
        hpBar.fillAmount = Mathf.Lerp(hpBar.fillAmount, currHp / maxHP, Time.deltaTime * 10f);
    }
}

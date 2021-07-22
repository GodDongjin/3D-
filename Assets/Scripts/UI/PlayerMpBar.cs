using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMpBar : MonoBehaviour
{
    public PlayerInfo playerInfo;

    public Text hpTxt;
    public Text hpInfoTxt;

    public Image hpBar;

    public int hpSingleBar = 100;

    public float maxMp = 100;
    public float currMp = 100;


    // Start is called before the first frame update
    void Start()
    {
        playerInfo = GameObject.Find("Player").GetComponent<PlayerInfo>();

        maxMp = playerInfo._PlayerInfomation.maxMp;
        currMp = playerInfo._PlayerInfomation.currentMp;


    }

    // Update is called once per frame
    void Update()
    {
        maxMp = playerInfo._PlayerInfomation.maxMp;
        currMp = playerInfo._PlayerInfomation.currentMp;

        HandleHp();

        hpInfoTxt.text = currMp + " / " + maxMp;
    }

    private void HandleHp()
	{
        //hpBar.rectTransform.sizeDelta = new Vector2(hpBar.rectTransform.sizeDelta.x * ((float)(currHp) % hpSingleBar), hpBar.rectTransform.sizeDelta.y);
        hpBar.fillAmount = Mathf.Lerp(hpBar.fillAmount, currMp / maxMp, Time.deltaTime * 10f);
    }
}

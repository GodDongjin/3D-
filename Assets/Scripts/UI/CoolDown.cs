using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDown : MonoBehaviour
{
    PlayerInfo player;

    public Image[] image;
    public Text[] text;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerInfo>();
        //image[0].fillAmount = player._PlayerInfomation.currentSkille1Cooldown / player._PlayerInfomation.maxSkille1Cooldown;
        //image[1].fillAmount = player._PlayerInfomation.currentSkille2Cooldown / player._PlayerInfomation.maxSkille2Cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if(player._PlayerInfomation.isCooldown1)
		{
            image[0].fillAmount = 1 - (player._PlayerInfomation.currentSkille1Cooldown / player._PlayerInfomation.maxSkille1Cooldown);
            
        }
        else if(!player._PlayerInfomation.isCooldown1)
		{
            image[0].fillAmount = player._PlayerInfomation.currentSkille1Cooldown / player._PlayerInfomation.maxSkille1Cooldown;
        }

        if (player._PlayerInfomation.isCooldown2)
        {
            image[1].fillAmount = 1 - (player._PlayerInfomation.currentSkille2Cooldown / player._PlayerInfomation.maxSkille2Cooldown);
        }
        else if (!player._PlayerInfomation.isCooldown2)
        {
            image[1].fillAmount = player._PlayerInfomation.currentSkille2Cooldown / player._PlayerInfomation.maxSkille2Cooldown;
        }


        if (player._PlayerInfomation.isItem1Cooldown)
        {
            image[2].fillAmount = 1 - (player._PlayerInfomation.currentItem1Cooldown / player._PlayerInfomation.maxItem1Cooldown);

        }
        else if (!player._PlayerInfomation.isItem1Cooldown)
        {
            image[2].fillAmount = player._PlayerInfomation.currentItem1Cooldown / player._PlayerInfomation.maxItem1Cooldown;
        }

        if (player._PlayerInfomation.isItem2Cooldown)
        {
            image[3].fillAmount = 1 - (player._PlayerInfomation.currentItem2Cooldown / player._PlayerInfomation.maxItem2Cooldown);
        }
        else if (!player._PlayerInfomation.isItem2Cooldown)
        {
            image[3].fillAmount = player._PlayerInfomation.currentItem2Cooldown / player._PlayerInfomation.maxItem2Cooldown;
        }

        int num = (int)player._PlayerInfomation.currentSkille1Cooldown;
        int num2 = (int)player._PlayerInfomation.currentSkille2Cooldown;
        int num3 = (int)player._PlayerInfomation.currentItem1Cooldown;
        int num4 = (int)player._PlayerInfomation.currentItem2Cooldown;

        text[0].text = num.ToString();
        text[1].text = num2.ToString();



    }
}

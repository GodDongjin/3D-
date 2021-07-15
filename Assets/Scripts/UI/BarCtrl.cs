using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarCtrl : MonoBehaviour
{
    public BossInfo Boss;

    public Text hpTxt;
    public Text hpInfoTxt;

	public Image nextHpBar, curHpBar;

    public int hpSingleBar = 100;

    public float maxHP = 100;
    public float currHp = 100;

    public List<Color> colors;

    public int t = 20;


    // Start is called before the first frame update
    void Start()
    {
        Boss = GameObject.Find("Boss").GetComponent<BossInfo>();

        maxHP = Boss._BossInfomation.maxHp;
        currHp = Boss._BossInfomation.currentHp;
    }

    // Update is called once per frame
    void Update()
    {
        maxHP = Boss._BossInfomation.maxHp;
        currHp = Boss._BossInfomation.currentHp;
        //Debug.Log(GetHpRatiolnSinglBar(t));
        Refersh();
        SetColor();
    }

    void Refersh()
	{
        curHpBar.rectTransform.sizeDelta = new Vector2(nextHpBar.rectTransform.sizeDelta.x * GetHpRatiolnSinglBar(currHp), nextHpBar.rectTransform.sizeDelta.y);

        hpTxt.text = "X " + GetHpCount(currHp);

        curHpBar.color = GetColotByLayer(currHp);
        nextHpBar.color = GetColotByLayer(currHp - hpSingleBar);

        if(currHp <= 0)
		{
 
            hpInfoTxt.text = 0 + " / " + maxHP;
        }
        else
		{
            hpInfoTxt.text = currHp + " / " + maxHP;
        }
        
    }

    public void SetColor()
	{
      

	}

    public float GetHpRatiolnSinglBar(float targetHp)
	{
        float resultRatio = 0;

        if(targetHp > 0)
		{

            float divided = targetHp / hpSingleBar;

            if (divided == (int)divided)
            {
                resultRatio = 1;
            }
            else
            {
                float moduled = targetHp % hpSingleBar;

                resultRatio = moduled / hpSingleBar;
            }
        }
		else
		{
            resultRatio = 0;

        }

        return resultRatio;
	}

    public int GetHpCount(float targetHp)
	{
        //float resultRatio = 0;
        int index = 0;

        if (targetHp >= 0)
        {
            float divided = targetHp / hpSingleBar;

            index = (int)divided;
        }

            return (int)index;
    }

    Color GetColotByLayer(float targetHp)
	{
        Color result = Color.black;

        if(targetHp > 0)
		{
            float divided = (float)targetHp / hpSingleBar;

            int index = (int)divided;

            if(divided == (int)divided)
			{
                index--;
			}

            result = colors[index % colors.Count];
		}

        return result;
	}
}

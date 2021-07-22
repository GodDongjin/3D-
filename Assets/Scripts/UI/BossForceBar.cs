using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossForceBar : MonoBehaviour
{
    public BossInfo bossInfo;

    public Text hpTxt;
    public Text hpInfoTxt;

    public Image ForceBar;

    public int ForceSingleBar = 100;

    public float maxForce;
    public float currForce;


    // Start is called before the first frame update
    void Start()
    {
        bossInfo = GameObject.Find("Boss").GetComponent<BossInfo>();

        maxForce = bossInfo._BossInfomation.maxRigidity;
        currForce = bossInfo._BossInfomation.currentRigidity;


    }

    // Update is called once per frame
    void Update()
    {
        maxForce = bossInfo._BossInfomation.maxRigidity;
        currForce = bossInfo._BossInfomation.currentRigidity;

        HandleForce();

        hpInfoTxt.text = currForce + " / " + maxForce;
    }

    private void HandleForce()
    {
        //hpBar.rectTransform.sizeDelta = new Vector2(hpBar.rectTransform.sizeDelta.x * ((float)(currHp) % hpSingleBar), hpBar.rectTransform.sizeDelta.y);
        ForceBar.fillAmount = Mathf.Lerp(ForceBar.fillAmount, currForce / maxForce, Time.deltaTime * 10f);
    }
}

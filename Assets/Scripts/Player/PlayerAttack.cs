using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttack : Player
{
    BossInfo boss;
  

    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.Find("Boss").GetComponent<BossInfo>();
        //ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
		{
            if (state != Player_State.Attack && attackCombo == 0)
			{
                MouseRotate();
                ChangeState(Player_State.Attack);
            }
		}

        if(Input.GetKeyDown(KeyCode.Q))
		{
            if(state != Player_State.Skiile1)
			{
                ChangeState(Player_State.Skiile1);
            }
		}
       
    }

    //ParticleSystemTriggerEventType

    private void OnTriggerEnter(Collider other)
    {
        if (!isEnemyHit && state == Player_State.Attack)
        {
            if (other.name == "Boss")
            {
                isEnemyHit = true;
                Vector3 bossPos = GameManager.instance.g_Boss.transform.position;
                Vector3 hitPrefabsPos = new Vector3(bossPos.x, bossPos.y + 3, bossPos.z);
                Instantiate(hitPrefabs, hitPrefabsPos, Quaternion.identity);

                //boss.BossHpLose(damege, rigidity);

                GameManager.instance.g_Boss.BossHpLose(damege, rigidity);
            }
        }
    }
   

   
}

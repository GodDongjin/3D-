using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : Player
{
    // Start is called before the first frame update
    void Start()
    {
        
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
       
    }

    
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
            }
        }
    }
   

   
}

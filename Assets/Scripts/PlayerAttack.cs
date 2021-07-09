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

    private void OnTriggerStay(Collider other)
    {
        if (isEnemyHit)
        {
            if (other.tag == "Enemy")
            {
                other.gameObject.SetActive(false);

            }
        }
    }
   

   
}

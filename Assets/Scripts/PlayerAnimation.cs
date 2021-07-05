using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : Player
{

    float index = 0f;
    // Start is called before the first frame update
    void Start()
    {
        base.animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        base.animator.SetBool("IsWalk", movePos != Vector3.zero);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            base.animator.SetFloat("combo", index);
            index++;
        }
        
    }

}

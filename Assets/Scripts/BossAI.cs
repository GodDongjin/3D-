using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : Boss
{
    float dis;

    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.Find("Boss");
        player = GameObject.Find("Player");

        animator = gameObject.GetComponent<Animator>();

        state = AI_State.Idle;
        ChangeState(state);

    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case AI_State.Idle: IdleUpdate(); break;
            case AI_State.Move: MoveUpdate(); break;
            case AI_State.Attack1: Attack1Update(); break;
            case AI_State.Attack2: Attack2Update(); break;
            case AI_State.skill: IdleUpdate(); break;
            case AI_State.Stiffness: IdleUpdate(); break;
            case AI_State.Die: IdleUpdate(); break;
        }

        

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            animator.SetBool("Attack1", true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            animator.SetBool("Attack2", true);
        }


    }

    public void ChangeState(AI_State nextState)
    {
        state = nextState;

        animator.SetBool("Attack1", false);
        animator.SetBool("Attack2", false);
        animator.SetBool("Move", false);

        StopAllCoroutines();

        switch (state)
        {
            case AI_State.Idle: StartCoroutine(CoroutineIdel()); break;
            case AI_State.Move: StartCoroutine(CoroutineMove()); break;
            case AI_State.Attack1: StartCoroutine(CoroutineAttack1()); break;
            case AI_State.Attack2: StartCoroutine(CoroutineAttack2()); break;
            case AI_State.skill: break;
            case AI_State.Stiffness: break;
            case AI_State.Die: break;
        }
    }

    public void IdleUpdate()
    {
        //플레이어랑 보스 거리 차이 체크
       

    }

    public void MoveUpdate()
    {
        boss.transform.position = Vector3.Slerp(player.transform.position, boss.transform.position, 3f);
    }

    public void Attack1Update()
    {
        //StartCoroutine(CoroutineAttack1());

        //ChangeState(AI_State.Idle);
    }

    public void Attack2Update()
    {
        //StartCoroutine(CoroutineAttack2());

        
    }


    //코루틴 
    IEnumerator CoroutineIdel()
    {
        dis = Vector3.Distance(boss.transform.position, player.transform.position);

        if (dis <= 3f)
        {
            int randAction = Random.Range(0, 2);

            switch (randAction)
            {
                case 0:
                    state = AI_State.Attack1;
                    break;
                case 1:
                    state = AI_State.Attack2;
                    break;
            }
            Debug.Log("쫒아가");
            ChangeState(state);
        }
        if (dis > 3f)
        {
            ChangeState(AI_State.Move);
            Debug.Log("따라가");
        }
        

        yield break;

    }

    IEnumerator CoroutineMove()
    {
        animator.SetBool("Move", true);

        yield return new WaitForSeconds(3f);

        ChangeState(AI_State.Idle);

        yield break;
    }

        IEnumerator CoroutineAttack1()
    {
        animator.SetBool("Attack1", true);

        while (true)
        {

            // TODO : 애니메이션 종료 확인 후 상태 전환

            yield return new WaitUntil(() => BossAnimatorEnd("G_Attack4"));

            ChangeState(AI_State.Idle);

            yield break;
        }

        
    }

    IEnumerator CoroutineAttack2()
    {
        animator.SetBool("Attack2", true);

        while (true)
        {
            // TODO : 애니메이션 종료 확인 후 상태 전환

            yield return new WaitUntil(() => BossAnimatorEnd("G_Attack6"));

            ChangeState(AI_State.Idle);

            yield break;
            //ChangeState(AI_State.Idle);
        }
    }

    //보스 애니메이션 끝났는지 확인
    bool BossAnimatorEnd(string animatorName)
    {

        if (animator.GetCurrentAnimatorStateInfo(0).IsName(animatorName))
        {
            float normalizedTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;

            if (normalizedTime >= 0.9)
            {
                return true;
            }
        }

        return false;
    }

}

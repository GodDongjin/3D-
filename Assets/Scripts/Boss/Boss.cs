using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AI_State
{
    Idle, Move, Attack1, Attack2, Skill1, Skill2, Rigidity, Die
}

public class Boss : MonoBehaviour
{
    public static GameObject boss;

    public static Transform startPos;

    [SerializeField]
    public static AI_State state;

    public static Animator animator;

    public static float maxHp = 1000;
    public static float currentHp;
    public static float maxRigidity = 300f;
    public static float currentRigidity = maxRigidity;
    public static float glod = 1000;
    public static float damege = 10f;
    public static float moveSpeed = 3f;

    public static string nameOfThePrefab;

    public bool isEffect = false;
    public bool isChase = false;
    public bool isPlayerHit  = false;
    public bool isDie = false;


    //플레이어 한테 줄 피격판정
    public static bool isHeavyRigidity = false;
    public static bool isLightRigidity = false;

    private static int index;

    public static float distance;

    public void BossHpLose(float damege, float rigidityDamege)
    {
        currentHp = currentHp - damege;

        if(currentRigidity <= maxRigidity)
		{
            currentRigidity = currentRigidity - rigidityDamege;
        }
       
    }




}

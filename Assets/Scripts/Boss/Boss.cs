using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AI_State
{
    Idle, Move, Attack1, Attack2, Skill1, Skill2, Stiffness, Die
}

public class Boss : MonoBehaviour
{
    public static GameObject boss;
    
   
   
    [SerializeField]
    public static AI_State state;

    public static Animator animator;

    public float maxHp = 100f;
    public float currentHp;
    public static float damege = 10f;
    public static float moveSpeed = 3f;

    public static string nameOfThePrefab;

    public bool isEffect = false;
    public bool isChase = false;
    public bool isPlayerHit  = false;

    //플레이어 한테 줄 피격판정
    public static bool isHeavyRigidity = false;
    public static bool isLightRigidity = false;

    private static int index;

    public void BossHpLose(float damege)
    {
        currentHp = currentHp - damege;
        //Debug.Log(damege + "를 입었다");

    }



}

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
    public static GameObject player;
   
   
    [SerializeField]
    public static AI_State state;

    public static Animator animator;

    public static float hp;
    public static float damege;
    public static float moveSpeed = 3f;

    public static string nameOfThePrefab;

    public bool isEffect = false;

    private static int index;



}

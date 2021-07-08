using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AI_State
{
    Idle, Move, Attack1, Attack2, skill, Stiffness, Die
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
    public static float moveSpeed = 5f;


   
}

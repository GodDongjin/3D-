using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public static GameObject player;
	public static Animator animator;

	public static Vector3 movePos;
	public static Ray ray;
	static RaycastHit hit;

	public float maxHp;
	public float currentHp;
	public float moveSpeed;

	public static float attackCombo = 0f;
	public int maxLevel;
	public int currentLevel;

	public static bool isAttack = false;
	public static bool isClick = false;
	public static bool isWalk = false;


	public void MouseRotate()
	{
		if (isClick)
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out hit))
			{
				movePos = hit.point;
			}

			Vector3 direction = (movePos - player.transform.position).normalized;
			Quaternion lookRotation = Quaternion.LookRotation(direction);
			player.transform.rotation = lookRotation;
		}
		//player.transform.LookAt(player.transform.position + movePos);
		//isClick = false;
	}


}

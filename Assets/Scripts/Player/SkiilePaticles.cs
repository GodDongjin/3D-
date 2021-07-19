using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkiilePaticles : MonoBehaviour
{
	//private void OnParticleCollision(GameObject other)
	//{
	//	Debug.Log(other.name);
	//}


	private void OnTriggerEnter(Collider other)
	{
		if(other.name == "Boss")
		{
			Debug.Log("보스 스킬 맞음");
		}
	}

}

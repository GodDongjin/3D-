using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkiilePaticles : MonoBehaviour
{
	
	
	void OnParticleCollision(Collider collider)
	{
		Debug.Log(collider.name);
	}

	
}

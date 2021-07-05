using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerCtrl : MonoBehaviour
{
    Camera m_Cam;
	GameObject player;
	[SerializeField]
	Vector3 offSet;
	//PlayerInfomation p_Info;

	private void Awake()
	{
		m_Cam = gameObject.GetComponent<Camera>();
		player = GameObject.Find("Player");
		//p_Info = gameObject.GetComponent<PlayerInfomation>();
	}

	// Update is called once per frame
	void Update()
    {
		offSet.Set(0, 8, -5);
		//m_Cam.transform.position = player.transform.position + new Vector3(0, 8, -5);
		m_Cam.transform.position =
			new Vector3(player.transform.position.x + offSet.x, m_Cam.transform.position.y, player.transform.position.z + offSet.z);
		//m_Cam.transform.rotation = Quaternion.Euler(new Vector3(45, 0, 0));
	}
}

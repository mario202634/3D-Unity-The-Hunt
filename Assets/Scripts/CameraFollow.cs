using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public GameObject player;
	private Vector3 cameraoffset;
	public int x, y, z;
	void Start()
	{

	cameraoffset = new Vector3(x, y, z);
	}

	void Update()
	{
	}

	void LateUpdate()
	{
		transform.position = player.transform.position + cameraoffset;
	}
}

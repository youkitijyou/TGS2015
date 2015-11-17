using UnityEngine;
using System.Collections;

public class CockpitYawPitch : MonoBehaviour 
{

	public float speed;
	private Vector2 movement;	//角度を記憶
	private float pitch;
	private float yaw;
	// Use this for initialization
	void Start () 
	{
		pitch = 0.0f;
		yaw = 0.0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		movement.y = Input.GetAxisRaw ("Vertical") * speed * Time.deltaTime;
		movement.x = Input.GetAxisRaw ("Horizontal") * speed * Time.deltaTime;
		
		pitch -= movement.normalized.y;
		yaw += movement.normalized.x;
		
		
		if (yaw >= 120)	yaw = 120;
		else if(yaw <= -120) yaw = -120;
		
		
		if (pitch >= 60)	pitch = 60;
		else if (pitch <= -89)	pitch = -89;
		
		transform.localRotation = 
			Quaternion.Euler(pitch,
			                 yaw,
			                 transform.localRotation.z);
	}

}

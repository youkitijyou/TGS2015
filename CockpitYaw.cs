using UnityEngine;
using System.Collections;

public class CockpitYaw : MonoBehaviour {
	public float speed;
	private Vector2 movementYaw;	//角度を記憶
	private float yaw;
	// Use this for initialization
	void Start () 
	{
		yaw = 0.0f;
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		movementYaw.y = Input.GetAxisRaw ("Vertical") * speed * Time.deltaTime;
		movementYaw.x = Input.GetAxisRaw ("Horizontal") * speed * Time.deltaTime;

		yaw += movementYaw.x;

		
		if (yaw >= 90)	yaw = 90;
		else if(yaw <= -90) yaw = -90;
		

		
		transform.localRotation = 
			Quaternion.Euler(transform.localRotation.x,
			                 yaw,
			                 transform.localRotation.z);
	}
}

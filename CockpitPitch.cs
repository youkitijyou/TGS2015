using UnityEngine;
using System.Collections;

public class CockpitPitch : MonoBehaviour 
{
	public float speed;
	private Vector2 movementPitch;	//角度を記憶
	private float pitch;
	// Use this for initialization
	void Start () 
	{
		pitch = 0.0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		movementPitch.y = Input.GetAxisRaw ("Vertical") * speed * Time.deltaTime;
		movementPitch.x = Input.GetAxisRaw ("Horizontal") * speed * Time.deltaTime;
		
		pitch -= movementPitch.y;
		
		
		if (pitch >= 30)	pitch = 30;
		else if (pitch <= -90)	pitch = -90;
		
		transform.localRotation = 
			Quaternion.Euler(pitch,
			                 transform.localRotation.y,
			                 transform.localRotation.z);
	}
}

using UnityEngine;
using System.Collections;

public class Player3Yaw : MonoBehaviour {
	public float speed;
	private Vector2 movementYaw;	//角度を記憶
	private float gunYaw;
	private float cockpitYaw;
	public GameObject cockpit;
	public float gunYawLimit;
	public float cockpitYawLimit;

	// Use this for initialization
	void Start () 
	{
		gunYaw = 0.0f;
		cockpitYaw = 0.0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		movementYaw.y = Input.GetAxisRaw ("Vertical");
		movementYaw.x = Input.GetAxisRaw ("Horizontal");

		if (Input.GetAxisRaw ("Horizontal") > 0) 
		{
			if (gunYaw <= gunYawLimit) {
				AddGunYaw ();
				MoveGun ();
			} else {
				if (cockpitYaw < cockpitYawLimit)
				{
				AddCockpitYaw ();
				MoveCockpit ();
				}
			}

		}
		else{
			if (gunYaw >= -gunYawLimit) {
				AddGunYaw ();
				MoveGun ();
			} else {
				if (cockpitYaw > -cockpitYawLimit)
				{
				AddCockpitYaw ();
				MoveCockpit ();
				}
			}
		}
	}
	void MoveGun()
	{
		transform.localRotation = 
			Quaternion.Euler (transform.localRotation.x,
			                  gunYaw,
			                  transform.localRotation.z);
	}
	void MoveCockpit()
	{
		cockpit.transform.localRotation =
			Quaternion.Euler (cockpit.transform.localRotation.x,
			                  cockpitYaw,
			                  cockpit.transform.localRotation.z);
	}
	void AddGunYaw()
	{
		gunYaw += movementYaw.normalized.x * speed * Time.deltaTime;
	}
	void AddCockpitYaw()
	{
		cockpitYaw += movementYaw.normalized.x * speed * Time.deltaTime;
	}







}

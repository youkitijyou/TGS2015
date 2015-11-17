using UnityEngine;
using System.Collections;

public class Player3YaoPitch : MonoBehaviour {

	public GameObject guns;
	public GameObject gunSystem;

	private Vector2 movement;	//角度を記憶

	private float gunPitch;
	private float cockpitPitch;
	private float gunYaw;
	private float cockpitYaw;
	
	public float gunpitchLimit;
	public float cockpitpitchLimit;
	public float gunYawLimit;
	public float cockpitYawLimit;
	public float speed;


	// Use this for initialization
	void Start () {
		gunPitch = 0.0f;
		cockpitPitch = 0.0f;
		gunYaw = 0.0f;
		cockpitYaw = 0.0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		movement.y = Input.GetAxisRaw ("Vertical");
		movement.x = Input.GetAxisRaw ("Horizontal");
		
		if (Input.GetAxisRaw ("Horizontal") > 0) 
		{
			if (gunYaw <= gunYawLimit) {
				AddGunYaw ();
				MoveGunSystem ();
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
				MoveGunSystem ();
			} else {
				if (cockpitYaw > -cockpitYawLimit)
				{
					AddCockpitYaw ();
					MoveCockpit ();
				}
			}
		}
		if (Input.GetAxisRaw ("Vertical") < 0) 
		{
			if (gunPitch <= gunpitchLimit/2) {
				AddGunPitch ();
				MoveGuns ();
			} else {
				if (cockpitPitch < cockpitpitchLimit/2)
					AddCockpitPitch ();
				MoveCockpit ();
			}
			
		}
		else{
			if (gunPitch >= -gunpitchLimit) {
				AddGunPitch ();
				MoveGuns ();
			} else {
				if (cockpitPitch > -cockpitpitchLimit)
					AddCockpitPitch ();
				MoveCockpit ();
			}
		}
	}




	void MoveGunSystem()
	{
		gunSystem.transform.localRotation = 
			Quaternion.Euler (gunSystem.transform.localRotation.x,
			                  gunYaw,
			                  gunSystem.transform.localRotation.z);
	}
	void MoveCockpit()
	{
		transform.localRotation =
			Quaternion.Euler (cockpitPitch,
			                  cockpitYaw,
			                  transform.localRotation.z);
	}
	void MoveGuns()
	{
		guns.transform.localRotation = 
			Quaternion.Euler (
				gunPitch,
				guns.transform.localRotation.y,
				guns.transform.localRotation.z);
	}
	void AddGunYaw()
	{
		gunYaw += movement.x * speed * Time.deltaTime;
	}



	void AddGunPitch()
	{
		gunPitch-= movement.y * speed * Time.deltaTime;
	}

	void AddCockpitYaw()
	{
		cockpitYaw += movement.normalized.x * speed * Time.deltaTime;
	}
	void AddCockpitPitch()
	{
		cockpitPitch -= movement.normalized.y * speed * Time.deltaTime;
	}


}

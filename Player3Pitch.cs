using UnityEngine;
using System.Collections;

public class Player3Pitch : MonoBehaviour 
{
	public float speed;
	private Vector2 movementPitch;	//角度を記憶
	private float gunPitch;
	private float cockpitPitch;

	public float gunpitchLimit;
	public float cockpitpitchLimit;

	public GameObject cockpit;
	// Use this for initialization
	void Start () 
	{
		gunPitch = 0.0f;
		cockpitPitch = 0.0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		movementPitch.y = Input.GetAxisRaw ("Vertical");
		movementPitch.x = Input.GetAxisRaw ("Horizontal");



		if (Input.GetAxisRaw ("Vertical") < 0) 
		{
			if (gunPitch <= gunpitchLimit/2) {
				AddGunPitch ();
				MoveGun ();
			} else {
				if (cockpitPitch < cockpitpitchLimit/2)
				AddCockpitPitch ();
				MoveCockpit ();
			}
			
		}
		else{
			if (gunPitch >= -gunpitchLimit) {
				AddGunPitch ();
				MoveGun ();
			} else {
				if (cockpitPitch > -cockpitpitchLimit)
				AddCockpitPitch ();
				MoveCockpit ();
			}
		}

	}
	void MoveGun()
	{
		transform.localRotation = 
			Quaternion.Euler (
			                  gunPitch,
				transform.localRotation.y,
			                  transform.localRotation.z);
	}
	void MoveCockpit()
	{
		cockpit.transform.localRotation =
			Quaternion.Euler (
			                  cockpitPitch,
				cockpit.transform.localRotation.y,
				cockpit.transform.localRotation.z);
	}
	void AddGunPitch()
	{
		gunPitch-= movementPitch.normalized.y * speed * Time.deltaTime;
	}
	void AddCockpitPitch()
	{
		cockpitPitch -= movementPitch.normalized.y * speed * Time.deltaTime;
	}
}

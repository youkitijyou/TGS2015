using UnityEngine;
using System.Collections;

public class Player4YaoPitch : MonoBehaviour {

	public GameObject launchers;
	public GameObject launcherSystem;

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

	public GameObject myCamera;
	public GameObject spotLight;

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
		if (Input.GetKey (KeyCode.X)) {
			myCamera.GetComponent<Quaker>().Quake();
			spotLight.GetComponent<LightControler>().Flash();
		}

		if (MainMenu.gameStarted) {
			movement.y = Input.GetAxisRaw ("Vertical");
			movement.x = Input.GetAxisRaw ("Horizontal");
		
			if (Input.GetAxisRaw ("Horizontal") > 0) {
				if (gunYaw <= gunYawLimit) {
					AddGunYaw ();
					MoveGunSystem ();
				} else {
					if (cockpitYaw < cockpitYawLimit) {
						AddCockpitYaw ();
						MoveCockpit ();
					}
				}
			} else if (Input.GetAxisRaw ("Horizontal") < 0) {
				if (gunYaw >= -gunYawLimit) {
					AddGunYaw ();
					MoveGunSystem ();
				} else {
					if (cockpitYaw > -cockpitYawLimit) {
						AddCockpitYaw ();
						MoveCockpit ();
					}
				}
			} else {
				gunYaw = 0.0f;
			}
			if (Input.GetAxisRaw ("Vertical") < 0) {
				if (gunPitch <= gunpitchLimit / 3) {
					AddGunPitch ();
					MoveGuns ();
				} else {
					if (cockpitPitch < gunpitchLimit / 3)
						AddCockpitPitch ();
					MoveCockpit ();
				}
			
			} else {
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
	}




	void MoveGunSystem()
	{
		launcherSystem.transform.localRotation = 
			Quaternion.Euler (launcherSystem.transform.localRotation.x,
			                  gunYaw,
			                  launcherSystem.transform.localRotation.z);
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
		launchers.transform.localRotation = 
			Quaternion.Euler (
				gunPitch,
				launchers.transform.localRotation.y,
				launchers.transform.localRotation.z);
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
		cockpitYaw += movement.x * speed * Time.deltaTime;
	}
	void AddCockpitPitch()
	{
		cockpitPitch -= movement.y * speed * Time.deltaTime;
	}


}

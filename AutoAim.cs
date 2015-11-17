using UnityEngine;
using System.Collections;

public class AutoAim : MonoBehaviour {

	public float aimSpeed;
	public GameObject targetPoint;
	public GameObject cockpit;
	public GameObject leftGun;
	public GameObject rightGun;
	public GameObject leftEye;
	public GameObject rightEye;




	// Use this for initialization
	void Start () {
		transform.rotation = Quaternion.Euler (0, 0, 0);
	}

	// Update is called once per frame
	void FixedUpdate () {
	

		var targetDir = Quaternion.LookRotation(targetPoint.transform.position,cockpit.transform.up);
		float speed = aimSpeed * Time.deltaTime;
		transform.rotation =  Quaternion.RotateTowards (transform.rotation, targetDir, speed);

		leftGun.transform.rotation = Quaternion.RotateTowards (leftGun.transform.rotation, leftEye.transform.rotation, speed);
		rightGun.transform.rotation = Quaternion.RotateTowards (rightGun.transform.rotation, rightEye.transform.rotation, speed);


	}
}

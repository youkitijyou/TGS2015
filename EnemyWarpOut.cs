using UnityEngine;
using System.Collections;

public class EnemyWarpOut : MonoBehaviour {

	public float tumble;
	public float waitTime;
	private float rotateTime;
	private bool notRotate;
	public float speedZ;
	public float speedY;
	
	
	void Start ()
	{
		notRotate = true;
		rotateTime = Time.time + waitTime;
	}
	void StartRotation()
	{
		GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
		speedZ = 800.0f;
		notRotate = false;
	}
	void FixedUpdate()
	{
		transform.Translate(new Vector3(0.0f, speedY, 0.0f) * Time.deltaTime, Space.Self);
		transform.Translate (new Vector3(0.0f, 0.0f, speedZ) * Time.deltaTime, Space.World);
		if (notRotate && Time.time > rotateTime) {
			StartRotation();

		}

	}
}

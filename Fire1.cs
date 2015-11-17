using UnityEngine;
using System.Collections;

public class Fire1 : MonoBehaviour {


	
	public GameObject shot;
	public Transform shotSpawnLeft;
	public Transform shotSpawnRight;
	public float fireRate;
	
	private float nextFire;
	
	void Update()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawnLeft.position, shotSpawnLeft.rotation);
			Instantiate(shot, shotSpawnRight.position, shotSpawnLeft.rotation);
			GetComponent<AudioSource>().Play();


		}
	}
}

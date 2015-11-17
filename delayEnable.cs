using UnityEngine;
using System.Collections;

public class delayEnable : MonoBehaviour {

	public float delayTime;
	public GameObject enemyModel;
	public GameObject warpEffect;

	private float awakeTime;
	private bool active;
	private bool warp;
	// Use this for initialization
	void Start () {
		active = true;
		warp = true;
		awakeTime = Time.time + delayTime;
	}
	void OnEnable ()
	{
		awakeTime = Time.time + delayTime;
		active = true;
		warp = true;
		enemyModel.SetActive(false);
		GetComponent<SphereCollider>().enabled = false;
	}
	// Update is called once per frame
	void Update () 
	{

		if (active) {
			if (warp) {
				Instantiate (warpEffect,transform.position, Quaternion.Euler(0,0,0));
				warp = false;
			}
			if (Time.time > awakeTime) {
				enemyModel.SetActive(true);
				GetComponent<SphereCollider>().enabled = true;
				active = false;
			}
		}
	}
}

using UnityEngine;
using System.Collections;

public class EnemyAnimation : MonoBehaviour {

	public float time;

	// Use this for initialization
	void Start () {
	
		GetComponent<Animator> ().SetBool ("moveFlag", true);
		GetComponent<Animator> ().SetBool ("attackFlag", false);
		GetComponent<Animator> ().SetBool ("knockBackFlag", false);
	}
	
	// Update is called once per frame
	void Update () {
	
		if (GetComponent<Animator> ().GetBool ("knockBackFlag")) {
			if (--time < 0) {

				time = 60;
				GetComponent<Animator> ().SetBool ("knockBackFlag", false);
				GetComponent<Animator> ().SetBool ("moveFlag", true);
			}
		}
	}
}

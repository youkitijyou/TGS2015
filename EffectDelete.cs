using UnityEngine;
using System.Collections;

public class EffectDelete : MonoBehaviour {

	public GameObject spawnObj;

	private AddMaterialsColor mat;

	// Use this for initialization
	void Start () {
		mat = GetComponent<AddMaterialsColor> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (mat.checkMax ()) {
			gameObject.SetActive(false);
			spawnObj.SetActive (true);
		}
	}
}

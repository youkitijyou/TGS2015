using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	public Transform prefab;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			prefab.position += new Vector3(0, 1, 0);
		}

		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			prefab.position -= new Vector3(0, 1, 0);
		}

		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			prefab.position -= new Vector3(1, 0, 0);
		}

		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			prefab.position += new Vector3(1, 0, 0);
		}
	}
}

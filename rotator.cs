using UnityEngine;
using System.Collections;

public class rotator : MonoBehaviour {

	public float speed;		//回転スピード
	private float degree;	//角度を内部で保存

	// Use this for initialization
	void Start () {
		//degree = 0.0f;
	}

	// Update is called once per frame
	void FixedUpdate () {
	
		//GameObject parent = gameObject.transform.parent.gameObject;

		//左に回す
		//if(Input.GetKey(KeyCode.LeftArrow)){
		if(Input.GetKey(KeyCode.Z)){
			degree += speed;
		}

		//右に回す
		//if (Input.GetKey (KeyCode.RightArrow)) {
		if(Input.GetKey(KeyCode.X)){
			degree -= speed;
		}

		//回転処理
		transform.localRotation = 
			Quaternion.Euler(transform.rotation.x,transform.rotation.y,degree);
	}
}

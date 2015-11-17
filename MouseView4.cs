using UnityEngine;
using System.Collections;

public class MouseView4 : MonoBehaviour {
	
	public float mouseResponse;
	public Transform cameraPos;
	
	//private Vector3 nowMouse;		//現マウス座標
	//private Vector3 beforeMouse;	//1フレーム前マウス座標
	
	private Vector2 rotate;	//角度を記憶
	private float yaw;
	private float pitch;
	
	// Use this for initialization
	void Start () {
		//beforeMouse = Input.mousePosition;
		//nowMouse = Input.mousePosition;
		yaw = 0.0f;
		pitch = 0.0f;
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		//マウス座標取得
		//nowMouse = Input.mousePosition;
		
		//マウス座標の差分を回転量にする
		float movementX = Input.GetAxisRaw ("ViewX");
		float movementY = Input.GetAxisRaw ("ViewY");
		//beforeMouse = nowMouse;	//旧座標書き換え
		
		
		
		//回転処理
		yaw += movementX * mouseResponse*Time.deltaTime;
		if (yaw >= 90) {
			yaw = 90;
		} 
		else if (yaw <= -90) {
			yaw = -90;
		}
		
		
		pitch -= movementY * mouseResponse*Time.deltaTime;
		if (pitch >= 90) {
			pitch = 90;
		}
		else if(pitch <= -90){
			pitch = -90;
		}
		
		transform.localRotation = 
			Quaternion.Euler(pitch,
			                 yaw,
			                 transform.localRotation.z);
	}
}

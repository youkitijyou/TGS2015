using UnityEngine;
using System.Collections;

public class ScreenLight : MonoBehaviour {
	
	public float max;
	public GameObject[] lights = new GameObject[4];
	public GameObject startPanel;
	
	private bool insight;
	private int iterator;
	
	public GameObject[] animObj = new GameObject[2];
	public GameObject manager;
	public GameObject panelLeft;
	public GameObject rollbase;
	
	// Use this for initialization
	void Start () {
		for (int i = 0; i < lights.Length; ++i) {
			lights[i].GetComponent<Renderer>().material.color = new Color(255,0,0,0);
			
		}
		iterator = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		//駆動テスト KeyFで
		//if (Input.GetKey (KeyCode.F)) {
		//	InSight ();
		//} else {
		//	NotSight();
		//}
		
		float speed = 0.014f;
		
		if (insight) {
			if(iterator == 0) speed = 0.75f;
			lights [iterator].GetComponent<Renderer> ().material.color += new Color (0f, 0f, 0f, speed);
			if (lights [iterator].GetComponent<Renderer> ().material.color.a >= 0.75f) {
				iterator++;
			}
		} else {
			if (lights [iterator].GetComponent<Renderer> ().material.color.a <= 0f) {
				if(iterator > 0) iterator--;
			} else {
				lights [iterator].GetComponent<Renderer> ().material.color -= new Color (0f, 0f, 0f, speed);
			}
		}
		
		
		//ゲージがいっぱいになった時の処理
		if (iterator >= 4) {
			this.enabled = false;
			animObj[0].GetComponent<Animation>().StartAnimation();
			animObj[0].GetComponent<SESelecter>().DelaySE(36.0f);
			animObj[1].GetComponent<Animation>().StartAnimation();
			animObj[1].GetComponent<SESelecter>().DelayStopSE(35.0f);
			rollbase.GetComponent<RollingCockpit>().enabled = true;
			manager.GetComponent<MainMenu>().Test();
			panelLeft.GetComponent<Collider>().enabled=false;
			GetComponent<LookAtMenu>().enabled=false;
			startPanel.SetActive(false);
			Destroy (this);
		}
		
	}
	
	//視界に入っている　ゲージが増加するようになる
	public void InSight()
	{
		insight = true;
	}
	
	//視界に入っていない　ゲージが減少するようになる
	public void NotSight()
	{
		insight = false;
	}
}

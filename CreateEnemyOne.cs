using UnityEngine;
using System.Collections;

public class CreateEnemyOne : MonoBehaviour 
{
	public float timerEmy;
	public GameObject enemyOne;
	public Transform[] enemyOneTF=new Transform[30];
	public GameObject enemyOneIndicatorPrefab;

	//private GameObject enemyOne;
	private GameObject enemyOneIndicator;
	private GameObject[] enemyOneindicatorTF = new GameObject[30];
	private float nextEmy;
	private float nextEmyOnce;
	private bool active;
	public int num;
	private bool warpSw;

	void Start()
	{
		active = false;
		num = 0;
		for (int i=0; i<enemyOneTF.Length; i++) 
		{
			GameObject temp=Instantiate (enemyOne, new Vector3 (0.0f, 0.0f, 1000.0f), Quaternion.identity) as GameObject;
			enemyOneTF[i] = temp.transform;
			enemyOneTF[i].gameObject.SetActive(false);

			enemyOneindicatorTF[i] = Instantiate (enemyOneIndicatorPrefab, new Vector3 (enemyOneTF[i].position.x, enemyOneTF[i].position.y, enemyOneTF[i].position.z), Quaternion.identity) as GameObject;
			enemyOneindicatorTF[i].transform.parent = enemyOneTF[i];
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*
		if (Time.time > nextEmy) {
			nextEmy = Time.time + timerEmy;
			active = true;
		}
		if (active) {
			{
				if (num < 15) {
					int i = 0;
					do {
						enemyOneTF [num].gameObject.SetActive (true);
						num++;
						i++;
					} while(i<15);
				} else {
					int i = 0;
					do {
						enemyOneTF [i].gameObject.SetActive (true);
						num++;
						i++;
					} while(i<30);
				}
			}
			active = false;
		}
		*/
	}

	public void EnableEnemy(int num){

		int count = 0;

		for (int i = 0; i < enemyOneTF.Length; ++i) {

			if(enemyOneTF[i].gameObject.activeSelf) continue;

			enemyOneTF [i].gameObject.SetActive (true);
			++count;
			if(count >= num) break;
		}
	}
	public void warpCreate(bool sw){
		
		warpSw = sw;
	}
}

using UnityEngine;
using System.Collections;

public class CreateEnemyTwo : MonoBehaviour 
{
	public float timerEmy;
	public GameObject enemyTwo;
	public Transform[] enemyTwoTF = new Transform[10];
	//public GameObject enemyTwoIndicatorPrefab;
	
	//private GameObject enemyTwo;
	//private GameObject enemyTwoIndicator;
	//private GameObject[] enemyTwoIndicatorTF = new GameObject[10];
	private float nextEmy;
	private float nextEmyOnce;
	private bool active;
	public int num;
	
	void Start()
	{
		active = false;
		num = 0;
		for (int i=0; i < enemyTwoTF.Length; i++) 
		{
			GameObject temp=Instantiate (enemyTwo, new Vector3 (0.0f, 0.0f, 300.0f), Quaternion.identity) as GameObject;
			enemyTwoTF[i] = temp.transform;
			enemyTwoTF[i].gameObject.SetActive(false);
			enemyTwoTF[i].transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);

			//enemyTwoIndicatorTF[i] = Instantiate (enemyTwoIndicatorPrefab, new Vector3 (enemyTwoTF[i].position.x, enemyTwoTF[i].position.y, enemyTwoTF[i].position.z), Quaternion.identity) as GameObject;
			//enemyTwoIndicatorTF[i].transform.parent = enemyTwoTF[i];
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Time.time > nextEmy) {
			nextEmy = Time.time + timerEmy;
			active = true;
		}
		if (active) {
			{

				//enemyTwoTF [num].gameObject.SetActive (true);
				if (num <= 10) {
					int i = 0;
					do {
						enemyTwoTF [num].gameObject.SetActive (true);
						num++;
						i++;
					} while(i<1);
				} 
			}
			active = false;
		}
	}
}

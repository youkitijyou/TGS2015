using UnityEngine;
using System.Collections;

public class RollingCockpit : MonoBehaviour 
{

	public float speed;
	public float maxSpeed;
	private float addDegree;
	private float rollDgree;

	SESelecter rollSE;
	
	void Start () 
	{
		//rollDgree = 0.0f;
		rollSE = GetComponent<SESelecter> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		//左に加算
		if(Input.GetButton("RollL")){
			addDegree += speed;
			if(addDegree >= maxSpeed) addDegree = maxSpeed;
			rollSE.SE2();

		//右に加算
		}else if(Input.GetButton("RollR")){
			addDegree -= speed;
			if(addDegree <= -maxSpeed) addDegree = -maxSpeed;
			rollSE.SE2();
		}

		//減速
		else{
			addDegree *= 0.85f;

			//停止
			if(addDegree <= 0.5f && addDegree >= -0.5f){
				addDegree = 0f;
				rollSE.Stop ();
			}
		}

		rollDgree += addDegree;
		if (rollDgree + addDegree > 360f) rollDgree = 0f;
		if (rollDgree + addDegree < 0f) rollDgree = 360f;


		transform.localRotation = 
			Quaternion.Euler (transform.rotation.x, transform.rotation.y, rollDgree);
	}

	public float RollDegree()
	{
		return rollDgree;
	}
}

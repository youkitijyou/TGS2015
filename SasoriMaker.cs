using UnityEngine;
using System.Collections;

public class SasoriMaker : MonoBehaviour {
	
	public GameObject SasoriBase;
	public GameObject[] sasoris = new GameObject[10];
	// Use this for initialization
	void Start () {
		
		//インスタンス化
		for (int i = 0; i<sasoris.Length; ++i) {
			GameObject temp = Instantiate<GameObject>(SasoriBase);
			sasoris[i] = temp;
			sasoris[i].SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		//生成テスト　KeyRで
	}
	
	void init(int i)
	{
		sasoris [i].SetActive (true);
		sasoris[i].transform.position = new Vector3(0f,0f,Random.Range(10f,35f));
		sasoris[i].transform.rotation = Quaternion.Euler(0f,0f,Random.Range(0,359));
		sasoris [i].transform.FindChild ("eff_sasori").gameObject.SetActive (true);
		sasoris [i].transform.FindChild ("Sasori").gameObject.SetActive (false);
	}
	
	public void spawn(int roop)
	{
		for (int h = 0; h < roop; ++h) {
			for (int i = 0; i<sasoris.Length; ++i) {
				if(sasoris[i].transform.FindChild("eff_sasori").gameObject.activeSelf == true ||
				   sasoris[i].transform.FindChild("Sasori").gameObject.activeSelf == true) continue;
				
				init (i);
				break;	//ひとつ出現で終了
			}
		}
	}
}

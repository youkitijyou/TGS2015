using UnityEngine;
using System.Collections;

//カウンタークラス　ご自由にお使いください
public class Counter
{
	private int count_;
	private int max_;

	//初期のカウント値と,限界値を指定.
	public Counter(int count,int max)
	{
		count_ = count;
		max_ = max;
	}

	//リセット　カウンターを0に戻します
	public void reset()
	{
		count_ = 0;
	}

	//現在のカウント値を獲得
	public int get()
	{
		return count_;
	}

	public bool forword()
	{
		if (++count_ > max_) {
			reset();
			return true;
		}
		return false;
	}
}

public class SasoriMove : MonoBehaviour {

	private Animator anim;	//アニメーターへアタッチ
	
	//アニメーションのID記憶用
	private int randing;
	private int walk;
	private int attack;
	
	//攻撃間隔の制御用
	private Counter controlCnt;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

		controlCnt = new Counter (0, 120);

		randing = Animator.StringToHash("randing");
		walk = Animator.StringToHash ("walk");
		attack = Animator.StringToHash("attack");

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		//現在のstateに応じた処理
		if (CheckState ("Fly"))	Fly ();
		else if (CheckState ("Randing")) Randing ();
		else if (CheckState ("Walk")) Walk ();
		else if (CheckState ("Attack")) DoAttack ();
	}

	//飛来中の処理
	void Fly()
	{
		GameObject randingPoint = GameObject.Find ("RandingPoint");

		//着地点までの移動量を求める
		Vector3 add = Vector3.MoveTowards (this.transform.position, randingPoint.transform.position,
		                                   8f * Time.deltaTime);
		transform.position = add;

		if(Vector3.Distance(this.transform.position,randingPoint.transform.position) <= 4.0f){
			anim.SetBool(randing,true);
		}
	}

	//着地時の処理
	void Randing()
	{
		/*特にない　アニメ一巡で自動的にWalkに移ります*/
	}

	//歩行中の処理
	void Walk()
	{

		if (controlCnt.forword () || transform.position.z <= 50.0f) {
			anim.SetTrigger(attack);
			return;
		}

		Vector3 addForce = new Vector3 (0f, 0f, -2f * Time.deltaTime);
		transform.position += addForce;

	}

	//攻撃中の処理
	void DoAttack()
	{

	}
	
	//現在のstateが渡したstateと等しいか判定
	bool CheckState(string state)
	{
		//現在のstateを獲得
		AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo (0);

		return info.shortNameHash == Animator.StringToHash (state);
	}
}

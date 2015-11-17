using UnityEngine;
using System.Collections;

public class AddMaterialsColor : MonoBehaviour {

	public float addAlpha;

	private Renderer render;
	private float alpha;
	// Use this for initialization
	void Start () {
		alpha = 0f;
		render = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Color c = render.material.GetColor("_TintColor");
		alpha += addAlpha;

		render.material.SetColor("_TintColor",new Color(c.r,c.g,c.b,alpha));
	}

	public bool checkMax()
	{
		if (alpha + addAlpha > 255f) {
			alpha = 0f;
			return true;
		} else
			return false;
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StarBar : MonoBehaviour {

	private float _value =1f;
	// Use this for initialization
	public List<UISprite> sprites = new List<UISprite>();
	void Start () {
		bool starFound = true;
		int c = 1;
		while(starFound) {
			Transform t =this.transform.FindChild("Star"+c);
			if(t!=null) {
				sprites.Add(t.gameObject.GetComponent<UISprite>());
			} else {
				starFound = false;
			}
			c++;
		}
	}
	public float value {
		get {
			return _value;
		}
		set {
			_value = value;
			float dividedAmount = 1f/sprites.Count;
			float c = dividedAmount;
			for(int i = 1;i<sprites.Count;i++) {
				sprites[i].enabled = _value>c;
				c+= dividedAmount;
			}
	
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}

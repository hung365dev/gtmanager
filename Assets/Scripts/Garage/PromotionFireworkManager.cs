using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PromotionFireworkManager : MonoBehaviour {

	public List<GameObject> fireworks = new List<GameObject>();
	public float timeBetweenFireworks;
	// Use this for initialization
	void Start () {
		StartCoroutine(doFireworks());
	}
	
	public IEnumerator doFireworks() {
		yield return new WaitForSeconds(5f);
		for(int i = 0;i<fireworks.Count;i++) {
			fireworks[i].gameObject.SetActive(true);
			yield return new WaitForSeconds(timeBetweenFireworks);
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}

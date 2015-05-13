using UnityEngine;
using System.Collections;

public class GarageCameraController : MonoBehaviour {

	public GameObject lookAtThis;
	public Vector3 eulerAngleVelocity = new Vector3(0f,50f,0f);
	public float desiredFieldOfView = 40f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Camera cam = this.GetComponent<Camera>();
		if(this.GetComponent<SmoothLookAt>()!=null&&lookAtThis!=null) {
			this.GetComponent<SmoothLookAt>().target = lookAtThis.gameObject.transform;

			if(cam.fieldOfView>desiredFieldOfView) {
				cam.fieldOfView--;
			}
		}
		else
		if(cam.fieldOfView<desiredFieldOfView-5f) {
			cam.fieldOfView++;
		}
	}

}

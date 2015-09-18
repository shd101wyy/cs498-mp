using UnityEngine;
using System.Collections;

// https://developer.oculus.com/doc/0.6.0.0-unity/annotated.html

public class CameraFlipper : MonoBehaviour {

	private Camera cam;

	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F)) {
			cam.transform.rotation *= Quaternion.Euler(0, 180, 0);
		}
	}
}

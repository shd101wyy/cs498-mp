using UnityEngine;
using System.Collections;

public class VRMirror : MonoBehaviour {

	private int pressCount;
	private GameObject centerEye;
	private Vector3 originalPosition;
	// Use this for initialization
	void Start () {
		pressCount = 0;
		centerEye = GameObject.Find ("CenterEyeAnchor");
		originalPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.M)) {
			pressCount += 1;
		}


		if (pressCount == 1) {        // same
			transform.rotation = centerEye.transform.rotation * Quaternion.Euler(0, -90, 0);
			transform.position = centerEye.transform.position + originalPosition;
		} else if (pressCount > 1) {  // mirror
			transform.rotation = (new Quaternion(-centerEye.transform.rotation.x, -centerEye.transform.rotation.y, centerEye.transform.rotation.z, centerEye.transform.rotation.w)) * Quaternion.Euler(0, 90, 0);
			transform.position = - centerEye.transform.position + originalPosition;
		}
	}
}

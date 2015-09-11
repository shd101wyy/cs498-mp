using UnityEngine;
using System.Collections;

public class Lightswitch : MonoBehaviour {
	private bool pointLightOn;
	private Light pointLight;

	// Use this for initialization
	void Start () {
		pointLightOn = true;
		pointLight = GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			pointLightOn = !pointLightOn;
			pointLight.enabled = pointLightOn;	
		}
	}
}

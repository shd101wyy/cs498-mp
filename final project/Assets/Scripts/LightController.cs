using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour {
	
	private float timeOn;
	private float timeOff;
	private float changeTime;
	private bool lightEnabled;
	private Light lt;
	private Color alertColor;
	private bool isAlerting;
	
	// Use this for initialization
	void Start () {
		changeTime = 0;
		timeOn = 0.1f;
		timeOff = 0.5f;
		lightEnabled = true;
		lt = GetComponent<Light> ();
		isAlerting = false;

		alertColor = new Color (211.0f/255.0f, 56.0f/255.0f, 18.0f/255.0f);
	}

	public void startAlert() {
		lt.color = alertColor;
		isAlerting = true;
	}

	// Update is called once per frame
	void Update () {
		if (isAlerting) {
			if (Time.time > changeTime) {
				lightEnabled = !(lightEnabled);
				if (lightEnabled) {
					lt.intensity = 2.0f;
					changeTime = Time.time + timeOn;
				} else {
					lt.intensity = 1.0f;
					changeTime = Time.time + timeOff;
				}
			
			}
		}
	}
}

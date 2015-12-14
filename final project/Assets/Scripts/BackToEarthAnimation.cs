using UnityEngine;
using System.Collections;

public class BackToEarthAnimation : MonoBehaviour {

	public Material earthSkybox;
	private GameObject cloud;

	// Use this for initialization
	void Start () {
		cloud = GameObject.Find ("CloudsToy Mngr");
		cloud.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void enableCloud() {
		cloud.SetActive (true);
	}

	void ChangeSkyBox() {
		Debug.Log ("Change Skybox");
		RenderSettings.skybox = earthSkybox;
	}
}

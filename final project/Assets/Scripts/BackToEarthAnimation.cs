using UnityEngine;
using System.Collections;

public class BackToEarthAnimation : MonoBehaviour {

	public Material farEarthSkybox;
	public Material nearEarthSkybox;
	public Material earthSkybox;

	private GameObject rain;
	private GameObject cloud;
	private GameObject particles;
	private Camera cam;

	// Use this for initialization
	void Start () {
		Debug.Log ("Game Starts");
		
		cloud = GameObject.Find ("CloudsToy Mngr");
		cloud.SetActive (false);
	
		particles = GameObject.Find ("particles");
		particles.SetActive (false);
	
		cam = Camera.main;

		rain = GameObject.Find ("RainPrefab");
		rain.SetActive (false);

		RenderSettings.skybox = farEarthSkybox;
	}
	
	// Update is called once per frame
	void Update () {
		// this.transform.Rotate (Vector2.up, 2f, Space.Self); // for debug
		particles.transform.up = new Vector3 (0, 1, 0).normalized;
	}

	void enableRain() {
		rain.SetActive (true);
	}

	void disableRain() {
		rain.SetActive (false);
	}

	void enableCloud() {
		cloud.SetActive (true);
	}

	void enableParticles() {
		particles.SetActive (true);
	}

	void disableParticles() {
		particles.SetActive (false);
	}

	void useNearEarthSkybox() {
		RenderSettings.skybox = nearEarthSkybox;
	}

	void ChangeSkyBox() {
		Debug.Log ("Change Skybox");
		RenderSettings.skybox = earthSkybox;
	}
}

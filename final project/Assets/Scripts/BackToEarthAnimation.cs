using UnityEngine;
using System.Collections;

public class BackToEarthAnimation : MonoBehaviour {

	public Material farEarthSkybox;
	public Material nearEarthSkybox;
	public Material earthSkybox;
	private GameObject cloud;
	private GameObject particles;
	private Camera cam;

	// Use this for initialization
	void Start () {
		cloud = GameObject.Find ("CloudsToy Mngr");
		cloud.SetActive (false);
	
		particles = GameObject.Find ("particles");
		particles.SetActive (false);
	
		cam = Camera.main;

		RenderSettings.skybox = farEarthSkybox;
	}
	
	// Update is called once per frame
	void Update () {
		// this.transform.Rotate (Vector2.right, 2f, Space.Self);
		particles.transform.eulerAngles = new Vector3(0, 0, 0); // paricle not rotate
		particles.transform.position = cam.transform.position + new Vector3(0, -2, 0);
	}

	void enableCloud() {
		cloud.SetActive (true);
	}

	void enableParticles() {
		Debug.Log ("enable particles");
		particles.SetActive (true);
	}

	void useNearEarthSkybox() {
		RenderSettings.skybox = nearEarthSkybox;
	}

	void ChangeSkyBox() {
		Debug.Log ("Change Skybox");
		RenderSettings.skybox = earthSkybox;
	}
}

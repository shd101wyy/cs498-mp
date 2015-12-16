using UnityEngine;
using System.Collections;
using System.Linq;

public class BackToEarthAnimation : MonoBehaviour {

	public Material farEarthSkybox;
	public Material nearEarthSkybox;
	public Material earthSkybox;

	private GameObject rain;
	private GameObject cloud;
	private GameObject particles;
	private Camera cam;
	private AudioSource engineSound;
	private GameObject fireInCapsule;

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

		engineSound = GameObject.Find ("Engine_Sound").GetComponent<AudioSource> ();

		fireInCapsule = GameObject.Find ("fire in capsule");
		fireInCapsule.SetActive (false);

		RenderSettings.skybox = farEarthSkybox;
	}
	
	// Update is called once per frame
	void Update () {
		// this.transform.Rotate (Vector2.up, 2f, Space.Self); // for debug
		particles.transform.up = new Vector3 (0, 1, 0).normalized;
	}

	void startEngine() {
		engineSound.Play ();
	}

	void stopEngine() {
		engineSound.Stop ();
	}

	void enableGravity() {
		GameObject.Find ("pencil").GetComponent<Rigidbody> ().useGravity = true;
		GameObject.Find ("ping pong").GetComponent<Rigidbody> ().useGravity = true;
		GameObject.Find ("knife").GetComponent<Rigidbody> ().useGravity = true;
		GameObject.Find ("animal_1").GetComponent<Rigidbody> ().useGravity = true;
		GameObject.Find ("animal_2").GetComponent<Rigidbody> ().useGravity = true;
		GameObject.Find ("animal_4").GetComponent<Rigidbody> ().useGravity = true;
		GameObject.Find ("animal_7").GetComponent<Rigidbody> ().useGravity = true;
		
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

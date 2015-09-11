using UnityEngine;
using System.Collections;

public class ProximityDimmer : MonoBehaviour {
	GameObject player; 
	GameObject pointLight;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("OVRPlayerController");
		pointLight = GameObject.Find ("pointLight");
	}

	float calculateDistance(Vector3 position1, Vector3 position2) {
		return Mathf.Sqrt (Mathf.Pow (position1.x - position2.x, 2) + 
		                   Mathf.Pow (position1.z - position2.z, 2));
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 playerPosition = player.transform.position;
		Vector3 pointLightPosition = pointLight.transform.position;
		float distance = calculateDistance (playerPosition, pointLightPosition);
		// Debug.Log ("Distance: " + distance);

		Light light = pointLight.GetComponent<Light>();
		light.intensity = 5 - Mathf.Pow (distance / 2, 2);
		// Debug.Log ("intensity: " + light.intensity);

		if (Input.GetKey ("escape")) {
			Application.Quit ();
		}
	}
}

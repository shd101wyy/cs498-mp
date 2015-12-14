using UnityEngine;
using System.Collections;

public class AirFlow : MonoBehaviour {
	private float speed = 0.4f;
	private float rotationSpeed = 0.5f;
	private GameObject player = null;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey( KeyCode.S )) {
			// Debug.Log ("Pitch Up");
			player.transform.Rotate(-rotationSpeed, 0, 0, Space.Self);
			
		}

		if (Input.GetKey(KeyCode.W)) {
			//Debug.Log ("Pitch Down");
			player.transform.Rotate(rotationSpeed, 0, 0, Space.Self);
		}

		if (Input.GetKey(KeyCode.A)) {
			// Debug.Log ("Roll Left");
			player.transform.Rotate(0, 0, rotationSpeed, Space.Self);
		}

		if (Input.GetKey(KeyCode.D)) {
			// Debug.Log ("Roll Right");
			player.transform.Rotate(0, 0, -rotationSpeed, Space.Self);
		}

		if(Input.GetKey(KeyCode.Y)){
			speed += 0.01f;
		}

		if(Input.GetKey(KeyCode.H)){
			speed = 0.0f;
		}

		if(Input.GetKey(KeyCode.U)){
			if (speed != 0.0f) {
				speed -= 0.01f;
			}
		}

		// move forward
		player.transform.Translate (0, 0, speed);

	}
}

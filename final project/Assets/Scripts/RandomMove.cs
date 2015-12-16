using UnityEngine;
using System.Collections;

public class RandomMove : MonoBehaviour {
	private Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		rigidBody.AddForce (new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1)).normalized * 0.3f, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {

	}
}

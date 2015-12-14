using UnityEngine;
using System.Collections;

public class SpaceCapsuleController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Random.insideUnitSphere * 5;
	}
}

using UnityEngine;
using System.Collections;

public class GenerateStimuli : MonoBehaviour {

	private GameObject small;
	private GameObject medium;
	private GameObject large;


	// Use this for initialization
	void Start () {
		small = GameObject.Find ("Small");
		medium = GameObject.Find ("Medium");
		large = GameObject.Find ("Large");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.S)) {
			small.SetActive(false);
			medium.SetActive(false);
			large.SetActive(false);
		}
	}
}

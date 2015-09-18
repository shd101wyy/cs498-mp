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

	IEnumerator wait() {
		small.SetActive(false);
		medium.SetActive(false);
		large.SetActive(false);

		small.transform.localPosition = new Vector3(0.0f, 0.0f, 2.0f);
		medium.transform.localPosition = new Vector3(0.0f, 0.0f, 4.0f);
		large.transform.localPosition = new Vector3(0.0f, 0.0f, 8.0f);

		// yield return new WaitForSeconds(3);
		
		int displayNum = 0;
		while (displayNum != 3) {
			int num = (int)Random.Range(0, 3);
			GameObject obj = null; 

			if (num == 0) {
				obj = small;
			} else if (num == 1) {
				obj = medium;
			} else {
				obj = large;
			}

			if (!obj.activeSelf) {
				displayNum++;
				if (displayNum == 1) {
					obj.transform.RotateAround(Vector3.zero, small.transform.up, -20);
				} else if (displayNum == 3) {
					obj.transform.RotateAround(Vector3.zero, large.transform.up, 20);
				}
				yield return new WaitForSeconds(3);
				obj.SetActive(true);
			} 
		}
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.S)) {
			/*
			small.SetActive(false);
			medium.SetActive(false);
			large.SetActive(false);
			*/
			transform.position = Vector3.zero;
			transform.rotation = GameObject.Find ("CenterEyeAnchor").transform.rotation;
			// transform.position += new Vector3(0, 0, -2);

			StartCoroutine(wait());

		}
	}
}

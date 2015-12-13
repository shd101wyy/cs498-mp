using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshCollider))]

public class NumberButtonClick : MonoBehaviour {
	public Material activeButton;
	public Material inactiveButton;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*
	void OnMouseEnter() {
		Debug.Log ("Enter");
	}
	*/

	void OnMouseDown() {
		Debug.Log ("Clicked" + this.name);
		if (this.name == "NB_R") { // reset all buttons
			GameObject.Find("NB_0").GetComponent<Renderer>().material = inactiveButton;
			GameObject.Find("NB_1").GetComponent<Renderer>().material = inactiveButton;
			GameObject.Find("NB_2").GetComponent<Renderer>().material = inactiveButton;
			GameObject.Find("NB_3").GetComponent<Renderer>().material = inactiveButton;
			GameObject.Find("NB_4").GetComponent<Renderer>().material = inactiveButton;
			GameObject.Find("NB_5").GetComponent<Renderer>().material = inactiveButton;
			GameObject.Find("NB_6").GetComponent<Renderer>().material = inactiveButton;
			GameObject.Find("NB_7").GetComponent<Renderer>().material = inactiveButton;
			GameObject.Find("NB_8").GetComponent<Renderer>().material = inactiveButton;
			GameObject.Find("NB_9").GetComponent<Renderer>().material = inactiveButton;
		} else if (this.name == "NB_ENTER") {
			// 1, 2, 4, 7
		} else {
			if (this.GetComponent<Renderer> ().material.ToString() == "Inactive_Button (Instance) (UnityEngine.Material)") {
				this.GetComponent<Renderer> ().material = activeButton;
				
			} else {
				this.GetComponent<Renderer> ().material = inactiveButton;
			}
		}
	}
}

using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour {

	GameObject spaceStation;

	// Use this for initialization
	void Start () {
		Debug.Log ("Game Start");
		spaceStation = GameObject.Find("SpaceStation");		
	}
	
	// Update is called once per frame
	void Update () {
		spaceStation.transform.Rotate (0, 0, 0.5f);
		spaceStation.transform.Translate (0.0001f, 0, 0.005f);
	}
}

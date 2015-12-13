using UnityEngine;
using System.Collections;

public class RandomMove : MonoBehaviour {
	private float moveX;
	private float moveY;
	private float moveZ;

	// Use this for initialization
	void Start () {
		moveX = Random.Range (-0.001f, 0.001f);
		moveY = Random.Range (0.000f, 0.0001f);
		moveZ = Random.Range (-0.001f, 0.001f);
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate (moveX, moveY, moveZ);
	}
}

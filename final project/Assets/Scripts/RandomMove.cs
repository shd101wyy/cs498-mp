using UnityEngine;
using System.Collections;

public class RandomMove : MonoBehaviour {
	private float moveX;
	private float moveY;
	private float moveZ;

	private float originalX;
	private float originalY;
	private float originalZ;

	// Use this for initialization
	void Start () {
		moveX = 0.001f;
		moveY = 0.001f;
		moveZ = 0.001f;
	
		originalX = this.transform.localPosition.x;
		originalY = this.transform.localPosition.y;
		originalZ = this.transform.localPosition.z;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Mathf.Abs (this.transform.localPosition.x - originalX) > 0.5) {
			moveX = -moveX;
		}

		
		if (Mathf.Abs (this.transform.localPosition.y - originalY) > 0.5) {
			moveY = -moveY;
		}


		
		if (Mathf.Abs (this.transform.localPosition.z - originalZ) > 0.5) {
			moveZ = -moveZ;
		}


		this.transform.Translate (new Vector3(moveX, moveY, moveZ), Space.Self);
	}
}

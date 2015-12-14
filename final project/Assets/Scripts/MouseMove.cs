﻿using UnityEngine;
using System.Collections;

public class MouseMove : MonoBehaviour {

	private Vector3 screenPoint;
	private Vector3 offset = new Vector3(0, 0, 0);
	private bool _objectSelected = false;
	private GameObject cursor;
	private bool collideOtherObject;
	
	void Start() {
		cursor = GameObject.Find ("Cursor");
		collideOtherObject = false;
	}

	void MouseScrollWheel() {
    }

	void Update() {

		// set camera position
		if(_objectSelected  && collideOtherObject == false ) { // private bool to determine when an object is selected
			if(Input.GetAxis("Mouse ScrollWheel") != 0.0f) { // check if the user is moving the mouse wheel
				// play with the constant, its the amount to move per mouse wheel movement
				float amountToMove = Input.GetAxis("Mouse ScrollWheel");
				// depending on the orientation of the object you may need to use something other then a Vector3.forward
				offset += (cursor.transform.position - Camera.main.transform.position ) * amountToMove * 0.5f; // translate the amountToMove to a vector3
			}
		}
	}

	void OnCollisionEnter(Collision collision) {
		collideOtherObject = true;
	}

	void OnCollisionExit() {
		collideOtherObject = false;
	}

	void OnMouseEnter() {
	}

	void OnMouseExit() {
	}
	
	void OnMouseDown() {
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = new Vector3 (0, 0, 0);
		_objectSelected = false;
	}
	
	void OnMouseDrag() {
		// Debug.Log ("Drag " + this.name);
		_objectSelected = true;
		Vector3 curScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint) + offset;
		transform.position = curPosition + offset;
	}

}
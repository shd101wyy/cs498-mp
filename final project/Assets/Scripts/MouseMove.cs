using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshCollider))]

public class MouseMove : MonoBehaviour {

	private Vector3 screenPoint;
	private Vector3 offset = new Vector3(0, 0, 0);
	private bool _objectSelected = false;
	private Color tempColor;

	void MouseScrollWheel() {
		Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
    }

	void Update() {

		// set camera position
		if(_objectSelected) { // private bool to determine when an object is selected
			if(Input.GetAxis("Mouse ScrollWheel") != 0.0f) { // check if the user is moving the mouse wheel
				// play with the constant, its the amount to move per mouse wheel movement
				float amountToMove = Input.GetAxis("Mouse ScrollWheel");
				// depending on the orientation of the object you may need to use something other then a Vector3.forward
				offset += GameObject.Find("TrackingSpace").transform.forward * amountToMove; // translate the amountToMove to a vector3
			}
		}
	}

	void OnMouseEnter() {
		 // set object as selected
		/*
		tempColor = GetComponent<Renderer>().material.color;
		GetComponent<Renderer>().material.color = Color.yellow;
		*/
	}

	void OnMouseExit() {
		// GetComponent<Renderer>().material.color = tempColor;
		 // set object as not selected
	}
	
	void OnMouseDown() {
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = new Vector3 (0, 0, 0);
		_objectSelected = false;

		if (this.name == "paper1" ||
			this.name == "paper2" ||
			this.name == "paper3" ||
			this.name == "paper4") {
			this.transform.localRotation = GameObject.Find("CenterEyeAnchor").transform.localRotation;
		}
	}
	
	void OnMouseDrag() {
		_objectSelected = true;
		Vector3 curScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint) + offset;
		transform.position = curPosition + offset;
	}
}

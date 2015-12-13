using UnityEngine;
using System.Collections;

public class CursorRay : MonoBehaviour {
	private Camera cam;
	private LineRenderer lineRenderer;


	private Color tempColor;
	private bool _objectSelected = false;
	private Vector3 offset = new Vector3(0, 0, 0);
	private GameObject collisionObject;


	// Use this for initialization
	void Start () {
		cam = Camera.main; 
		lineRenderer = GetComponent<LineRenderer> ();
		collisionObject = null;
	}
	
	// Update is called once per frame
	void Update () {
		// update ray rotation
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 5; // set distance = 10 from the camera
		Vector3 screenPos = cam.ScreenToWorldPoint(mousePos);

		Vector3 forward = screenPos - transform.position;
		RaycastHit hit;
		if (Physics.Raycast (transform.position, forward, out hit)) {
			if (hit.collider) {			// ray meets object
				lineRenderer.SetPosition (1, forward /*hit.point*/);
				collisionObject = hit.collider.gameObject;
				tempColor = collisionObject.GetComponent<Renderer>().material.color;
				collisionObject.GetComponent<Renderer>().material.color = Color.red;
				Debug.Log ("Hit "+collisionObject.name);
			} else {   // didn't hit object
				if (collisionObject != null) {
					collisionObject.GetComponent<Renderer>().material.color = tempColor;
					collisionObject = null;
				}

			}
		} else {
			if (collisionObject != null) {
				collisionObject.GetComponent<Renderer>().material.color = tempColor;
				collisionObject = null;
			}
			lineRenderer.SetPosition(1, forward);
		}

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
}

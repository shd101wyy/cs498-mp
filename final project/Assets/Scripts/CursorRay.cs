using UnityEngine;
using System.Collections;

public class CursorRay : MonoBehaviour {
	private Camera cam;
	private LineRenderer lineRenderer;


	private Color tempColor;
	private bool _objectSelected = false;
	private Vector3 offset = new Vector3(0, 0, 0);


	// Use this for initialization
	void Start () {
		cam = Camera.main; 
		lineRenderer = GetComponent<LineRenderer> ();
		lineRenderer.SetWidth (0.1f, 0.1f);
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
			}
		} else {
			lineRenderer.SetPosition(1, forward);
		}
	}
}
using UnityEngine;
using System.Collections;

public class CursorEvent : MonoBehaviour {
	private Camera cam;
	public float maxDistance;
	public Material red;
	public Material blue; 

	// Use this for initialization
	void Start () {
		cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mousePos = Input.mousePosition;
		Vector3 maxPos = new Vector3 (mousePos.x, mousePos.y, maxDistance);
		Vector3 screenPos = cam.ScreenToWorldPoint(maxPos);
		Ray ray = cam.ScreenPointToRay (maxPos);

		// change rotation
		transform.rotation = cam.transform.rotation;

		// Debug.DrawRay(ray.origin, ray.direction * 10);

		int layerMask = 1 << 8; // Layer8 is HittableObject layer defined by ME !!


		// Check hit HittableObject
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 500.0f, layerMask)/* Physics.SphereCast(ray, 100.0f, out hit) */) {
			// Debug.Log ("Hit object " + hit.collider.name);
			// Debug.DrawLine(ray.origin, hit.point, Color.yellow);
			// Debug.DrawLine(ray.origin, ray.origin + (hit.point - ray.origin) * 0.7f);

			if (hit.collider.gameObject.GetComponent<MouseMove>() != null) { // the object can be moved
				this.GetComponent<Renderer> ().material = red;

				/*
				if (Input.GetMouseButtonDown(0)) {
					hit.collider.gameObject.transform.position = screenPos; // get object closer
				}
				*/
			} else {
				this.GetComponent<Renderer> ().material = blue;
			}
		} else {
			this.GetComponent<Renderer>().material = blue;
		}

		// update cursor position
		this.transform.position = screenPos;
	}
}
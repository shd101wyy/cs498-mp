using UnityEngine;
using System.Collections;

public class CursorEvent : MonoBehaviour {
	private Camera cam;
	public float maxDistance;
	public Material red;
	public Material blue; 
	public Material inactiveButton;
	public Material activeButton;

	private GameObject btn_0;
	private GameObject btn_1;
	private GameObject btn_2;
	private GameObject btn_3;
	private GameObject btn_4;
	private GameObject btn_5;
	private GameObject btn_6;
	private GameObject btn_7;
	private GameObject btn_8;
	private GameObject btn_9;
	private GameObject btn_E;
	private GameObject btn_R;

	// Use this for initialization
	void Start () {
		cam = Camera.main;

		btn_0 = GameObject.Find ("Btn_0");
		btn_1 = GameObject.Find ("Btn_1");
		btn_2 = GameObject.Find ("Btn_2");
		btn_3 = GameObject.Find ("Btn_3");
		btn_4 = GameObject.Find ("Btn_4");
		btn_5 = GameObject.Find ("Btn_5");
		btn_6 = GameObject.Find ("Btn_6");
		btn_7 = GameObject.Find ("Btn_7");
		btn_8 = GameObject.Find ("Btn_8");
		btn_9 = GameObject.Find ("Btn_9");
		btn_E = GameObject.Find ("Btn_E");
		btn_R = GameObject.Find ("Btn_R");
	}

	void resetNumberButtons() {
		btn_0.GetComponent<Renderer>().material = inactiveButton;
		btn_1.GetComponent<Renderer>().material = inactiveButton;
		btn_2.GetComponent<Renderer>().material = inactiveButton;
		btn_3.GetComponent<Renderer>().material = inactiveButton;
		btn_4.GetComponent<Renderer>().material = inactiveButton;
		btn_5.GetComponent<Renderer>().material = inactiveButton;
		btn_6.GetComponent<Renderer>().material = inactiveButton;
		btn_7.GetComponent<Renderer>().material = inactiveButton;
		btn_8.GetComponent<Renderer>().material = inactiveButton;
		btn_9.GetComponent<Renderer>().material = inactiveButton;
		btn_E.GetComponent<Renderer>().material = inactiveButton;
		btn_R.GetComponent<Renderer>().material = inactiveButton;
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

			if (hit.collider.gameObject.GetComponent<MouseMove>() != null || hit.collider.gameObject.tag == "NumberButton") { // the object can be moved
				this.GetComponent<Renderer> ().material = red;
		
				if (Input.GetMouseButtonDown(0)) {
					if (hit.collider.tag == "NumberButton" && btn_E.GetComponent<Renderer>().sharedMaterial == inactiveButton) {
						GameObject btn = hit.collider.gameObject;
						if (btn.name == "Btn_R") { // reset
							resetNumberButtons();
						} else if (btn.name == "Btn_E") {
							if (btn_0.GetComponent<Renderer>().sharedMaterial == inactiveButton && 
							    btn_1.GetComponent<Renderer>().sharedMaterial == activeButton && 
							    btn_2.GetComponent<Renderer>().sharedMaterial == activeButton && 
							    btn_3.GetComponent<Renderer>().sharedMaterial == inactiveButton && 
							    btn_4.GetComponent<Renderer>().sharedMaterial == activeButton && 
							    btn_5.GetComponent<Renderer>().sharedMaterial == inactiveButton && 
							    btn_6.GetComponent<Renderer>().sharedMaterial == inactiveButton && 
							    btn_7.GetComponent<Renderer>().sharedMaterial == activeButton && 
							    btn_8.GetComponent<Renderer>().sharedMaterial == inactiveButton && 
							    btn_9.GetComponent<Renderer>().sharedMaterial == inactiveButton) {
								Debug.Log("Password correct");
								resetNumberButtons();
								btn.GetComponent<Renderer>().material = activeButton;

								GameObject.Find("Alert_Sound").GetComponent<AudioSource>().Stop(); // stop playing audio
								
								GameObject.Find("space_capsule").GetComponent<Animation>().Play("backToEarth");
							} else {
								Debug.Log("Password wrong");
								resetNumberButtons();
							}
						} else {
							if (btn.GetComponent<Renderer>().sharedMaterial == inactiveButton) {
								btn.GetComponent<Renderer>().material = activeButton;
							} else {
								btn.GetComponent<Renderer>().material = inactiveButton;
							}
						}	
					}

					if (hit.collider.name == "instruction paper") { // start alert
						GameObject.Find("Spotlight").GetComponent<LightController>().startAlert();
						GameObject.Find("Spotlight_2").GetComponent<LightController>().startAlert();
						GameObject.Find("Spotlight_3").GetComponent<LightController>().startAlert();
						GameObject.Find("Alert_Sound").GetComponent<AudioSource>().Play();  // start playing alert sound
					}
			
				}
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
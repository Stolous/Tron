using UnityEngine;
using System.Collections;

public class MouseOrbit : MonoBehaviour {

	public Transform target;
	public float distance = 5.0f;
	public float xSpeed = 120.0f;
	public float ySpeed = 120.0f;
	public float distanceMin = .5f;
	public float distanceMax = 15f;
	
	private float x = 0.0f;
	private float y = 0.0f;
	
	void LateUpdate () {
		if (target) {
			x += Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
			y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

			Quaternion rotation = Quaternion.Euler(y, x, 0);
			
			distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);
			
			RaycastHit hit;
			if (Physics.Linecast (target.position, transform.position, out hit)) {
				distance -=  hit.distance;
			}
			Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
			Vector3 position = rotation * negDistance + target.position;
			
			transform.rotation = rotation;
			transform.position = position;
		}
	}
}

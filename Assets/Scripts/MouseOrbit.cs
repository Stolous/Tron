﻿using UnityEngine;
using System.Collections;

public class MouseOrbit : MonoBehaviour {

	public bool shouldOrbit = true;
	public byte playerNumber = 0;
	public Transform target;

	public float distance = 5.0f;
	public float xSpeed = 120.0f;
	public float ySpeed = 120.0f;
	public float distanceMin = .5f;
	public float distanceMax = 15f;
	
	private float x = 0.0f;
	private float y = 0.0f;

	private Vector3 expectedPosition;

	void LateUpdate () {
		if(shouldOrbit && target) {
			x += Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
			y = Mathf.Clamp(y - Input.GetAxis("Mouse Y") * ySpeed * 0.02f, 2, 100);

			Quaternion rotation = Quaternion.Euler(y, x, 0);
			
			distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);
			
			/*RaycastHit hit;
			if (Physics.Linecast (target.position, transform.position, out hit)) {
				distance -=  hit.distance;
			}*/
			Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
			Vector3 position = rotation * negDistance + target.position;
			
			transform.rotation = rotation;
			transform.position = position;
		}
		else {
			transform.localPosition = Vector3.Lerp(transform.localPosition, expectedPosition, 0.1f);
			transform.LookAt(transform.parent.position + new Vector3(0f, 1f, 0f));
			if((Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.Keypad0)) && (playerNumber == 0 || playerNumber == 2)) {
				expectedPosition = (Input.GetKey(KeyCode.RightControl) ? Vector3.right : Vector3.left) * distance + new Vector3(0f, 2f, 0f);
			}
			else if((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.E)) && (playerNumber == 1)) {
				expectedPosition = (Input.GetKey(KeyCode.A) ? Vector3.right : Vector3.left) * distance + new Vector3(0f, 2f, 0f);
			}
			else
				expectedPosition  = Vector3.back * distance + new Vector3(0f, 2f, 0f);

		}
	}
}

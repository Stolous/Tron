﻿using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {
	
	public void FitBetween(Vector3 A, Vector3 B) {
		this.transform.position = (A + B) / 2;
		Vector3 scale = this.transform.localScale;
		scale.z = Vector3.Distance(A, B);
		this.transform.localScale = scale;
	}

	/*void OnTriggerEnter(Collider other) {
		Debug.Log("wall death");
	}*/
}

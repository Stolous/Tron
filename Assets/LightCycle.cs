using UnityEngine;
using System.Collections;

public class LightCycle : MonoBehaviour {
	
	void OnTriggerEnter(Collider other) {
		Debug.Log("Player lost");
	}
}

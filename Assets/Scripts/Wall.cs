using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

	public GameObject player;
	private bool isSet = false;
	public bool isFixed = false;

	/*void OnStartServer() {
		player.GetComponent<LightCycleMovements>().currentWall = this;
		Debug.Log("start server in wall");
	}
	void OnStartClient() {
		this.onst
		player.GetComponent<LightCycleMovements>().currentWall = this;
		Debug.Log("start client in wall");
	}*/
	/*
	void Update() {
		if(!this.isSet) {
			player.GetComponent<LightCycleMovements>().currentWall = this;
			this.isSet = true;
			Debug.Log("first frame in wall");
		}
	}*/
	
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

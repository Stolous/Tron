using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class LightCycleMovements : NetworkBehaviour {

	public float speed = 2.5f;
	public Transform wallPosition;

	public GameObject currentWall;
	//[SyncVar]
	private Vector3 lastPosition = Vector3.zero;
	private bool startingWall = true;

	void Start() {
		lastPosition = new Vector3(wallPosition.transform.position.x, wallPosition.transform.position.y, 0);
		//lastPosition = wallPosition.transform.position;
	}

	void Update() {
		transform.Translate(speed * Vector3.forward * Time.deltaTime);
		if(this.GetComponent<LightCycle>().currentWall)
			currentWall = this.GetComponent<LightCycle>().currentWall;
		if(startingWall) {
			if(currentWall)
				this.currentWall.GetComponent<Wall>().isFixed = true;
			/*this.currentWall = */this.GetComponent<LightCycle>().SpawnWall();
			this.startingWall = false;
		}
		else {
			if(currentWall && !currentWall.GetComponent<Wall>().isFixed)
				currentWall.GetComponent<Wall>().FitBetween(lastPosition, wallPosition.position);
		}


		if(this.isLocalPlayer) {
			if(Input.GetKeyDown(KeyCode.LeftArrow)) {
				transform.RotateAround(wallPosition.position, Vector3.up, -90);
				this.lastPosition = wallPosition.position;
				this.startingWall = true;

			}
			else if(Input.GetKeyDown(KeyCode.RightArrow)) {
				transform.RotateAround(wallPosition.position, Vector3.up, 90);
				this.lastPosition = wallPosition.position;
				this.startingWall = true;
			}
		}
	}
	/*
	void FixedUpdate() {
		if(currentWall && !startingWall)
			currentWall.GetComponent<Wall>().FitBetween(lastPosition, wallPosition.position);
	}*/

	/*[ClientRpc]
	void RpcOnTurn() {
		this.lastPosition = wallPosition.position;
		this.startingWall = true;
	}*/
}
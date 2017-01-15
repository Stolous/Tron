using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class LightCycleMovements : NetworkBehaviour {

	public float speed = 2.5f;
	public Transform wallPosition;

	public GameObject currentWall;
	private Vector3 lastPosition = Vector3.zero;
	private bool startingWall = true;
	public byte playerNumber = 0;

	void Start() {
		lastPosition = new Vector3(wallPosition.transform.position.x, wallPosition.transform.position.y, 0);
	}

	void Update() {
		transform.Translate(speed * Vector3.forward * Time.deltaTime);
		if(this.GetComponent<LightCycle>().currentWall)
			currentWall = this.GetComponent<LightCycle>().currentWall;
		if(this.GetComponent<LightCycle>().localCurrentWall)
			currentWall = this.GetComponent<LightCycle>().localCurrentWall;
		if(startingWall) {
			if(currentWall)
				this.currentWall.GetComponent<Wall>().isFixed = true;
			this.GetComponent<LightCycle>().SpawnWall();
			this.startingWall = false;
		}
		else {
			if(currentWall && !currentWall.GetComponent<Wall>().isFixed)
				currentWall.GetComponent<Wall>().FitBetween(lastPosition, wallPosition.position);
		}

		if(this.isLocalPlayer || Application.loadedLevelName == "LocalGame") {
			if(((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)) && (playerNumber == 0 || playerNumber == 2)) || 
			   ((Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.D)) && (playerNumber == 1))) {
				transform.RotateAround(wallPosition.position, Vector3.up, Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.Q) ? -90 : 90);
				this.lastPosition = wallPosition.position;
				this.startingWall = true;
			}
		}
	}
}
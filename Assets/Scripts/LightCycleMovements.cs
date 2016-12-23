using UnityEngine;
using System.Collections;

public class LightCycleMovements : MonoBehaviour {

	public float speed = 2.5f;
	public GameObject wallObject;
	public Transform wallPosition;

	private GameObject currentWall;
	private Vector3 lastPosition = Vector3.zero;
	private bool startingWall = true;

	void Start() {
		lastPosition = new Vector3(0, wallPosition.transform.position.y, 0);
	}

	void Update() {
		transform.Translate(speed * Vector3.forward * Time.deltaTime);

		if(startingWall) {
			this.currentWall = (GameObject)Instantiate(wallObject, wallPosition.position, transform.rotation);
			this.startingWall = false;
		}
		else {
			currentWall.GetComponent<Wall>().FitBetween(lastPosition, wallPosition.position);
		}


		if(Input.GetKeyDown(KeyCode.LeftArrow)) {
			transform.RotateAround(wallPosition.position, Vector3.up, -90);
			lastPosition = wallPosition.position;
			this.startingWall = true;
		}
		else if(Input.GetKeyDown(KeyCode.RightArrow)) {
			transform.RotateAround(wallPosition.position, Vector3.up, 90);
			lastPosition = wallPosition.position;
			this.startingWall = true;
		}
	}
}

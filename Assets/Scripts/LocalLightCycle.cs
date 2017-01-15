using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class LocalLightCycle : LightCycle {

	/*void Awake() {
		GetComponent<LightCycleMovements>().enabled = true;
		cameraObject.SetActive(true);
	}*/
	
	public override void SpawnWall() {
		GameObject wall = (GameObject)Instantiate(wallPrefab, new Vector3(0, -20, 0), transform.rotation); // Spawning out of the map so no collision at the start
		wall.GetComponent<Wall>().player = this.gameObject;

		this.localCurrentWall = wall;
		Debug.Log("spawned wall");
	}
}

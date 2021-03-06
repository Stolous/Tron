﻿using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class MultiplayerLightCycle : LightCycle {

	void Start() {
		Debug.Log("connected");
		if(this.isLocalPlayer) {
			GetComponent<LightCycleMovements>().enabled = true;
			cameraObject.SetActive(true);
		}
	}

	public override void SpawnWall() {
		if(isServer) {
			GameObject wall = (GameObject)Instantiate(wallPrefab, new Vector3(0, -20, 0), transform.rotation); // Spawning out of the map so no collision at the start
			wall.GetComponent<Wall>().player = this.gameObject;
			NetworkServer.SpawnWithClientAuthority(wall, base.connectionToClient);
			
			this.currentWall = wall;
			Debug.Log("spawned wall for myself");
		}
		else {
			CmdSpawnWall();
		}
	}
	
	[Command]
	private void CmdSpawnWall() {
		GameObject wall = (GameObject)Instantiate(wallPrefab, new Vector3(0, -20, 0), transform.rotation * Quaternion.Euler(0, 90, 0)); // Spawning out of the map so no collision at the start
		wall.GetComponent<Wall>().player = this.gameObject;
		NetworkServer.SpawnWithClientAuthority(wall, connectionToClient);
		
		this.currentWall = wall;
		Debug.Log("spawned wall for " + base.connectionToClient);
	}
}

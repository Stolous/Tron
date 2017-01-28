using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class LightCycle : NetworkBehaviour {

	public GameObject cameraObject;
	public GameObject wallPrefab;

	[SyncVar]
	public GameObject currentWall;

	public GameObject localCurrentWall;

	void OnTriggerEnter(Collider other) {
		if(Network.isServer)
			GameObject.Find("NetworkManager").GetComponent<NetworkManager>().StopServer();
		Debug.Log("Player lost");
		Application.LoadLevel("GameFinished");
	}

	public virtual void SpawnWall() {}
}

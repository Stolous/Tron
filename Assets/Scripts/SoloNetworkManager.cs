using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class SoloNetworkManager : MonoBehaviour {

	void Start () {
		this.GetComponent<NetworkManager>().StartServer();
	}
}

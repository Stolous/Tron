using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class GameManager : MonoBehaviour {

	void OnServerConnection() {
		Debug.Log("connected");
	}

	void Start() {
		DontDestroyOnLoad(this.gameObject);
	}

	public void PlayLocal() {
		Debug.Log("Playing local game");
		Application.LoadLevel("LocalGame");
	}

	public void PlayNetworked() {
		Debug.Log("Playing networked game");
		Application.LoadLevel("Lobby");
	}

	public void ExitGame() {
		Debug.Log("Quitting");
		Application.Quit();
	}

}

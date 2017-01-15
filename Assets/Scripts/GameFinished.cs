using UnityEngine;
using System.Collections;

public class GameFinished : MonoBehaviour {

	public void RestartGame() {
		Application.LoadLevel("LocalGame");
	}

	public void MainMenu() {
		Debug.Log("Going back to main menu");
		Application.LoadLevel("Menu");
	}
}

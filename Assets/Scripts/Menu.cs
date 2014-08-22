using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Jump")){
			//now stop menu and start game
			Director.main.StartGame();
			Director.main.StopMenu();
		}
	}
}

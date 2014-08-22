using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour {
	public static Director main; //let's make this guy a "singleton"

	public GameObject menuPrefab;
	private GameObject menuInstance;

	public GameObject gamePrefab;
	private GameObject gameInstance;

	void Awake(){
		//precisely when my game starts!
		main = this;

		//let's set up the menu! instantiate that thing
		StartMenu();
	}

	public void PrintMessage(){
		Debug.Log("I'M ALIVE!!");
	}

	public void StartMenu(){
		menuInstance = (GameObject)Instantiate(menuPrefab, Vector3.zero, Quaternion.identity);
	}
	public void StopMenu(){
		Destroy(menuInstance);
	}
	public void StartGame(){
		gameInstance = (GameObject)Instantiate(gamePrefab, Vector3.zero, Quaternion.identity);
	}
	public void StopGame(){

	}
}

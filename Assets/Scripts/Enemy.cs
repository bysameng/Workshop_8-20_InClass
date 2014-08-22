using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnCollisionEnter(Collision other){
		if (other.gameObject.name == "PlayerCube"){
			//tell player to die!
			//or maybe increase player's movement speed
			PlayerMotor p = other.gameObject.GetComponent<PlayerMotor>();
			p.jumpPower = 200f;
			Destroy(this.gameObject);
		}
	}
}

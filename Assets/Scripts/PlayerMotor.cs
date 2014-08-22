using UnityEngine;
using System.Collections;

public class PlayerMotor : MonoBehaviour {

	public float topSpeed;
	public float acceleration;
	public float deceleration;

	private Vector2 movement;
	private Vector2 velocity;

	private bool onGround;
	private float jumpTimer;

	public float jumpTimerFull = .1f;
	public float gravity = 25f;
	public float jumpPower = 50f;

	// Use this for initialization
	void Start () {
		topSpeed = 5f;
		acceleration = 5f;
		deceleration = 5f;
	}
	
	// Update is called once per frame
	void Update () {

		onGround = CheckGround();

		movement.x = Input.GetAxisRaw("Horizontal") * acceleration;
		Debug.Log("movement.x is " + movement.x);
		if (movement.x == 0){
			velocity.x = DecelerateValue(velocity.x, deceleration * Time.deltaTime);
		}

		if (!onGround){
			movement.y = gravity;
		}
		else velocity.y = movement.y = 0f;

		if (Input.GetButtonDown("Jump") && onGround){
			Director.main.PrintMessage();
			jumpTimer = jumpTimerFull;
		}

		if (jumpTimer > 0){
			jumpTimer -= Time.deltaTime; //subtract how much time has passed
			movement.y = jumpPower; //jump power acceleration
			onGround = false; //we're not on the ground! dont use gravity!
		}

		velocity += movement * Time.deltaTime;

		velocity.x = Mathf.Clamp(velocity.x, -topSpeed, topSpeed);
		velocity.y = Mathf.Clamp(velocity.y, -1000f, 1000f);
	
		//apply velocity
		rigidbody.velocity = velocity;
	}


	float DecelerateValue (float value, float decel){
		//value is positive!
		if (value > 0){
			value -= decel; //let's move it closer to zero by subtracting
			if (value < 0){
				value = 0;
			}
		}
		//value is negative!
		else if (value < 0){
			value += decel; //let's move it closer by adding
			if (value > 0){
				value = 0;
			}
		}
		return value;
	}

	
	bool CheckGround(){

		Vector3 rayOriginLeft = transform.position;
		Vector3 rayOriginRight = rayOriginLeft;

		rayOriginLeft.x += collider.bounds.size.x/2;
		rayOriginRight.x -= collider.bounds.size.x/2;

		bool left = Physics.Raycast(rayOriginLeft, Vector3.down, collider.bounds.size.y / 2);
		bool right = Physics.Raycast(rayOriginRight, Vector3.down, collider.bounds.size.y / 2);

		return (left || right);
	}

}

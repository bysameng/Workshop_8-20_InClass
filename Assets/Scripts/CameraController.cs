using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject followedObject;

	private Vector3 targetPosition;
	private Vector3 velocity;
	private float smoothTime;

	// Use this for initialization
	void Start () {
		smoothTime = .3f;
	}
	
	// Update is called once per frame
	void Update () {
		targetPosition = followedObject.transform.position;
		targetPosition += new Vector3 (0, 2, -10);
		Vector3 newPosition = Vector3.SmoothDamp(transform.position,
		                                         targetPosition,
		                                         ref velocity,
		                                         smoothTime);
		transform.position = newPosition;
	}
}

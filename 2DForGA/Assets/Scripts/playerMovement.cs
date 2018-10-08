using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {
	public float speed = 10f;
	public Vector2 maxVelocity = new Vector2(3, 5);
	private Rigidbody2D playerRigidbody;

	public bool standing;
	public float jetSpeed = 15f;
	//public float airSpeedMultiplier = .3f;


	// Use this for initialization
	void Start () {
		playerRigidbody = GetComponent<Rigidbody2D> ();

	}

	// Update is called once per frame
	void Update () {
		var forceX = 0f;
		var forceY = 0f;

		var absVelX = Mathf.Abs (playerRigidbody.velocity.x);
		var absVelY = Mathf.Abs (playerRigidbody.velocity.y);

		if(absVelY < .2f) {
			standing = true;
		} else {
			standing = false;
		}

		if (Input.GetKey("up")){
			if(absVelY < maxVelocity.y) 
				forceY = jetSpeed;
		}

		if (Input.GetKey ("right")) {
			if(absVelX < maxVelocity.x)
				forceX = speed;
				//forceX = standing ? speed : (speed * airSpeedMultiplier);
			transform.localScale = new Vector3(1, 1, 1);

		} else if (Input.GetKey ("left")) {
			if(absVelX < maxVelocity.x)
				forceX = -speed;
				//forceX = standing ? -speed : (-speed * airSpeedMultiplier);
			transform.localScale = new Vector3(-1, 1, 1);
		}

		playerRigidbody.AddForce(new Vector2 (forceX, forceY));

	}
}
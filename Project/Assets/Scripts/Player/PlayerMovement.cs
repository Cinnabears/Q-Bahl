using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public static float speed  = 8f;
	public float jumpForce = 300f;
	private bool isGrounded = false;

	Vector3 movement;
	Rigidbody playerRigidbody;

	// Use this for initialization
	void Awake () {
		// This will be used to rotate the player's aim/arm/gun around the z-axis
		playerRigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per physics frame
	void FixedUpdate () {
		float h = Input.GetAxisRaw ("Horizontal");

		Move (h);
		if (isGrounded && Input.GetKeyDown ("space")) {
			isGrounded = false;
			Jump ();
		}
	}

	void Move(float h) {
		movement.Set (h, 0f, 0f);
		movement = movement.normalized * speed * Time.deltaTime;
		playerRigidbody.MovePosition (transform.position + movement);
	}

	void Jump() {
		playerRigidbody.AddForce (transform.up * jumpForce);
	}
		
	void OnCollisionEnter(Collision other) {
		if (other.gameObject.CompareTag ("Ground")) {
			isGrounded = true;
		}
	}
}

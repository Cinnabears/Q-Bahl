using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public static float speed  = 10f;
	public float jumpForce = 700f;
	private bool isGrounded = false;
	public bool isJumping = false;
	public float jumpTimeout = 0;
	public float h;
	public static bool facingRight = true;

	//public Transform groundCheck;
	//float groundRadius = 0.2f;
	//public LayerMask whatIsGround;

	public Animator playerAnim;

	Vector3 movement;
	Rigidbody playerRigidbody;
	RaycastHit hit;
	Vector3 rayDir = new Vector3 (0f, -1f, 0f);
	float rayDist = 0.8f;
	public int movementDir;




	// Use this for initialization
	void Awake () {
		// This will be used to rotate the player's aim/arm/gun around the z-axis
		playerRigidbody = GetComponent<Rigidbody> ();
		playerAnim = gameObject.GetComponent<Animator> ();
	}


	// Update is called once per physics frame
	void FixedUpdate () {
		//isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

		playerAnim.SetFloat ("vSpeed", GetComponent<Rigidbody> ().velocity.y);

		isJumping = !(jumpTimeout == 0 && isGrounded);
		playerAnim.SetBool ("Jumping", isJumping);


		if (GameObject.Find ("GameManager").GetComponent<GameManager> ().GetCurrGameState() != GAME_STATE.START_MENU && GameObject.Find ("GameManager").GetComponent<GameManager> ().GetCurrGameState() != GAME_STATE.PAUSED) {
	        h = Input.GetAxis ("Horizontal");
			movementDir = (int)h;
			playerAnim.SetFloat ("Speed", Mathf.Abs (h));

			if (h > 0 && !facingRight) {
				Flip ();
			} else if (h < 0 && facingRight) {
				Flip ();
			}

			GetComponent<Rigidbody> ().velocity = new Vector3 (h * speed, GetComponent<Rigidbody>().velocity.y);
			//Move (h);

			if (isJumping && jumpTimeout > 0) {
				jumpTimeout -= Time.deltaTime;
				if (jumpTimeout <= 0) {
					GetComponent<Rigidbody> ().AddForce (new Vector3 (0, jumpForce, 0));
					jumpTimeout = 0;
				}
			}

		}

		if (Physics.Raycast (transform.position, rayDir, out hit, rayDist)) {
			isGrounded = true;

		} else {
			isGrounded = false;
		}
		playerAnim.SetBool ("Ground", isGrounded);

	}

	void Update()
	{

		if (isGrounded && Input.GetButtonDown("Jump") && isJumping == false) {
			isJumping = true;
			jumpTimeout = .2f;

		} 
			
		//playerAnim.SetBool ("Jumping", isJumping);

	}

//	void Move(float h) {
//		if (h > 0 && !facingRight) {
//			Flip ();
//		} else if (h < 0 && facingRight) {
//			Flip ();
//		}
//		movement.Set (h, 0f, 0f);
//		movement = movement.normalized * speed * Time.deltaTime;
//		playerRigidbody.MovePosition (transform.position + movement);
//	}

//	void Jump() {
//		playerRigidbody.AddForce (transform.up * jumpForce);
//	}
		
	void OnCollisionEnter(Collision other) {
//		if (other.gameObject.CompareTag("MovingPlat")) {
//			playerRigidbody.isKinematic = true;
//			gameObject.transform.SetParent (other.transform);
//		}
//
	}

	public void ChangeSpeed(float num){
		speed *= num;
	}

	public void ResetNormal(){
		speed = 8f;
	}

	void Flip()
	{
		Vector3 scaleME = transform.localScale;
		Vector3 non;
		scaleME.z *= -1;
		transform.localScale = scaleME;
		facingRight = !facingRight;
		non = GameObject.Find ("PlayerArm").transform.localScale;
		//non.z *= -1;
		GameObject.Find ("PlayerArm").transform.localScale = non;
	}
}

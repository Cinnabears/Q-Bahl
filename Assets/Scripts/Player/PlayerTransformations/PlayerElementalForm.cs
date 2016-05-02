﻿using UnityEngine;
using System.Collections;

public class PlayerElementalForm : PlayerTransform {


	public GameObject rockWallObject;
	public GameObject fireball;
	public float turnAngle;
	public float fireballSpeed = 1000f;

	Rigidbody rb;
	Rigidbody fireballRb;
	GameObject spawnedRockWall;

	PlayerAiming playerAim;
	float rayDist = 20.0f;
	Vector3 rayDir = new Vector3 (0, -1, 0);
	RaycastHit hit;
	Vector3 mouseToWorld;
	float rockWallDir;
	float wallGrowthCount;

	// Cooldown Variables
	public float cooldown1;
	public bool isCooling1 = false;
	public float cooldown2;
	public bool isCooling2 = false;
	public float cooldown3;
	public bool isCooling3 = false;

	void Awake () {
		rb = GetComponent<Rigidbody> ();
		playerAim = rb.GetComponent<PlayerAiming> ();
		transform_name = "Elemental";
		transform_description = "Avatar yo.";
		cooldown1 = 1.0f;
		cooldown2 = 5.0f;
		cooldown3 = 3.0f;
	}
	
	public override void Ability1() {
		Debug.Log ("Elemental Ability 1");
		shootFireball ();
	}
	
	public override void Ability2() {
		Debug.Log ("Elemental Ability 2");
		rockWall ();
	}
	
	public override void SpecialAbility() {
		Debug.Log ("Elemental Special Ability");
	}

	private void shootFireball () {
		if (!isCooling1) {
			isCooling1 = true;
			GameObject fireballClone = (GameObject) Instantiate (fireball, new Vector3 (rb.position.x, rb.position.y, rb.position.z), Quaternion.identity);
			fireballRb = fireballClone.GetComponent<Rigidbody> ();

			Vector3 fbDir = (playerAim.mouse_pos - fireball.transform.position).normalized;
			fireballRb.velocity = new Vector3 (fbDir.x * 15f, fbDir.y * 15f, rb.position.z);

			Invoke ("resetCooling1", cooldown1);
		}
	}

	private void rockWall () {
		if (!isCooling2) {
			if (Physics.Raycast (rb.transform.position, rayDir, out hit, rayDist)) {
				if (playerAim.looking_right) {
					rockWallDir = 10f;
				} else {
					rockWallDir = -10f;
				}
				Debug.Log ("EHRE COMES THE WALL!");
				spawnedRockWall = (GameObject) Instantiate (rockWallObject, new Vector3 (rb.position.x + rockWallDir, hit.point.y, rb.position.z), Quaternion.Euler(0,90,0));
				isCooling2 = true;
				wallGrowthCount = 5;
//				InvokeRepeating ("raiseRockWall", 0.0f, 0.1f);
				Invoke ("resetCooling2", cooldown2);
			}
		}
	}

	private void raiseRockWall () {
		
		spawnedRockWall.transform.Translate (0, 0.01f, 0);
		wallGrowthCount -= 0.1f;
		if (wallGrowthCount <= 0) {
			CancelInvoke ("raiseRockWall");
		}
	}

	private void resetCooling1 () {
		isCooling1 = false;
	}

	private void resetCooling2 () {
		isCooling2 = false;
	}

	private void resetCooling3 () {
		isCooling3 = false;
	}

}

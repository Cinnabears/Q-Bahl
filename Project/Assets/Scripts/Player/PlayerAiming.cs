using UnityEngine;
using System.Collections;

public class PlayerAiming : MonoBehaviour {
	public GameObject playerArm;

	Vector3 mouse_pos;
	Vector3 arm_pos;
	private float turn_angle;


	// Update is called once per frame
	void FixedUpdate () {
		Turn ();
	}

	void Turn() {
		mouse_pos = Input.mousePosition;
		arm_pos = Camera.main.WorldToScreenPoint (playerArm.transform.position);
		mouse_pos.x = mouse_pos.x - arm_pos.x;
		mouse_pos.y = mouse_pos.y - arm_pos.y;
		mouse_pos.z = 0f;
		turn_angle = Mathf.Atan2 (mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
		playerArm.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, turn_angle));
	}
}

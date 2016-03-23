using UnityEngine;
using System.Collections;

public class PlayerWarpForm : PlayerTransform {

	void Awake () {
		transform_name = "Warp";
		transform_description = "Where, what, meow?";
	}

	public override void Ability1() {
		Debug.Log ("Warp Ability 1");
	}
	public override void Ability2() {
		Debug.Log ("Warp Ability 2");
	}
	public override void SpecialAbility() {
		Debug.Log ("Warp Special Ability");
	}
		
}

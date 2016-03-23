using UnityEngine;
using System.Collections;

public class PlayerNormalForm : PlayerTransform {

	void Awake () {
		transform_name = "Normal";
		transform_description = "What his momma gave him.";
	}

	public override void Ability1() {
		Debug.Log ("Normal Ability 1");
	}
	public override void Ability2() {
		Debug.Log ("Normal Ability 2");
	}
	public override void SpecialAbility() {
		Debug.Log ("Normal Special Ability");
	}
}

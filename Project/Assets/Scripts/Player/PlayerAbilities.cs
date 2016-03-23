using UnityEngine;
using System.Collections;

public class PlayerAbilities : MonoBehaviour {

	PlayerTransform current_player_form;

	// Use this for initialization
	void Awake () {
		current_player_form = null;
	}
	
	// Update is called once per frame
	void Update () {
		UseAbility ();
	}

	void UseAbility () {
		if (current_player_form != null) {
			if (Input.GetButton("Fire1")) {
				UseAbility1 ();
			} else if (Input.GetButton("Fire2")) {
				UseAbility2 ();
			} else if (Input.GetKeyDown(KeyCode.E)) {
				UseSpecialAbility ();
			};
		}
	}

	void UseAbility1 () {
		current_player_form.Ability1 ();
	}

	void UseAbility2 () {
		current_player_form.Ability2 ();
	}

	void UseSpecialAbility () {
		current_player_form.SpecialAbility ();
	}

	public void SetCurrentForm (PlayerTransform form) {
		current_player_form = form;
	}
}

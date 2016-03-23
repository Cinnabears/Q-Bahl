using UnityEngine;
using System.Collections.Generic;

public class PlayerTransformManager : MonoBehaviour {

	PlayerTransform current_form;
	public Dictionary<int, PlayerTransform> transform_dict;

	PlayerAbilities player_abilities;

	// Use this for initialization
	void Awake () {
		player_abilities = GetComponent <PlayerAbilities> ();
		transform_dict = new Dictionary<int, PlayerTransform> ();
		transform_dict.Add (1, GetComponent<PlayerNormalForm> ());
		transform_dict.Add (2, GetComponent<PlayerWarpForm> ());
		ChangePlayerForm (1);
	}

	void Update () {
		CheckForTransform ();
	}

	void CheckForTransform () {
		if (Input.GetKeyDown(KeyCode.Alpha1) && current_form != transform_dict[1]) {
			ChangePlayerForm(1);
		}
		if (Input.GetKeyDown(KeyCode.Alpha2) && current_form != transform_dict[2]) {
			ChangePlayerForm (2);
		}
	}

	void ChangePlayerForm (int form_num) {
		current_form = transform_dict[form_num];
		player_abilities.SetCurrentForm (current_form);
		Debug.Log ("Transforming into " + current_form.transform_name + " form!");
	}

	public PlayerTransform GetCurrentForm () {
		return current_form;
	}
}

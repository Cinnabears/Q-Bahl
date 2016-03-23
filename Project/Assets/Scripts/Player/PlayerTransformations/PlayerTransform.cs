using UnityEngine;
using System.Collections;

abstract public class PlayerTransform : MonoBehaviour, IPlayerAbilities {

	public string transform_name;
	public string transform_description;
	public string ability1_desc;
	public string ability2_desc;
	public string special_ability_desc;
	public float ability1_time;
	public float ability2_time;
	public float special_ability_time;

	public abstract void Ability1();
	public abstract void Ability2();
	public abstract void SpecialAbility();
}

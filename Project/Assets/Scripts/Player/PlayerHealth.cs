using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour, IDamageable<float>, IKillable {

	float startingHealth = 100f;
	float currentHealth;
	bool isDead;

	PlayerMovement playerMovement;

	void Awake() {
		playerMovement = GetComponent<PlayerMovement> ();
		currentHealth = startingHealth;
		isDead = false;
	}

	public void TakeDamage(float damageTaken) {
		currentHealth -= damageTaken;

		if (currentHealth <= 0 && !isDead) {
			Death ();
		}
	}

	public void Death() {
		isDead = true;
		Debug.Log ("I AMS DEAD");
		playerMovement.enabled = false;
	}
}

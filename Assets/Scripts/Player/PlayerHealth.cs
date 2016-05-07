using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour, IDamageable<int>, IKillable {

	public int startingHealth = 100;
	public int currentHealth = 100;
    public int currentLives;
	bool isDead;

	PlayerMovement playerMovement;

	void Awake() {
		playerMovement = GetComponent<PlayerMovement> ();
		currentHealth = startingHealth;
		isDead = false;
        currentLives = 3;
	}

	public void TakeDamage(int damageTaken) {
        if (!isDead) {
            currentHealth -= damageTaken;
        }
		if (currentHealth <= 0 && !isDead) {
			Death ();
		}
	}

	public void Death() {
		isDead = true;
		Debug.Log ("I AMS DEAD");
		//playerMovement.enabled = false;
        currentLives--;
        GameObject.Find("UIManager").GetComponent<UIManager>().died = true;
        if (currentLives <= 0)
        {
            GameObject.Find("UIManager").GetComponent<UIManager>().gameOver = true;
        }
        isDead = false;
        currentHealth = startingHealth;
	}
}

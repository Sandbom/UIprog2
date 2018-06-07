using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossMovement : MonoBehaviour {

	float randomNumber;

	// Cooldowns and timers for boss
	float timer = 0.0f;
	float maxTimer = 1.5f;
	float coolDownTimer = 0.0f;
	float dontattackTimer = 6f;
	public float BossHP;

	Rigidbody2D BossRB;
	Animator BossAnim;

	public Slider BossHealthSlider;
	float currentHealth;

	bool facingRight = false;
	bool attacking = false;
	float roll;
	public static bool BossAlive = true;

	// variables to decide what projectile gets shot from where
	public Transform shootfrom;
	public Transform shootfrom2;
	public GameObject bossBullet;
	public GameObject bossBullet2;

	// HUD for when boss is dead
	public GameObject WinnerText;
	public GameObject Menubutton;
	public GameObject Quitbutton;

	// Use this for initialization
	void Start () {
		BossRB = GetComponent<Rigidbody2D> ();
		BossAnim = GetComponent<Animator> ();
		currentHealth = BossHP;
	}
	
	// Update is called once per frame
	// Rolls a number between 0 and 50, if the number is above 5(~95%) shoot a projectile and otherwise swap sides and run that animation
	void Update () {
		if (StartBossFight.bossEngaged) {
			timer += Time.deltaTime;
			coolDownTimer += Time.deltaTime;
			dontattackTimer += Time.deltaTime;
			// Checks every 5 seconds if we can do next attack
			if(timer >= maxTimer){
				timer = 0f;
				randomNumber = Random.Range (0, 50);
				if (randomNumber > 5 && dontattackTimer > 5) {
					Debug.Log ("shooting");
					BossShoot ();
				} else if (randomNumber < 5 && coolDownTimer > 10) {
					dontattackTimer = 0f;
					Debug.Log ("Charging");
					coolDownTimer = 0;
					ChangeSide ();
				}
				}
			}
		}

	// Add damage to boss, if health is less than 0 we trigger the boss death animation and reward player with score.
	public void addDamage(float damage){
		currentHealth = currentHealth - damage;
		BossHealthSlider.value = currentHealth;
		Debug.Log (currentHealth);

		if (currentHealth <= 0) {
			// Disable the colliders during the deathanimaton so the player can walk through the corpse and doesnt
			// take damage from touching the corpse, we also set the parents Rigidbody to kinematic to avoid the corpse falling through the map
			foreach(Collider2D c in GetComponents<BoxCollider2D> ()) {
				c.enabled = false;
			}
			BossRB.isKinematic = true;
			ScoreScript.scoreValue += 10000;
			BossAnim.SetTrigger ("BossDeath");
			Invoke ("DeclareWinner", 1.5f);
			BossAlive = false;
			Destroy(gameObject, 2f);
		}
	}

	// Called once the player beats the boss and is given options to return to main menu or quit game
	void DeclareWinner(){
		Time.timeScale = 0.05f;
		Time.fixedDeltaTime = 0.02F * Time.timeScale;
		WinnerText.SetActive (true);
		Menubutton.SetActive (true);
		Quitbutton.SetActive (true);
	}

	// instantiates one of the two projectiles from an upper or lower level, 50% chance for both.
	void BossShoot(){
		BossAnim.SetBool ("Charging", false);
		if (facingRight) {
			// We use the Random function to either shoot from the upper firing point or the lower one, 50% chance on each
			roll = Random.Range (0, 2);
			if (roll >= 1) {
				// we instantiate either the red or green projectile prefab at one of the 2 firing points on the boss
				Instantiate (bossBullet, shootfrom.position, Quaternion.Euler (new Vector3 (0, 0, 180)));
			} else if (1 >= roll) {
				BossAnim.SetBool("Shooting", true);
				Instantiate (bossBullet2, shootfrom2.position, Quaternion.Euler (new Vector3 (0, 0, 180)));
			}
		} else if (!facingRight) {
			roll = Random.Range (0, 2);
			if (roll >= 1) {
				Instantiate (bossBullet, shootfrom.position, Quaternion.Euler (new Vector3 (0, 0, 0)));
			}
			else if (1 >= roll) {
				BossAnim.SetBool("Shooting", true);
				Instantiate (bossBullet2, shootfrom2.position, Quaternion.Euler (new Vector3 (0, 0, 0)));
			}
		}
	}

	// We use this function to let the boss swap sides, so he charges for 2,5seconds then swaps. 
	void ChangeSide(){
		BossAnim.SetBool ("Shooting", false);
		if (facingRight) {
			BossAnim.SetBool ("Charging", true);
			Debug.Log ("Chargin");
			//BossRB.AddForce (new Vector2 (-6, 0));
			BossRB.velocity = new Vector2(15, 0);
			Invoke ("StopAndFlip", 2.5f);
		}
		else if (!facingRight) {
			BossAnim.SetBool ("Charging", true);
			Debug.Log ("Chargin");
			//BossRB.AddForce (new Vector2 (-6, 0));
			BossRB.velocity = new Vector2(-15, 0);
			Invoke ("StopAndFlip", 2.5f);
		}
	}

	// Flips boss once he is done chargings
	void StopAndFlip(){
		BossRB.velocity = new Vector2 (0, 0);
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}

using UnityEngine;
using System.Collections;

// Script related to the player's health, hunger and thirst.
public class PlayerSurvive : MonoBehaviour {

	public const float MAX_STAT = 100f;

	// 0 = Death | 100 = Healthy
	public float health = 100f;

	// 0 = Hungry | 100 = Full
	public float hunger = 100f;

	// 0 = Thirsty | 100 = Full
	public float thirst = 100f;



	// Drain rates per Update() * Time.deltaTime
	public float starveHealthDrainRate = 0.05f;

	public float hungerDrainRate = 0.05f;

	public float thirstDrainRate = 0.1f;


	public void Update() {
		hunger -= hungerDrainRate * Time.deltaTime;
		thirst -= thirstDrainRate * Time.deltaTime;

		hunger = Mathf.Max(0.0f, hunger);
		thirst = Mathf.Max(0.0f, thirst);

		if (hunger <= 0f) {
			health -= starveHealthDrainRate * Time.deltaTime;
		}

		if (thirst <= 0f) {
			health -= starveHealthDrainRate * Time.deltaTime;
		}
	}
		
	public void EatFood(float foodAmount) {
		hunger = Mathf.Min(hunger + foodAmount, MAX_STAT);
	}

	public void DrinkWater(float waterAmount) {
		thirst = Mathf.Min(thirst + waterAmount, MAX_STAT);
	}
}

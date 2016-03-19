using UnityEngine;
using System.Collections;

public abstract class ResourceSource : MonoBehaviour, IInteractible {

	public float resourceRestorationAmount = 20f;
	public float coolDownSecs = 10f;
	public int usesLeft = 1000;

	private float coolDownTimer = 0f; // Timestamp of when the player can continue to use water source

	public void Activate(GameObject interactor) {
		var playerSurvive = interactor.GetComponent<PlayerSurvive>();

		if (coolDownTimer > Time.time) {
			return;
		}

		if (playerSurvive == null) {
			return;
		}
		RestoreResource(playerSurvive);	
		coolDownTimer = Time.time + coolDownSecs;

		if (usesLeft <= 1) {
			Destroy(gameObject);
			return;
		}
		usesLeft--;
	}

	public abstract void RestoreResource(PlayerSurvive playerSurvive);
}

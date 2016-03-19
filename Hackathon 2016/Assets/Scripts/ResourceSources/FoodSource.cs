using UnityEngine;
using System.Collections;

public class FoodSource : ResourceSource {
	
	public override void RestoreResource(PlayerSurvive playerSurvive) {
		playerSurvive.EatFood(resourceRestorationAmount);
	}
}

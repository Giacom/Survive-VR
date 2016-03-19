using UnityEngine;
using System.Collections;

public class WaterSource : ResourceSource {

	public override void RestoreResource(PlayerSurvive playerSurvive) {
		playerSurvive.DrinkWater(resourceRestorationAmount);
	}
}

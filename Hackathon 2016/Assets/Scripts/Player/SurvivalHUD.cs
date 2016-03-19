using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SurvivalHUD : MonoBehaviour {

	public PlayerSurvive player;

	public Image healthBar;
	public Image thirstBar;
	public Image hungerBar;

    public void Update() {
        // Normalized to 0 - 1.0 range
        healthBar.fillAmount = player.health * 0.01f;
        thirstBar.fillAmount = player.thirst * 0.01f;
        hungerBar.fillAmount = player.hunger * 0.01f;
    }   
}

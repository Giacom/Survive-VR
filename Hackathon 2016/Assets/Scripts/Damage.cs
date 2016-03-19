using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {

    CharacterController Control;
    public float cooldownDuration = 5f;
    public float damage = 20f;
    PlayerSurvive playerSurvive;
    private float cooldownTimer = 0f;
    
    public void Awake()
    {
        playerSurvive = GetComponent<PlayerSurvive>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Wolf"))
        {
            if (cooldownTimer > Time.time)
            {
                return;
            }
            playerSurvive.health -= damage;
            cooldownTimer = Time.time + cooldownDuration;

        }
        
        if (playerSurvive.health < 0)
        {
            Control.enabled = false;

        }

    }

}

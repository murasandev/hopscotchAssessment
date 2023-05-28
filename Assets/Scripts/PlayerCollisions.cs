using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public PlayerMovementController playerMovementScript;
    public PlayerAnimations PlayerAnimations;
    public HealthBar healthBarScript;
    public GameOver gameOverCS;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blue Missile") || other.gameObject.CompareTag("Missile"))
        {
            healthBarScript.DamageTaken(20);
        }
        if (other.gameObject.CompareTag("Win Box"))
        {
            gameOverCS.winGame();
            PlayerAnimations.Win();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Orange Missile"))
        {
            //stop players abil to control movements
            playerMovementScript.StopMovements();
            healthBarScript.DamageTaken(10);
            Invoke("ExplosionDamage", 1.0f);
        }
    }

    private void ExplosionDamage()
    {
        healthBarScript.DamageTaken(20);
    }
}

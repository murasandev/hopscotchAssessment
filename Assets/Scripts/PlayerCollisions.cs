using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public PlayerMovementController playerMovementScript;
    public HealthBar healthBarScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blue Missile") || other.gameObject.CompareTag("Missile"))
        {
            healthBarScript.DamageTaken(20);
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

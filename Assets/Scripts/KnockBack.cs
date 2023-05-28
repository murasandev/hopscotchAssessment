using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float normalStrength = 5000.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blue Missile"))
        {
            Debug.Log("Explode");
            Vector3 knockbackDirection = transform.position - other.gameObject.transform.position;
            knockbackDirection.Normalize();

            Rigidbody playerRigidbody = GetComponent<Rigidbody>();
            playerRigidbody.AddForce(knockbackDirection * normalStrength * Time.deltaTime, ForceMode.Impulse);
        }
    }
}

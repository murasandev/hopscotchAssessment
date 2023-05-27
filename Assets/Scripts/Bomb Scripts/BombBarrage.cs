using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBarrage : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject crosshairGO;

    private float startHeight = 10.0f;
    private float timeToActive = 3.0f;
    private float timer;
    private float resetTimer = 0;
    public float gravityModifier = 1.0f;
    private bool activateBool;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        rb.useGravity = false;
    }

    private void Update()
    {
        if (activateBool)
        {
            ActivateGravity();
        }
    }

    private void OnEnable()
    {
        timer = resetTimer;
        transform.position = new Vector3(crosshairGO.transform.position.x, startHeight, crosshairGO.transform.position.z);
        activateBool = true;
    }

    private void OnDisable()
    {
        activateBool = false;
        rb.useGravity = false;
        ResetVelocity();
    }

    private void ActivateGravity()
    {
        //activates gravity to drop bomb after timeToActive seconds.
        timer += Time.deltaTime;
        if (timer >= timeToActive)
        {
            rb.useGravity = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        crosshairGO.SetActive(false);
        this.gameObject.SetActive(false);
    }

    private void ResetVelocity()
    {
        //resets bomb velocity when disabled
        rb.velocity = Vector3.zero;
    }
}

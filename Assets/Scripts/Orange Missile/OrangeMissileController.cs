using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeMissileController : MonoBehaviour
{
    private float inactiveTimer = 1f;
    public GameObject explosionPS;
    public GameObject parentGO;

    public float speed = 6;
    Rigidbody _RB;
    public float waitTime = 2f;

    private float xMin = -3.0f, xMax = 3.0f;

    private void Awake()
    {
        _RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _RB.velocity = new Vector3(0, 0, -speed);
    }

    private void OnEnable()
    {
        float randomX = Random.Range(xMin, xMax);
        transform.position = new Vector3(randomX, transform.position.y, parentGO.transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("SetInactive", inactiveTimer);
        }
        if (collision.gameObject.CompareTag("Rocks"))
        {
            SetInactive();
        }
    }

    void SetInactive()
    {
        explosionPS.transform.position = transform.position;
        explosionPS.SetActive(true);
        this.gameObject.SetActive(false);
    }
}

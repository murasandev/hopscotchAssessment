using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10;

    public GameObject parentGO;
    public GameObject explosionPS;
    Rigidbody _RB;
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

    private void OnTriggerEnter(Collider other)
    {
        explosionPS.transform.position = transform.position;
        explosionPS.SetActive(true);
        this.gameObject.SetActive(false);
    }
}

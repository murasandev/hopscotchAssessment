using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    public Transform playerGO;
    public BoxCollider boxCollider;

    private float minX = -3.0f, maxX = 7.0f, xPos;
    private float offScreenOffset = 25.0f;
    private float disableDistance = 10.0f;

    private void OnEnable()
    {
        RandomX();
        transform.position = new Vector3(xPos, transform.position.y, playerGO.transform.position.z - offScreenOffset);
    }
    // Update is called once per frame
    void Update()
    {
        DisableRock();
        DisableCollider();
    }
    void RandomX()
    {
        xPos = Random.Range(minX, maxX);
    }
    void DisableRock()
    {
        if (transform.position.z >= disableDistance)
        {
            this.gameObject.SetActive(false);
        }
    }
    void DisableCollider()
    {
        //if player gets squished between obstacle and back constraint
        if (transform.position.z >= 2f)
        {
            boxCollider.isTrigger = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableRockColliders : MonoBehaviour
{
    public BoxCollider boxCollider;

    // Update is called once per frame
    void Update()
    {
        DisableCollider();
    }

    private void OnEnable()
    {
        boxCollider.enabled = true;
    }

    void DisableCollider()
    {
        //if player gets squished between obstacle and back constraint
        if (transform.position.z >= 2f)
        {
            boxCollider.enabled = false;
        }
    }
}

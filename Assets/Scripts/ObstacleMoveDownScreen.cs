using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMoveDownScreen : MonoBehaviour
{
    public float speed = 15.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}

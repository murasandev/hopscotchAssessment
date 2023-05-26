using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    public Vector3 startPos;
    public float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / .5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > startPos.z + repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
